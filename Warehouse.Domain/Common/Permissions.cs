namespace Warehouse.Domain.Common;
public static class Permissions
{
    public const string CreateEmployee = "create_employee";
    public const string UpdateEmployee = "update_employee";

    public const string CreateStorageCell = "create_storage_cell";
    public const string UpdateStorageCell = "update_storage_cell";

    public const string CreateSector = "create_sector";
    public const string UpdateSector = "update_sector";

    public const string UpdateItem = "update_item";
    public const string CreateItem = "create_item";

    public const string CreateCustomer = "create_customer";
    public const string UpdateCustomer = "update_customer";

    public static readonly List<string> All = new()
    {
        CreateEmployee,
        UpdateCustomer,
        UpdateEmployee,
        CreateStorageCell,
        UpdateStorageCell,
        CreateSector,
        UpdateSector,
        CreateItem,
        UpdateItem,
        CreateCustomer,
    };

    public static readonly List<string> Admin = new()
    {
        CreateSector, 
        UpdateSector,
        CreateStorageCell,
        UpdateStorageCell,
        CreateEmployee, 
        UpdateEmployee,
    };

}
