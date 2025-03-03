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

// The UserInterface class contains a list of various menu items for easy access.
public class UserInterface
{


    public CharacterUtilities _characterUtilities;
    public FileManager<Unit> _unitFileManager;
    public UnitManager _unitManager;
    public CommandMenu CommandMenu { get; private set; }
    public ExitMenu ExitMenu { get; private set; }
    public ItemCommandMenu ItemCommandMenu { get; private set; } = new();
    public InventoryMenu InventoryMenu { get; private set; } = new();
    public MainMenu MainMenu { get; private set; }
    public UnitSelectionMenu UnitSelectionMenu { get; private set; }

    public UserInterface(UnitManager unitManager, CharacterUtilities characterUtilities, FileManager<Unit> unitFileManager, MainMenu mainMenu, UnitSelectionMenu unitSelectionMenu, ExitMenu exitMenu, CommandMenu commandMenu, InventoryMenu inventoryMenu, ItemCommandMenu itemCommandMenu)
    {
        _characterUtilities = characterUtilities;
        _unitFileManager = unitFileManager;
        _unitManager = unitManager;
        CommandMenu = commandMenu;
        ExitMenu = exitMenu;
        ItemCommandMenu = itemCommandMenu;
        InventoryMenu = inventoryMenu;
        MainMenu = mainMenu;
        UnitSelectionMenu = unitSelectionMenu;
    }
}
