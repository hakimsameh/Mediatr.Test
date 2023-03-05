namespace MediatrTest.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly ISender Sender;

    public ItemController(ISender sender)
        => Sender = sender;

    [HttpGet("GetItems")]
    public async Task<IEnumerable<ItemModel>> GetItems()
        => await Sender.Send(new GetAllItems());

    [HttpGet("GetLogs")]
    public async Task<IEnumerable<DataLog>> GetLogs()
        => await Sender.Send(new GetAllLogs());

    [HttpGet("GetStoreData")]
    public async Task<IEnumerable<StoreData>> GetStoreData() 
        => await Sender.Send(new GetAllStoreData());

    [HttpPost]
    public async Task<IActionResult> AddItemData([FromBody] ItemDto item)
    {
        var request = new AddItemCommand(item.ItemName, item.ItemDescription);
        await Sender.Send(request);
        return Ok(request);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateItemData([FromBody] UpdateItemDto item)
    {
        var request = new UpdateItemCommand(item.Id, item.ItemName, item.ItemDescription);
        await Sender.Send(request);
        return Ok(request);
    }
}
