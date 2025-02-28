using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.CharacterBehaviors;

namespace w6_assignment_ksteph.Interfaces.UnitClasses;

public interface ICleric : IHeal, ICastable
{
    // An Cleric unit that is able to heal and cast spells.

}
