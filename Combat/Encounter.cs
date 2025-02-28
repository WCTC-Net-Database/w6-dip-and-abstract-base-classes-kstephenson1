using w6_assignment_ksteph.Interfaces;

namespace w6_assignment_ksteph.Combat;

public class Encounter
{
    // The encounter class is used to store and calculate information about combat encounters.  This object takes in an attacking unit,
    // target unit and will be able to generate combat chances and damages.

    private static Random _generator = new Random();
    int Roll;
    public IEntity Unit { get; set; }
    public IEntity Target { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public int HitChance { get; set; }
    public int CritChance { get; set; }
    public int Damage {  get; set; }

    public Encounter(IEntity unit, IEntity target, int minDamage, int maxDamage, int hitChance, int critChance)
    {
        Roll = _generator.Next(100) + 1;
        Unit = unit;
        Target = target;
        MinDamage = minDamage;      // These stats will eventually be calculated using unit stats instead of directly
        MaxDamage = maxDamage;      // in a constructor.
        HitChance = hitChance;      //
        CritChance = critChance;    //
        Damage = RollDamage();
    }


    public int RollDamage()
    {
        if (IsCrit())
        {
            return CalculateDamage() + CalculateDamage();
        }
        else if (IsHit())
        {
            return CalculateDamage();
        }
        return 0;
    }

    private int CalculateDamage()
    {
        return _generator.Next(MinDamage, MaxDamage + 1);
    }

    public bool IsCrit()
    {
        return Roll > MathF.Abs(CritChance - 100) ? true : false;
    }

    public bool IsHit()
    {
        return Roll > MathF.Abs(HitChance - 100) ? true : false;
    }

}
