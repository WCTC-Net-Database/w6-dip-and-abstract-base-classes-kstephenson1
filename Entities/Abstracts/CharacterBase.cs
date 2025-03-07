namespace w6_assignment_ksteph.Entities.Abstracts;

using System.Text.Json.Serialization;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.Inventories;
using w6_assignment_ksteph.UI;

// The character class stores information for each character.
public abstract class CharacterBase : UnitBase
{

    public override string ToString()
    {
        return $"{Name},{Class},{Level},{Stats.HitPoints},{Inventory}";
    }
}
