using System.Text.Json.Serialization;
using w6_assignment_ksteph.DataHelper;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Items;

public class Item : IItem
{
    // Item is a class that holds item information.
    [JsonIgnore]
    public Inventory Inventory { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ID { get; set; }

    public Item() { }

    public Item(string id)
    {
        ID = StringHelper.ToItemIdFormat(id);
        Name = StringHelper.ToItemNameFormat(id);
        Description = StringHelper.ToItemNameFormat(Name);
    }

    public Item(string id, string name)
    {
        ID = StringHelper.ToItemIdFormat(id);
        Name = StringHelper.ToItemNameFormat(name);
        Description = StringHelper.ToItemNameFormat(Name);
    }

    public override string ToString()
    {
        return ID;
    }

}
