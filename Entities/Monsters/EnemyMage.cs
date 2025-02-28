using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.Interfaces.UnitClasses;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Entities.Monsters;

public class EnemyMage : Monster, IMage
{
    // A Mage unit that is able to cast spells.
    public EnemyMage()
    {
        Inventory.Unit = this;
    }

    public EnemyMage(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        HitPoints = hitPoints;
        Inventory = inventory;
        Position = position;
        Inventory.Unit = this;
    }
    public CastCommand CastCommand { get; set; } = null!;

    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);
    }
}
