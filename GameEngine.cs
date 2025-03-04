using Spectre.Console;
using w6_assignment_ksteph.Commands;
using w6_assignment_ksteph.Commands.ItemCommands;
using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.DataHelper;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.CharacterBehaviors;
using w6_assignment_ksteph.Items.WeaponItems;
using w6_assignment_ksteph.UI;

namespace w6_assignment_ksteph;

public class GameEngine
{
    private UnitManager _unitManager;
    private UserInterface _userInterface;

    public GameEngine(UnitManager unitManager, UserInterface userInterface)
    {
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
        _userInterface.MainMenu.Display();

        // Builds the unit select menu.
        _userInterface.MainMenu.Update();
        _userInterface.UnitSelectionMenu.Update();

        while (true)
        {
            // Asks the user to choose a unit.
            IEntity unit1 = _userInterface.UnitSelectionMenu.Display("Select unit to control");
            if (unit1 == null) break;

            // If the selected unit is down, restarts
            if (unit1.HitPoints <= 0) continue;

            // Asks the user to choose an action for unit.
            ICommand command = _userInterface.CommandMenu.Display(unit1, $"Select action for {unit1.Name}");
            if (command == null) continue; // Go back was selected, sends back to unit selection.

            // If the unit is able to move, the unit moves.
            if (command.GetType() == typeof(MoveCommand))
            {
                unit1.Move();
            }

            // If the unit has a usable item, it can use an item.
            else if (command.GetType() == typeof(UseItemCommand))
            {
                if (unit1.Inventory.Items!.Count > 0)
                {
                    // Shows a list of items that are in the selected unit's inventory and asks the user to select an item.
                    IItem item = _userInterface.InventoryMenu.Display(unit1, $"Select item for {unit1.Name}.");

                    // Item is null if the user selects go back.
                    if ( item != null)
                    {
                        // Checks the items to see what commands are allowed, displays those commands to the user and asks for a selection
                        ICommand itemCommand = _userInterface.ItemCommandMenu.Display(item, $"Select action for {unit1.Name} to use on {item.Name}");

                        // Command is null if the user selects "Go Back"
                        if ( itemCommand != null ) 
                        {
                            // The selected command is executed by the selected unit.
                            switch (itemCommand) 
                            {
                                case EquipCommand:
                                    unit1.Equip((item as WeaponItem)!);
                                    break;
                                case UseItemCommand:
                                    unit1.UseItem(item);
                                    break;
                                case TradeItemCommand:
                                    IEntity tradeTarget = _userInterface.UnitSelectionMenu.Display($"Select unit to trade {item} to.");
                                    unit1.TradeItem(item, tradeTarget);
                                    break;
                                case DropItemCommand:
                                    unit1.DropItem(item);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{unit1.Name} has no usable items!");
                }

            }// If the unit is able to attack, it attacks.
            else if (command.GetType() == typeof(AttackCommand))
            {
                if (unit1 is IAttack)
                {
                    IEntity unit2 = _userInterface.UnitSelectionMenu.Display($"Select unit being attacked by {unit1.Name}");
                    unit1.Attack(unit2);
                }
            }
            // If the unit is able to heal, it heals.
            else if (command.GetType() == typeof(HealCommand))
            {
                IEntity unit2 = _userInterface.UnitSelectionMenu.Display($"Select unit being healed by {unit1.Name}");
                ((IHeal)unit1).Heal(unit2);
            }
            // If the unit is able to cast spells, it casts a spell.
            else if (command.GetType() == typeof(CastCommand))
            {
                string spell = Input.GetString($"Enter name of spell being cast by {unit1.Name}: ");
                ((ICastable)unit1).Cast(spell);
            }

            // Rebuilds the unit selection menu so that the health bars are updated.
            _userInterface.UnitSelectionMenu.Update();

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
