sleep 60s

/opt/mssql-tools/bin/sqlcmd -S carona_db -U sa -P Carona2024! -d master -i /tmp/01-create-db-and-tables.sql
/opt/mssql-tools/bin/sqlcmd -S carona_db -U sa -P Carona2024! -d master -i /tmp/02-initial-data.sql