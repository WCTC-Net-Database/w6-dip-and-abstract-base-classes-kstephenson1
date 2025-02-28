using w6_assignment_ksteph.Entities.Characters;
using w6_assignment_ksteph.Entities.Monsters;
using w6_assignment_ksteph.FileIO;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Items;
using w6_assignment_ksteph.UI;

namespace w6_assignment_ksteph.Entities;

public class UnitManager
{
    // The UnitManager class is a static class that holds lists of units for reference.
    private FileManager<Character> _characterFileManager;
    private FileManager<Monster> _monsterFileManager;
    public static UnitSet<Character> Characters { get; private set; } = new();
    public static UnitSet<Monster> Monsters { get; private set; } = new();

    public UnitManager(FileManager<Character> characterFileManager, FileManager<Monster> monsterFileManager)
    {
        _characterFileManager = characterFileManager;
        _monsterFileManager = monsterFileManager;
    }


    public void ImportUnits()                           //Imports the characters from the csv file and stores them.
    {
        List<Character> importedCharacters = _characterFileManager.Import<Character>();

        foreach (Character c in importedCharacters)
        {
            // Units imported from the characters file are imported as characters.  This block of text converts these characters to their respective types.
            // Is there a way to automate this without having to add a new line for every unit I add?
            if (c.Class == "Cleric")    Characters.AddUnit(new Cleric(c.Name, c.Class, c.Level, c.HitPoints, c.Inventory, c.Position));
            if (c.Class == "Fighter")   Characters.AddUnit(new Fighter(c.Name, c.Class, c.Level, c.HitPoints, c.Inventory, c.Position));
            if (c.Class == "Knight")    Characters.AddUnit(new Knight(c.Name, c.Class, c.Level, c.HitPoints, c.Inventory, c.Position));
            if (c.Class == "Rogue")     Characters.AddUnit(new Rogue(c.Name, c.Class, c.Level, c.HitPoints, c.Inventory, c.Position));
            if (c.Class == "Wizard")    Characters.AddUnit(new Wizard(c.Name, c.Class, c.Level, c.HitPoints, c.Inventory, c.Position));
        }

        List<Monster> importedMonsters = _monsterFileManager.Import<Monster>();
        foreach (Monster monster in importedMonsters)
        {
            // Units imported from the monsters file are imported as monsters.  This block of text converts these monsters to their respective types.
            // Is there a way to automate this without having to add a new line for every unit I add?

            if (monster.Class == "Archer")  Monsters.AddUnit(new EnemyArcher(monster.Name, monster.Class, monster.Level, monster.HitPoints, monster.Inventory, monster.Position));
            if (monster.Class == "Ghost")   Monsters.AddUnit(new EnemyGhost(monster.Name, monster.Class, monster.Level, monster.HitPoints, monster.Inventory, monster.Position));
            if (monster.Class == "Goblin")  Monsters.AddUnit(new EnemyGoblin(monster.Name, monster.Class, monster.Level, monster.HitPoints, monster.Inventory, monster.Position));
            if (monster.Class == "Mage")    Monsters.AddUnit(new EnemyMage(monster.Name, monster.Class, monster.Level, monster.HitPoints, monster.Inventory, monster.Position));
            if (monster.Class == "Cleric")  Monsters.AddUnit(new EnemyCleric(monster.Name, monster.Class, monster.Level, monster.HitPoints, monster.Inventory, monster.Position));
        }

        foreach (IEntity unit in Characters.Units)
        {
            unit.MaxHitPoints = unit.HitPoints;
            unit.Inventory.Unit = unit;
            foreach (IItem item in unit.Inventory.Items!)
            {
                item.Inventory = unit.Inventory;
            }
        }

        foreach (IEntity unit in Monsters.Units)
        {
            unit.MaxHitPoints = unit.HitPoints;
        }
    }

    public void ExportUnits()                           //Exports the stored characters into the specified csv file
    {
        _characterFileManager.Export<Character>(Characters.Units);
        _monsterFileManager.Export<Monster>(Monsters.Units);
    }
}
