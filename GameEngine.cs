using Spectre.Console;
using w6_assignment_ksteph.Commands;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.UI;

namespace w6_assignment_ksteph;

public class GameEngine
{
    private CommandHandler _commandHandler;
    private UnitManager _unitManager;
    private UserInterface _userInterface;

    public GameEngine(UnitManager unitManager, UserInterface userInterface, CommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
        _unitManager = unitManager;
        _userInterface = userInterface;
    }

    public void StartGameEngine()
    {
        Initialization();
        Run();
        Test();
        End();
    }

    void Test()
    {

    }

    public void Initialization()
    {
        // The Initialization method runs a few things that need to be done before the main part of the program runs.

        _unitManager.ImportUnits(); //Imports the caracters from the csv or json file.
    }

    public void Run()
    {
        // Shows the main menu.  Allows you to add/edit characters before the game is started.
        _userInterface.MainMenu.Display("[[Start Game]]");

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

    public void End()
    {
        // Exports the character list back to the chosen file format and ends the program.
        _unitManager.ExportUnits();
        _userInterface.ExitMenu.Show();
    }
}
