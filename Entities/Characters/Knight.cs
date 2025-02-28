using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Entities.Characters;

public class Knight : Character
{
    // An Fighter unit that is able to fight.
    public Knight()
    {
        Inventory.Unit = this;
    }
    public Knight(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position)
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
