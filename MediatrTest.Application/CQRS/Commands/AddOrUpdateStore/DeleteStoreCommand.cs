namespace MediatrTest.Application.CQRS.Commands.AddOrUpdateStore;

public record DeleteStoreCommand(ItemModel ItemModel) :IRequest;
