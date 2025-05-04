namespace Warehouse.Application.Commands.CreateItem;

public record CreateItemRequest(
    string CustomerId,
    string itemName,
    double Heigtht,
    double Width,
    double Depth);