namespace MediatrTest.Application.CQRS.Queries;

public record GetAllStoreData() : IRequest<IEnumerable<StoreData>>;

internal class GetAllStoreDataHandler : IRequestHandler<GetAllStoreData, IEnumerable<StoreData>>
{
    private readonly IStoreDataRepository storeDataRepository;

    public GetAllStoreDataHandler(IStoreDataRepository storeDataRepository)
    {
        this.storeDataRepository = storeDataRepository;
    }
    public Task<IEnumerable<StoreData>> Handle(GetAllStoreData request, CancellationToken cancellationToken)
        => storeDataRepository.GetAll();
    
}
