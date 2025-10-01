# KeycloakApiTemplate

## Migracje
```dotnet ef migrations add MigrationName -p Data/Data.csproj -s KeycloakApiTemplate/KeycloakApiTemplate.csproj --output-dir Migrations```
```dotnet ef database update -p Data/Data.csproj -s KeycloakApiTemplate/KeycloakApiTemplate.csproj```
