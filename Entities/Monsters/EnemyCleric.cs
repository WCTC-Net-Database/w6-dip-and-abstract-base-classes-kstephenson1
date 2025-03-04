using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.Entities.Abstracts;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.UnitClasses;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Entities.Monsters;

public class EnemyCleric : MonsterBase, ICleric
{
    // An Cleric unit that is able to heal and cast spells.
    public EnemyCleric()
    {
        Inventory.Unit = this;
    }

    public EnemyCleric(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        HitPoints = hitPoints;
        Inventory = inventory;
        Position = position;
        Inventory.Unit = this;
    }

    public HealCommand HealCommand { get; set; } = null!;
    public CastCommand CastCommand { get; set; } = null!;

    public void Heal(IEntity target)
    {
        HealCommand = new(this, target);
        Invoker.ExecuteCommand(HealCommand);
    }
    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);

    }
}
