using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.CharacterBehaviors;

namespace w6_assignment_ksteph.Commands.UnitCommands;

public class AttackCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IEntity _unit;
    private readonly IEntity _target;
    private readonly Encounter _encounter;
    public AttackCommand(IEntity unit, IEntity target)
    {
        _unit = unit;
        _target = target;
        _encounter = new(unit, target);
    }
    public void Execute()
    {
        if (_unit is IAttack)
        {
            if (_unit != _target)
            {
                Console.WriteLine($"{_unit.Name} attacks {_target.Name}");

                if (_encounter.IsCrit())
                {
                    Console.WriteLine($"{_unit.Name} critically hit {_target.Name} for {_encounter.Damage} damage!");
                    _target.Damage(_encounter.Damage);
                }
                else if (_encounter.IsHit())
                {
                    Console.WriteLine($"{_unit.Name} hit {_target.Name} for {_encounter.Damage} damage.");
                    _target.Damage(_encounter.Damage);
                }
                else
                {
                    Console.WriteLine($"{_unit.Name}'s misses {_target.Name}");
                }
            } else
            {
                Console.WriteLine($"{_unit.Name} should not attack themselves.  That's not very nice!");
            }
        }
        else
        {
            Console.WriteLine($"{_unit} cannot attack.");
        }
    }
}