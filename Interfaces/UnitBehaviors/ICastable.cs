using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.Commands.Invokers;
using w6_assignment_ksteph.Commands.UnitCommands;

namespace w6_assignment_ksteph.Interfaces.UnitBehaviors;

public interface ICastable
{
    public Stats Stats { get; set; }
    // Interface tha allows units to cast spells.
    CommandInvoker Invoker { set; get; }
    CastCommand CastCommand { set; get; }
    void Cast(string spellName);
}
