﻿using CsvHelper.Configuration;
using w6_assignment_ksteph.Entities.Abstracts;

namespace w6_assignment_ksteph.FileIO.Csv.Converters;

public class UnitMap : ClassMap<UnitBase>
{
    // The UnitMap assists the turning the csv file into units.
    // This class allows the inventory to be imported as a custom Inventories object instead of a string with
    // the help of the InventoryConverter
    public UnitMap()
    {
        Map(unit => unit.Name);
        Map(unit => unit.Class);
        Map(unit => unit.Level);
        Map(unit => unit.Inventory).TypeConverter(new CsvInventoryConverter());
        Map(unit => unit.Position).TypeConverter(new CsvPositionConverter());
    }
}
