# KeycloakApiTemplate

## Migracje

### Dodanie migracji
```dotnet ef migrations add MigrationName -p Data/Data.csproj -s KeycloakApiTemplate/KeycloakApiTemplate.csproj --output-dir Migrations```

### Aktualizacja bazy
```dotnet ef database update -p Data/Data.csproj -s KeycloakApiTemplate/KeycloakApiTemplate.csproj```
