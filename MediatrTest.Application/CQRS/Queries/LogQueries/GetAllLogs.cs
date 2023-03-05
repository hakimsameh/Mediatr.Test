namespace MediatrTest.Application.CQRS.Queries.LogQueries;

public record GetAllLogs : IRequest<IEnumerable<DataLog>>;

