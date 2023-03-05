namespace MediatrTest.Application.CQRS.Commands.AddOrUpdateStore;

internal record AddOrUpdateStoreCommand(ItemModel ItemModel) : IRequest;
