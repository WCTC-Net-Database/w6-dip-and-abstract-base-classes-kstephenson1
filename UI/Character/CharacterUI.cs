using Spectre.Console;
using w6_assignment_ksteph.Entities.Characters;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Items;

namespace w6_assignment_ksteph.UI;

public static class CharacterUI
{
    // CharacterUI helps display character information in a nice little table.

    public static void DisplayCharacterInfo(Character character) // Displays the character's info
    {
        // Builds a character table with 2 lines: Name, Level and Class.
        Grid charTable = new Grid().Width(25).AddColumn();
        charTable
            .AddRow(new Text(character.Name).Centered())
                .AddRow(new Text($"Level {character.Level} {character.Class}").Centered());

        // Builds an hp table that contains the health of the character
        Grid hpTable = new Grid().Width(15).AddColumn();
        hpTable
            .AddRow(new Text($"Hit Points:").Centered())
                .AddRow(new Text($"{character.HitPoints}/{character.MaxHitPoints}").Centered());

        //Creates a table that just says "Inventory:" This may be redesigned later.
        Grid invHeader = new Grid().Width(25).AddColumn();
        invHeader
            .AddRow(new Text($"{character.Position.ToString()}").RightJustified());

        // Creates an inventory table that lists all the items in the character's inventory.
        Grid invTable = new Grid();
        invTable.AddColumn();

        if (character.Inventory.Items!.Count != 0)
        {
            foreach (IItem item in character.Inventory.Items!)
            {
                invTable.AddRow(item.Name);
            }
        }
        else
        {
            invTable.AddRow("(No Items)");
        }

        // Creates a display table that contains all the other tables to create a nice little display.
        Table displayTable = new Table();
        displayTable
            .AddColumn(new TableColumn(charTable))
            .AddColumn(new TableColumn(hpTable))
            .AddRow(invHeader, invTable);

        // Displays the table to the user.
        AnsiConsole.Write(displayTable);
    }
}
