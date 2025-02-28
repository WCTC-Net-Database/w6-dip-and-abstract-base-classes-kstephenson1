using w6_assignment_ksteph.DataHelper;
using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.Interfaces;

namespace w6_assignment_ksteph.Commands.UnitCommands;

public class MoveCommand : ICommand
{
    // The MoveCommand takes in a unit and a position, checks to see if the unit can move, then moves to that position of able.

    private readonly IEntity _unit;
    private Position _position;
    public MoveCommand(IEntity unit)
    {
        _unit = unit;
    }
    public void Execute()
    {
        if (_unit is IEntity)
        {
            int x = Input.GetInt("Enter target location's x-coordinate: ");
            int z = Input.GetInt("Enter target location's z-coordinate: ");
            _position = new(x, z);

            Console.WriteLine($"{_unit.Name} moves from {_unit.Position} to {_position}");
            _unit.Position = _position;
        }
        else
        {
            Console.WriteLine($"{_unit.Name} cannot move!");
        }

    }
}
