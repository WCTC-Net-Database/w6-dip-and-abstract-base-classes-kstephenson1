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
    public int Constitution { get; set; }       // CON
    public int Strength { get; set; }           // STR
    public int Magic { get; set; }              // MAG
    public int Dexterity { get; set; }          // DEX
    public int Speed { get; set; }              // SPD
    public int Luck { get; set; }               // LCK
    public int Defense { get; set; }            // DEF
    public int Resistance { get; set; }         // RES
}