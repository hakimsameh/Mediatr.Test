
namespace MediatrTest.Domain.Model;

public class ItemModel : AggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public static ItemModel Create(string name, string description)
        => new() { Id = Guid.NewGuid(), Name = name, Description = description };
    public void UpdateData(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public void Submit(EditMode editMode)
        => RaiseDomainEvent(new ItemSubmittedEvent(this, editMode));

}
