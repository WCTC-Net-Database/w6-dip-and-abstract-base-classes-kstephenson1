﻿using w6_assignment_ksteph.Entities.Abstracts;
using w6_assignment_ksteph.FileIO;
using w6_assignment_ksteph.Interfaces;

namespace w6_assignment_ksteph.Entities;

public class UnitManager
{
    // The UnitManager class is a static class that holds lists of units for reference.
    private FileManager<UnitBase> _unitFileManager;
    public UnitSet<CharacterBase> Characters { get; private set; } = new();
    public UnitSet<MonsterBase> Monsters { get; private set; } = new();

    public UnitManager(FileManager<UnitBase> unitFileManager)
    {
        _unitFileManager = unitFileManager;
    }


    public void ImportUnits()                           //Imports the characters from the csv file and stores them.
    {
        List<UnitBase> importedUnits = _unitFileManager.Import<UnitBase>();

        foreach (UnitBase unit in importedUnits)
        {
            if (unit is CharacterBase character)
            {
                Characters.AddUnit(character);
            }

            if (unit is MonsterBase monster)
            {
                Monsters.AddUnit(monster);
            }
        }

        foreach (IEntity unit in Characters.Units)
        {
            unit.Stats.MaxHitPoints = unit.Stats.HitPoints;
            unit.Inventory.Unit = unit;
            foreach (IItem item in unit.Inventory.Items!)
            {
                item.Inventory = unit.Inventory;
            }
        }

        foreach (IEntity unit in Monsters.Units)
        {
            unit.Stats.MaxHitPoints = unit.Stats.HitPoints;
        }
    }

    public void ExportUnits()                           //Exports the stored characters into the specified csv file
    {
        List<UnitBase> unitList = new();
        foreach (UnitBase character in Characters.Units)
        {
            unitList.Add(character);
        }

        foreach (MonsterBase monster in Monsters.Units)
        {
            unitList.Add(monster);
        }
        _unitFileManager.Export<UnitBase>(unitList);
    }
}
