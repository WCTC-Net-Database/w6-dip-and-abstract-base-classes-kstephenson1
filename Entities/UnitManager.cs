using w6_assignment_ksteph.Entities.Characters;
using w6_assignment_ksteph.Entities.Monsters;
using w6_assignment_ksteph.FileIO;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Items;
using w6_assignment_ksteph.UI;

namespace w6_assignment_ksteph.Entities;

public static class UnitManager
{
    // The UnitManager class is a static class that holds lists of units for reference.
    public static UnitSet<Character> Characters { get; private set; } = new();
    public static UnitSet<Monster> Monsters { get; private set; } = new();

    public static void DisplayCharacters()                       //Displays each c's information.
    {
        Console.Clear();

        foreach (Character character in Characters.Units)
        {
            character.DisplayCharacterInfo();
        }
    }


    public static void ImportUnits()                           //Imports the characters from the csv file and stores them.
    {
        List<Character> importedCharacters = new FileManager<Character>().Import<Character>();

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

        List<Monster> importedMonsters = new FileManager<Monster>().Import<Monster>();
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

    public static void ExportUnits()                           //Exports the stored characters into the specified csv file
    {
        new FileManager<Character>().Export<Character>(Characters.Units);
        new FileManager<Monster>().Export<Monster>(Monsters.Units);
    }

    public static void AddCharacter(Character character)            // Adds a new c to the stored characters list.
    {
        Characters.AddUnit(character);
    }

    public static void DeleteCharacter(Character character)         // Removes a c from the stored characters list.
    {
        Characters.DeleteUnit(character);
    }
}
