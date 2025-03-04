using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Entities.Abstracts;

public abstract class MonsterBase : UnitBase
{
    // The Monster class is, for the most part, an abstract(ish) class that might contain some computer intelligence functions one day.
    public MonsterBase() { }

    public MonsterBase(string name, string characterClass, int level, int hitPoints, Inventory inventory)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        MaxHitPoints = hitPoints;
        Inventory = inventory;
        Inventory.Unit = this;
    }
}
