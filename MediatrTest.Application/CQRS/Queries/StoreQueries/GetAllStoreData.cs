namespace MediatrTest.Application.CQRS.Queries.StoreQueries;

public record GetAllStoreData() : IRequest<IEnumerable<StoreData>>;
