using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.CharacterBehaviors;

namespace w6_assignment_ksteph.Commands.UnitCommands;

public class HealCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IEntity _unit;
    private readonly IEntity _target;
    private readonly Encounter _encounter;
    public HealCommand(IEntity unit, IEntity target)
    {
        _unit = unit;
        _target = target;
        _encounter = new(unit, target, 2, 6, 100, 10);
    }
    public void Execute()
    {
        if (_unit is IHeal)
        {
            if (_encounter.IsCrit())
            {
                Console.WriteLine($"{_unit.Name} critically heals {_target.Name} for {_encounter.Damage} hit points!");
                _target.Damage(_encounter.Damage * -1);
            }
            else if (_encounter.IsHit())
            {
                Console.WriteLine($"{_unit.Name} heals {_target.Name} for {_encounter.Damage} hit points.");
                _target.Damage(_encounter.Damage * -1);
            }
            else
            {
                Console.WriteLine($"{_unit.Name}'s misses {_target.Name}");
            }
        }
        else
        {
            Console.WriteLine($"{_unit} cannot heal.");
        }

    }
}
