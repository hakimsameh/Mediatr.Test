namespace MediatrTest.Application.CQRS.Commands.ItemCommands.AddItem;

public record AddItemCommand(string ItemName, string ItemDescription) : IRequest;
