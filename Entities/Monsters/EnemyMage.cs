using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.Entities.Abstracts;
using w6_assignment_ksteph.Interfaces.UnitClasses;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.Entities.Monsters;

public class EnemyMage : MonsterBase, IMage
{
    // A Mage unit that is able to cast spells.
    public EnemyMage()
    {

    }

    public EnemyMage(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position, Stats stats)
    {

    }

    [Ignore]
    [JsonIgnore]
    public CastCommand CastCommand { get; set; } = null!;

    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);
    }
}
