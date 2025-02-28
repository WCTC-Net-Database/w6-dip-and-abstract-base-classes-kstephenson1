using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.CharacterBehaviors;

namespace w6_assignment_ksteph.Interfaces.UnitClasses;

public interface IArcher : IShootable
{
    // An Archer unit that is able to shoot.
    public void Attack(IEntity target) => Shoot(target);
}
