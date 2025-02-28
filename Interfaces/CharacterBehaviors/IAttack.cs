using w6_assignment_ksteph.Commands.Invokers;
using w6_assignment_ksteph.Commands.ItemCommands;
using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Interfaces.ItemBehaviors;

namespace w6_assignment_ksteph.Interfaces.CharacterBehaviors;

public interface IAttack
{
    // Interface tha allows units to attack.
    CommandInvoker Invoker { set; get; }
    AttackCommand AttackCommand { set; get; }
    EquipCommand EquipCommand { set; get; }

    void Attack(IEntity target);
    void Equip(IWeaponItem item);
}
