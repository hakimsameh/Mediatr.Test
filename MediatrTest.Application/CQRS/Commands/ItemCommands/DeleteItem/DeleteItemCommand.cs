namespace MediatrTest.Application.CQRS.Commands.ItemCommands.DeleteItem;
public record DeleteItemCommand(Guid Id) : IRequest<bool>;
