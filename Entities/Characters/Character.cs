namespace w6_assignment_ksteph.Entities.Characters;

using System.Text.Json.Serialization;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.Inventories;
using w6_assignment_ksteph.UI;

// The character class stores information for each character.
public class Character : Unit
{
    public Character()
    {
        Inventory.Unit = this;
    }

    public Character(string name, string characterClass, int level, int hitPoints, Inventory inventory)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        HitPoints = hitPoints;
        MaxHitPoints = hitPoints;
        Inventory = inventory;
        Inventory.Unit = this;
    }

    public override string ToString()
    {
        return $"{Name},{Class},{Level},{HitPoints},{Inventory}";
    }
}
