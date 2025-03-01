using System.Text.Json.Serialization;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Entities.Characters;

public class Fighter : Character
{
    public Fighter()
    {
        Inventory.Unit = this;
    }
    public Fighter(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        HitPoints = hitPoints;
        Inventory = inventory;
        Position = position;
        Inventory.Unit = this;
    }
}
