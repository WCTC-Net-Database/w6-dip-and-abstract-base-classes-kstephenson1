using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Serialization;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Entities.Characters;
using w6_assignment_ksteph.Entities.Monsters;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Inventories;

namespace w6_assignment_ksteph.FileIO.Json.Converters;

// The JsonInventoryConverter is used to turn json format into an Inventories Object automatically.
public class JsonUnitConverter : JsonConverter<Unit>
{
    public override Unit? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            var typeProperty = root.GetProperty("$type").GetString();

            //typeProperty = "w6_assignment_ksteph.Entities." + typeProperty;

            Type type = typeProperty switch
            {
                "Characters.Cleric" => typeof(Cleric),
                "Characters.Fighter" => typeof(Fighter),
                "Characters.Knight" => typeof(Knight),
                "Characters.Rogue" => typeof(Rogue),
                "Characters.Wizard" => typeof(Wizard),

                "Monsters.EnemyArcher" => typeof(EnemyArcher),
                "Monsters.EnemyCleric" => typeof(EnemyCleric),
                "Monsters.EnemyGhost" => typeof(EnemyGhost),
                "Monsters.EnemyGoblin" => typeof(EnemyGoblin),
                "Monsters.EnemyMage" => typeof(EnemyMage),
                _ => throw new NotSupportedException($"Type {typeProperty} is not supported")
            };

            return (Unit)JsonSerializer.Deserialize(root.GetRawText(), type, options);
        }
    }

    public override void Write(Utf8JsonWriter writer, Unit unit, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)unit, options);
    }
}
