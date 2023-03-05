namespace MediatrTest.Application.CQRS.Commands.ItemCommands.UpdateItem;

public record UpdateItemCommand(Guid Id, string ItemName, string ItemDescription) : IRequest;
