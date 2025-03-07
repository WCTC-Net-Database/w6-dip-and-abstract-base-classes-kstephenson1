﻿using CsvHelper.Configuration.Attributes;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.Interfaces.UnitBehaviors;
using w6_assignment_ksteph.Interfaces.InventoryBehaviors;

namespace w6_assignment_ksteph.Interfaces;

public interface IEntity : ITargetable, IAttack, IHaveInventory, IUseItems
{
    // Interface tha allows units to exist.
    MoveCommand MoveCommand { set; get; }
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    Position Position { get; set; }
    public Stats Stats { get; set; }

    void Move();
    string GetHealthBar();
}
