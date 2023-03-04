
namespace MediatrTest.Domain.Model;

public class StoreData : EntityBase<Guid>
{
    public Guid ItemId { get; private set; }
    public string ItemName { get; private set; }
    public int ItemQty { get; private set; }
    public static StoreData Create(Guid itemId, string itemName)
        => new(){ Id = Guid.NewGuid(), ItemId = itemId, ItemName = itemName, ItemQty = 1 };
    public void AddQty() 
        => ItemQty++;
    public void UpdateItem(string itemName)
        => ItemName = itemName;
}