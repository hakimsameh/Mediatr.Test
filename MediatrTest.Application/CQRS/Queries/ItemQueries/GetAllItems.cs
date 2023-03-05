namespace MediatrTest.Application.CQRS.Queries.ItemQueries;

public record GetAllItems : IRequest<IEnumerable<ItemModel>>;
