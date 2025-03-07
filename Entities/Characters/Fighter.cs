using System.Text.Json.Serialization;
using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.Entities.Abstracts;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Entities.Characters;

public class Fighter : CharacterBase
{
    public Fighter()
    {

    }
    public Fighter(string name, string characterClass, int level, Inventory inventory, Position position, Stats stats)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        Inventory = inventory;
        Position = position;
        Stats = stats;
        Inventory.Unit = this;
    }
}
