using MediatrTest.Domain.Repositories;

namespace MediatrTest.Infrastructure.Repositories
{
    internal class DataLogRepository : RepositoryBase<DataLog, Guid>, IDataLogRepository
    {
        public DataLogRepository(MediatorContext context) : base(context)
        {
        }
    }
}
