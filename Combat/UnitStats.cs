using Microsoft.VisualBasic;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.DataTypes;

namespace w6_assignment_ksteph.Combat;

public class UnitStats
{
    public UnitStats()
    {
        
    }

    // // // // // // // // // // // // // // // // //
    // Health                                       //
    // // // // // // // // // // // // // // // // //
    public int HitPoints  { get; set; }         //  HP
    public int MaxHitPoints { get; set; }       // MHP
    public int Constitution { get; set; }       // CON
    public int Movement { get; set; }           // MOV

    // // // // // // // // // // // // // // // // //
    // Primary Stats                                //
    // // // // // // // // // // // // // // // // //
    public int Strength { get; set; }           // STR
    public int Skill { get; set; }              // SKL
    public int Speed { get; set; }              // SPD
    public int Luck { get; set; }               // LCK
    public int Defense { get; set; }            // DEF
    public int Resistance { get; set; }         // RES

    // // // // // // // // // // // // // // // // //
    // Combat Calculations                          //
    // // // // // // // // // // // // // // // // //
    public int TriangleDamageModifier { get; set; }
    public int TriangleHitModifier { get; set; }
    public int Attack { get; set; }
    public int PhysicalResiliance { get; set; }
    public int MagicResiliance { get; set; }
    public int Damage { get; set; }
    public int Hit { get; set; }
    public int Avoid { get; set; }
    public int DisplayedHit { get; set; }
    public int Crit { get; set; }
    public int CritAvoid { get; set; }
    public int DisplayedCrit { get; set; }


}