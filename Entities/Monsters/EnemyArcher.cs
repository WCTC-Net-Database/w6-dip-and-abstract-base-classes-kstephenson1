using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.Entities.Abstracts;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.UnitClasses;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Entities.Monsters;

public class EnemyArcher : MonsterBase, IArcher
{
    // An Archer unit that is able to shoot.

    public EnemyArcher()
    {
        Inventory.Unit = this;
    }

    public EnemyArcher(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        HitPoints = hitPoints;
        Inventory = inventory;
        Position = position;
        Inventory.Unit = this;
    }

    public ShootCommand ShootCommand { get; set; }

    public void Shoot(IEntity target)
    {
        ShootCommand = new(this, target);
        Invoker.ExecuteCommand(ShootCommand);
    }

    public override void Attack(IEntity target) => Shoot(target);
}
