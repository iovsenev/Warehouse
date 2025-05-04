using Warehouse.Domain.Common;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Interfaces;

namespace Warehouse.Application.Commands.CreateItem;
public class CreateItemCommand
{
    private readonly ICustomerRepository _repository;

    public CreateItemCommand(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> CummandRun(CreateItemRequest requst, CancellationToken token)
    {
        var item = new Item
        {
            Name = requst.itemName,
            Width = requst.Width,
            Height = requst.Heigtht,
            Depth = requst.Depth,
        };

        var result = await _repository.CreateItem(Guid.Parse(requst.CustomerId), item, token);

        if (result.IsFailure)
            return result.Error;
        return result.Value;
    }
}
