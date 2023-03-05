namespace MediatrTest.Application.CQRS.Queries.StoreQueries;

internal class GetAllStoreDataHandler : IRequestHandler<GetAllStoreData, IEnumerable<StoreData>>
{
    private readonly IStoreDataRepository storeDataRepository;

    public GetAllStoreDataHandler(IStoreDataRepository storeDataRepository)
        => this.storeDataRepository = storeDataRepository;

    public Task<IEnumerable<StoreData>> Handle(GetAllStoreData request, CancellationToken cancellationToken)
        => storeDataRepository.GetAll();

}
