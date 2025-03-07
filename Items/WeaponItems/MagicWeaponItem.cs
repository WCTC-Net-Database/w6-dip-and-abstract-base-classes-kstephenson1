using System.Text.Json.Serialization;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.Interfaces.ItemBehaviors;
using w6_assignment_ksteph.Items;

namespace w6_assignment_ksteph.Items.WeaponItems;

public class MagicWeaponItem : EquippableItem
{
    // WeaponItem is a class that holds weapon item information

    public MagicWeaponItem(string id, string name, WeaponType weaponType, WeaponRank requiredRank, int maxDurability, int might, int hit, int crit, int range, int weight, int expModifier) : base(id, name, weaponType, requiredRank, maxDurability, might, hit, crit, range, weight, expModifier)
    {
        
    }

    public override string ToString()
    {
        return ID;
    }

}
