﻿using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Serialization;
using w6_assignment_ksteph.Entities.Abstracts;
using w6_assignment_ksteph.Entities.Characters;
using w6_assignment_ksteph.Entities.Monsters;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.FileIO.Json.Converters;

// The JsonInventoryConverter is used to turn json format into an Inventories Object automatically.
public class JsonUnitConverter : JsonConverter<UnitBase>
{
    public override UnitBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var rootElement = jsonDocument.RootElement;
            var typeProperty = rootElement.GetProperty("$type").GetString();

            //typeProperty = "w6_assignment_ksteph.Entities." + typeProperty;

            Type unitType = UnitClassSerializer.Deserialize(typeProperty);
            

            return (UnitBase)JsonSerializer.Deserialize(rootElement.GetRawText(), unitType, options);
        }
    }

    public override void Write(Utf8JsonWriter writer, UnitBase unit, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)unit, options);
    }
}
