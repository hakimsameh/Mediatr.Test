using MediatR;
using MediatrTest.Application.CQRS.Commands;
using MediatrTest.Application.CQRS.Queries;
using MediatrTest.Domain.Model;
using MediatrTest.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace MediatrTest.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        public ItemController(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }

        [HttpGet("GetItems")]
        public async Task<IEnumerable<ItemModel>> GetItems()
        {
            var result = await Mediator.Send(new GetAllItems());
            return result;
        }
        [HttpGet("GetLogs")]
        public async Task<IEnumerable<DataLog>> GetLogs()
        {
            var result = await Mediator.Send(new GetAllLogs());
            return result;
        }
        [HttpGet("GetStoreData")]
        public async Task<IEnumerable<StoreData>> GetStoreData() =>
            await Mediator.Send(new GetAllStoreData());

        [HttpPost]
        public async Task<IActionResult> AddItemData([FromBody] ItemDto item)
        {
            var request = new AddItemCommand(item.ItemName, item.ItemDescription);
            await Mediator.Send(request);
            return Ok(request);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateItemData([FromBody] UpdateItemDto item)
        {
            var request = new UpdateItemCommand(item.Id, item.ItemName, item.ItemDescription);
            await Mediator.Send(request);
            return Ok(request);
        }
    }
}
