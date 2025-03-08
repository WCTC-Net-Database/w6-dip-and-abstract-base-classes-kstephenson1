using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.Entities.Abstracts;
using w6_assignment_ksteph.Interfaces.UnitBehaviors;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Entities.Monsters;

public class EnemyGhost : MonsterBase, IFlyable
{
    // A Ghost unit that is able fly.
    public EnemyGhost()
    {

    }

    public EnemyGhost(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position, Stats stats)
    {

    }

    [Ignore]
    [JsonIgnore]
    public FlyCommand FlyCommand { get ; set ; } = null!;

    public void Fly()
    {
        FlyCommand = new(this);
        Invoker.ExecuteCommand(FlyCommand);
    }

    public override void Move() => Fly();

}
