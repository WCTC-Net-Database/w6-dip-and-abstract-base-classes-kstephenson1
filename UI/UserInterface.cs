using w6_assignment_ksteph.Commands;
using w6_assignment_ksteph.Commands.ItemCommands;
using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Entities.Characters;
using w6_assignment_ksteph.FileIO;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.CharacterBehaviors;
using w6_assignment_ksteph.Interfaces.InventoryBehaviors;
using w6_assignment_ksteph.Interfaces.ItemBehaviors;
using w6_assignment_ksteph.UI.Menus.InteractiveMenus;

namespace w6_assignment_ksteph.UI;

// The UserInterface class contains elements for the UI including the main menu and the exit message.
public class UserInterface
{
    public InteractiveMainMenu MainMenu { get; private set; } = new();
    public InteractiveSelectionMenu<IEntity> UnitSelectionMenu { get; private set; } = new();
    public InteractiveSelectionMenu<ICommand> CommandMenu { get; private set; } = new();
    public InteractiveSelectionMenu<IItem> InventoryMenu { get; private set; } = new();
    public InteractiveSelectionMenu<ICommand> ItemMenu { get; private set; } = new();
    public InteractiveSelectionMenu<bool> BoolMenu { get; private set; } = new();
    public Menu ExitMenu { get; private set; } = new();

    // Builds main menu and the exit message.
    public void BuildMenus() 
    {
        BuildInteractiveMainMenu();
        BuildUnitSelectMenu();
        BuildExitMenu();
    }

    // Builds the main menu.  The main menu stores an index (AutoNumber), option, description, and an action.
    // Used for quick and easy reference later when these menus are shown and the selection action is executed.
    private void BuildInteractiveMainMenu() 
                                                   
    {
        MainMenu = new();
        MainMenu.AddMenuItem("Display All Characters",  "Displays all characters and items in their inventory.",    CharacterUtilities.DisplayCharacters);
        MainMenu.AddMenuItem("Find Character",          "Finds an existing character by name.",                     CharacterUtilities.FindCharacter);
        MainMenu.AddMenuItem("New Character",           "Creates a new character.",                                 CharacterUtilities.NewCharacter);
        MainMenu.AddMenuItem("Level Up Chracter",       "Levels an existing character.",                            CharacterUtilities.LevelUp);
        MainMenu.AddMenuItem("Change File Format",      "Changes the file format between Csv and Json",             FileManager<Character>.SwitchFileType);
        MainMenu.AddMenuItem("Start Game",              "",                                                         DoNothing);
        MainMenu.BuildTable();
    }

    // Builds the exit message.  It's technically a menu but who cares.
    private void BuildExitMenu()
    {
        ExitMenu = new();
        ExitMenu.AddMenuItem("                                                                      ");
        ExitMenu.AddMenuItem("           Thank you for using the RPG Character Simulator.           ");
        ExitMenu.AddMenuItem("                              By Kyle S.                              ");
        ExitMenu.AddMenuItem("                                                                      ");
        ExitMenu.BuildTable();
    }

    // Builds the unit selection menu.  This menu takes all the characters and monsters and puts them into a selectable menu.  This menu
    // displays the characters in green, monsters in red, and contains basic unit info and health bars.  Downed units are dimmed out.
    public void BuildUnitSelectMenu()
    {
        int prevIndex = UnitSelectionMenu.GetSelectedIndex();
        UnitSelectionMenu = new(prevIndex);

        // Adds all the characters to the unit list using green letters.
        foreach (IEntity unit in UnitManager.Characters.Units)
        {
            // Strikethrough and dim the unit info if the unit is not alive.
            if (unit.HitPoints <= 0)
            {
                UnitSelectionMenu.AddMenuItem($"[green][dim][strikethrough]{unit.Name} Level {unit.Level} {unit.Class}[/][/][/]", $" {unit.GetHealthBar()}", unit);
            }
            else
            {
                UnitSelectionMenu.AddMenuItem($"[green][bold]{unit.Name}[/][/] Level {unit.Level} {unit.Class}", $" {unit.GetHealthBar()}", unit);
            }
        }
        // Adds all the monsters to the unit list using red letters.
        foreach (IEntity unit in UnitManager.Monsters.Units)
        {
            if (unit.HitPoints <= 0)
            {
                // Strikethrough and dim the unit info if the unit is not alive.
                UnitSelectionMenu.AddMenuItem($"[red][dim][strikethrough]{unit.Name} Level {unit.Level} {unit.Class}[/][/][/]", $" {unit.GetHealthBar()}", unit);
            }
            else
            {
                UnitSelectionMenu.AddMenuItem($"[red][bold]{unit.Name}[/][/] Level {unit.Level} {unit.Class}", $" {unit.GetHealthBar()}", unit);
            }
        }
        UnitSelectionMenu.AddMenuItem($"Exit Game", $"", null!);

    }

