namespace MediatrTest.Application.CQRS.Commands.AddLog;

internal record AddLogCommand(DataLog Data) : IRequest;
