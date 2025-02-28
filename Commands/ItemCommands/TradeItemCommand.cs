using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.CharacterBehaviors;
using w6_assignment_ksteph.Interfaces.InventoryBehaviors;
using w6_assignment_ksteph.Interfaces.ItemBehaviors;
using w6_assignment_ksteph.Items;
using w6_assignment_ksteph.UI;

namespace w6_assignment_ksteph.Commands.ItemCommands;

public class TradeItemCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IEntity _unit;
    private readonly IItem _item;
    private IEntity _target;
    public TradeItemCommand(IEntity unit, IItem item)
    {
        _unit = unit;
        _item = item;
    }
    public void Execute()
    {
        _target = UserInterface.UnitSelectionMenu.Display($"Select unit to trade {_item} to.");

        if (_unit is IHaveInventory && _target is IHaveInventory)
        {
            if (!_target.Inventory.IsFull())
            {
                _unit.Inventory.RemoveItem(_item);
                _target.Inventory.AddItem(_item);
                Console.WriteLine($"{_unit.Name} traded {_item.Name} to {_target.Name}");
            }
            else
            {
                Console.WriteLine($"{_unit.Name} cound not trade {_item.Name} to {_target.Name}.");
                Console.WriteLine($"{_target.Name}'s inventory is full.");
            }
        }
    }
}
