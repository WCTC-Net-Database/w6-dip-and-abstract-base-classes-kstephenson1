using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Interfaces.ItemBehaviors;

public interface IWeaponItem : IItem
{
    public WeaponType WeaponType { get; set; }
    public WeaponRank RequiredRank { get; set; }
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public int Might { get; set; }
    public int Hit { get; set; }
    public int Crit { get; set; }
    public int Range { get; set; }
    public int Weight { get; set; }
    public int ExpModifier { get; set; }
    public void Equip();
    public void TakeDurabilityDamage(int durabilityDamage);
    public void BreakItem();
}
