using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.UnitBehaviors;
using w6_assignment_ksteph.Interfaces.ItemBehaviors;
using w6_assignment_ksteph.Items;

namespace w6_assignment_ksteph.Commands.ItemCommands;

public class DropItemCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IEntity _unit;
    private readonly IItem _item;

    public DropItemCommand(IEntity unit, IItem item)
    {
        _unit = unit;
        _item = item;
    }
    public void Execute()
    {
        Console.WriteLine($"{_unit.Name} threw away {_item.Name}.");
        _unit.Inventory.RemoveItem(_item);
    }
}
