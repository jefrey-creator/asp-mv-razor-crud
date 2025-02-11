1. Update connection string on appsettings.json
2. Click Tools > NuGet Package Manage > Package Manager Console
3. type the command:
    add-migration "Init"
    update-databse
4. run the application

Note: "Init" is the name for the migration. Must start with capital letter always for naming convention.