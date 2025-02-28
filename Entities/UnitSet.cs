﻿namespace w6_assignment_ksteph.Entities;

using w6_assignment_ksteph.FileIO;
using w6_assignment_ksteph.Interfaces;


// UnitSet<Ttype> is a class contains a list of a generic type of unit and functions that point toward this generic unit type's
// import and export methods.

public class UnitSet<TUnit> where TUnit : IEntity
{
    public virtual List<TUnit> Units { get; set; } = new(); // A list of characters objects for reference

    public void ImportUnits()                           //Imports the characters from the csv file and stores them.
    {
        Units = new FileManager<TUnit>().Import<TUnit>();
    }

    public void ExportUnits()                           //Exports the stored characters into the specified csv file
    {
        new FileManager<TUnit>().Export<TUnit>(Units);
    }

    public void AddUnit(TUnit unit)            // Adds a new character to the stored characters list.
    {
        Units.Add(unit);
    }

    public void DeleteUnit(TUnit unit)         // Removes a character from the stored characters list.
    {
        Units.Remove(unit);
    }
}
