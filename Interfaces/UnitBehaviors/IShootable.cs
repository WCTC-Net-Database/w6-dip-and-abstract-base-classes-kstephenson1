﻿using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w6_assignment_ksteph.Commands.Invokers;
using w6_assignment_ksteph.Commands.UnitCommands;

namespace w6_assignment_ksteph.Interfaces.UnitBehaviors;

public interface IShootable
{
    // Interface tha allows units to shoot.
    CommandInvoker Invoker { set; get; }
    ShootCommand ShootCommand { set; get; }
    void Shoot(IEntity target);
}