    // Builds the menu that is used to select commands.  This menu takes in a unit and a prompt.  The menu has a list of commands, and checks to see
    // if the provided unit can do that command.  If the command is usable by that unit, the command is build into the table, and it is hidden if not.
    // Then the menu is ran with the prompt provided and returns the command selected by the user.  These commands are null and don't do anything.
    // Additional processing outside of this method is required.
    public ICommand ShowCommandMenu(IEntity unit, string prompt)
    {
        
        CommandMenu = new();

        CommandMenu.AddMenuItem("Move", "Moves the unit.", new MoveCommand(null!));

        if (unit is IHaveInventory)
        {
            if (unit.Inventory.Items!.Count != 0)
                CommandMenu.AddMenuItem("Items", "Uses an item in this unit's inventory.", new UseItemCommand(null!));
            else
                CommandMenu.AddMenuItem("[dim]Items[/]", "[dim]Uses an item in this unit's inventory.[/]", new UseItemCommand(null!));
        }

        if (unit is IAttack)
            CommandMenu.AddMenuItem("Attack", "Attacks a target unit.", new AttackCommand(null!, null!));

        if (unit is IHeal)
            CommandMenu.AddMenuItem("Heal", "Heals a target unit.", new HealCommand(null!, null!));

        if (unit is IHeal || unit is ICastable)
            CommandMenu.AddMenuItem("Cast", "Casts a spell.", new CastCommand(null!, "null"));

        CommandMenu.AddMenuItem("Go Back", "", null!);
        CommandMenu.BuildTable();
        return CommandMenu.Display(prompt);

    }

    // A menu that asks the user for a yes or no and returns the selection.
    public void BuildBoolMenu()
    {
        BoolMenu = new();
        BoolMenu.AddMenuItem("Yes", "", true);
        BoolMenu.AddMenuItem("No", "", true);
        BoolMenu.BuildTable();
    }

    // The ShowInventoryMenu is similar to the command menu, except it returns an item instead of a command.  It checks the provided unit
    // to retrieve a list of items in the unit's inventory, and displays those items in a menu and asks the user to select one.

    public IItem ShowInventoryMenu(IEntity unit, string prompt)
    {
        InventoryMenu = new();
        foreach (IItem item in unit.Inventory.Items!)
        {
            if (item is IConsumableItem consumableItem)
            {
                InventoryMenu.AddMenuItem($"{consumableItem.Name}", $"[[{consumableItem.UsesLeft}/{consumableItem.MaxUses}]] {consumableItem.Description}", item);
            }
            else if (item is IWeaponItem weaponItem)
            {
                unit.Inventory.IsEquipped(out IItem? equippedItem);
                if (weaponItem == equippedItem)
                {
                    InventoryMenu.AddMenuItem($"{weaponItem.Name}", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description} (Equipped)", item);
                }
                else
                {
                    InventoryMenu.AddMenuItem($"{weaponItem.Name}", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", item);
                }
            }
            else
            {
                InventoryMenu.AddMenuItem(item.Name, item.Description, item);
            }
        }
        InventoryMenu.AddMenuItem("Go Back", "", null!);
        InventoryMenu.BuildTable();
        return InventoryMenu.Display(prompt);
    }

    // The ShowItemMenu is similar to the command menu.  It checks the provided item to see if the item can be used with certain actions
    // and returns each action the item is usable in.  Asks the user to select one of the provided actions.
    public ICommand ShowItemMenu(IItem item, string prompt)
    {
        ItemMenu = new();

        ItemMenu.AddMenuItem($"Drop Item", $"Get rid of the item forever.", new DropItemCommand(null!, null!));
        ItemMenu.AddMenuItem($"Trade Item", $"Gives this item to someone else.", new TradeItemCommand(null!, null!, null!));

        if (item is IConsumableItem consumableItem)
        {
            ItemMenu.AddMenuItem($"Use Item", $"{consumableItem.Description}", new UseItemCommand(null!));
        }

        if (item is IWeaponItem weaponItem)
        {
            weaponItem.Inventory.IsEquipped(out IItem? equippedItem);
            if (weaponItem == equippedItem)
            {
                ItemMenu.AddMenuItem($"[dim]Equip Item[/]", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", null!);
            }
            else
            {
                ItemMenu.AddMenuItem($"Equip Item", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", new EquipCommand(null!, null!));
            }
        }
        
        ItemMenu.AddMenuItem("Go Back", "", null!);
        ItemMenu.BuildTable();
        return ItemMenu.Display(prompt);
    }

    public void Exit() // Shows the exit menu.
    {
        Console.Clear();
        ExitMenu.Show();
    }

    private void DoNothing() { } // This method does nothing...  or does it?
}
