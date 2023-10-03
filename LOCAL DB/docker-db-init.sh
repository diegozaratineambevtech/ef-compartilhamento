#!/bin/bash

echo "waiting 30s for the SQL Server to come up..."
sleep 30s

echo "running set up script..."
/opt/mssql-tools/bin/sqlcmd -S "localhost" -U sa -P "SuperSenha2000!" -d master -i db-init.sql