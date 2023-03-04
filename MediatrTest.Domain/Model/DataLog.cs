namespace MediatrTest.Domain.Model;

public class DataLog : EntityBase<Guid>
{
    private DataLog() { }
    private DataLog(Guid id, DateTime logDate, string logData, string logType)
    {
        Id = id;
        LogDate = logDate;
        LogData = logData;
        LogType = logType;
    }

    public DateTime LogDate { get; private set; }
    public string LogData { get; private set; }
    public string LogType { get; private set; }
    public static DataLog Create(DateTime logDate, string logData, string logType)
        => new(Guid.NewGuid(), logDate, logData, logType);
}
