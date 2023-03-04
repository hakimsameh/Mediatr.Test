namespace MediatrTest.RequestModel;

public record ItemDto(string ItemName, string ItemDescription);

public record UpdateItemDto(Guid Id, string ItemName, string ItemDescription);
