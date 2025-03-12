﻿using Spectre.Console;
using w6_assignment_ksteph.Commands;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.UI;

namespace w6_assignment_ksteph.Combat;

public class CombatHandler
{
    private CommandHandler _commandHandler;
    private UserInterface _userInterface;
    public CombatHandler(CommandHandler commandHandler, UserInterface userInterface)
    {
        _commandHandler = commandHandler;
        _userInterface = userInterface;
    }
    public void StartCombat()
    {
        while (true)
        {
            // Asks the user to choose a unit.
            IEntity unit = _userInterface.UnitSelectionMenu.Display("Select unit to control", "[[Exit Game]]");
            if (unit == null) break;

            // If the selected unit is down, restarts
            if (unit.Stats.HitPoints <= 0) continue;

            // Asks the user to choose an action for unit.
            ICommand command = _userInterface.CommandMenu.Display(unit, $"Select action for {unit.Name}", "[[Go Back]]");
            if (command == null) continue; // Go back was selected, sends back to unit selection.

            // Takes the command and the unit and handles
            _commandHandler.HandleCommand(command, unit);

            // Waits for user input.  Escape leaves the program and any other button loops the process.
            AnsiConsole.MarkupLine($"\nPress [green][[ANY KEY]][/] to continue...");
            ConsoleKey key = Console.ReadKey(true).Key;
        }
    }
}
