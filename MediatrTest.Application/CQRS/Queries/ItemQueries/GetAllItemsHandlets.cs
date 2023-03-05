namespace MediatrTest.Application.CQRS.Queries.ItemQueries;

internal class GetAllItemsHandlets : IRequestHandler<GetAllItems, IEnumerable<ItemModel>>
{
    private readonly IItemModelRepository dataBase;

    public GetAllItemsHandlets(IItemModelRepository dataBase)
        => this.dataBase = dataBase;

    public async Task<IEnumerable<ItemModel>> Handle(GetAllItems request, CancellationToken cancellationToken)
        => await dataBase.GetAll();
}
