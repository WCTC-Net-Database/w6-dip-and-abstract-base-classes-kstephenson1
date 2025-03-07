using Microsoft.VisualBasic;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.DataTypes;
using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;

namespace w6_assignment_ksteph.Combat;

public class Stats
{
    public Stats()
    {
        
    }

    // // // // // // // // // // // // // // // // //
    // Health                                       //
    // // // // // // // // // // // // // // // // //
    public int HitPoints  { get; set; }         //  HP
    public int MaxHitPoints { get; set; }       // MHP
    public int Movement { get; set; }           // MOV

    // // // // // // // // // // // // // // // // //
    // Primary Stats                                //
    // // // // // // // // // // // // // // // // //
    public int Strength { get; set; }           // STR
    public int Dexterity { get; set; }          // DEX
    public int Speed { get; set; }              // SPD
    public int Luck { get; set; }               // LCK
    public int Defense { get; set; }            // DEF
    public int Resistance { get; set; }         // RES

    // // // // // // // // // // // // // // // // //
    // Combat Calculations                          //
    // // // // // // // // // // // // // // // // //

    [Ignore]
    [JsonIgnore]
    public int TriangleDamageModifier { get; set; }
    
    [Ignore]
    [JsonIgnore]
    public int TriangleHitModifier { get; set; }
    
    [Ignore]
    [JsonIgnore]
    public int Attack { get; set; }
    
    [Ignore]
    [JsonIgnore]
    public int PhysicalResiliance { get; set; }
    
    [Ignore]
    [JsonIgnore]
    public int MagicResiliance { get; set; }
    
    [Ignore]
    [JsonIgnore]
    public int Damage { get; set; }
    
    [Ignore]
    [JsonIgnore]
    public int Hit { get; set; }
    
    [Ignore]
    [JsonIgnore]
    public int Avoid { get; set; }
    
    [Ignore]
    [JsonIgnore]
    public int DisplayedHit { get; set; }
    
    [Ignore]
    [JsonIgnore]
    public int Crit { get; set; }

    [Ignore]
    [JsonIgnore]
    public int CritAvoid { get; set; }
    [Ignore]
    [JsonIgnore]
    public int DisplayedCrit { get; set; }


}