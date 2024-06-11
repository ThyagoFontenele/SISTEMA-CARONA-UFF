using CaronaUFF.Domain.Entities;
using CaronaUFF.Infrastructure.Mappings;
using CaronaUFF.Infrastructure.Mappings.Conventions;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace CaronaUFF.Infrastructure;

public class FluentNhibernateHelper
{
    private static readonly ISessionFactory _sessionFactory;

    static FluentNhibernateHelper() =>
        _sessionFactory = FluentConfigure();

    public static ISession GetCurrentSession() =>
        _sessionFactory.GetCurrentSession();

    public static void BeginTransaction()
    {
        var _session = _sessionFactory.OpenSession();
        _session.BeginTransaction();
        CurrentSessionContext.Bind(_session);
    }

    public static async Task CommitAsync()
    {
        var _session = _sessionFactory.GetCurrentSession();

        if (_session is null)
        {
            return;
        }

        await _session.GetCurrentTransaction().CommitAsync();
    }

    public static async Task RollbackAsync()
    {
        var _session = _sessionFactory.GetCurrentSession();

        if (_session is null)
        {
            return;
        }

        await _session.GetCurrentTransaction().RollbackAsync();
    }

    private static ISessionFactory FluentConfigure()
    {
        var config = new StoreConfiguration();
        
            
        var sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(ConnectionStrings.GetDefaultConnection())
                .ShowSql()
            )
            .Mappings(m => m.AutoMappings
                .Add(AutoMap
                    .AssemblyOf<IEntity>(config)
                    .IgnoreBase<IEntity>()
                    .UseOverridesFromAssemblyOf<UsuarioMappingOverride>()
                    .UseOverridesFromAssemblyOf<VeiculoMappingOverride>()
                    .Conventions.Add(new CustomForeignKeyConvention())
                )
            )
            .CurrentSessionContext<AsyncLocalSessionContext>()
            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
            .BuildSessionFactory();

        return sessionFactory;
    }
}