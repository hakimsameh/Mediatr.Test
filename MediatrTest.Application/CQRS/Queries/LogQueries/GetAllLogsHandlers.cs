namespace MediatrTest.Application.CQRS.Queries.LogQueries;

internal class GetAllLogsHandlers : IRequestHandler<GetAllLogs, IEnumerable<DataLog>>
{
    private readonly IDataLogRepository logData;

    public GetAllLogsHandlers(IDataLogRepository logData)
    {
        this.logData = logData;
    }
    public async Task<IEnumerable<DataLog>> Handle(GetAllLogs request, CancellationToken cancellationToken)
    {
        var data = await logData.GetAll();
        return data.OrderBy(x => x.LogDate);
    }
}

