using w6_assignment_ksteph.Commands.Invokers;
using w6_assignment_ksteph.Commands;
using w6_assignment_ksteph.Combat;

namespace w6_assignment_ksteph.Interfaces.CharacterBehaviors;

public interface IHaveStats
{
    // Interface that requires units to have stats.
    public UnitStats Stats { get; set; }
}
