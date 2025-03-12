using Spectre.Console;
using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.Commands;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.UI;

namespace w6_assignment_ksteph;

public class GameEngine
{
    private CombatHandler _combatHandler;
    private UnitManager _unitManager;
    private UserInterface _userInterface;

    public GameEngine(UnitManager unitManager, UserInterface userInterface, CombatHandler combatHandler)
    {
        _combatHandler = combatHandler;
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

        _combatHandler.StartCombat();
    }

    public void End()
    {
        // Exports the character list back to the chosen file format and ends the program.
        _unitManager.ExportUnits();
        _userInterface.ExitMenu.Show();
    }
}
