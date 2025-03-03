using w6_assignment_ksteph.Commands;
using w6_assignment_ksteph.Commands.ItemCommands;
using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.CharacterBehaviors;
using w6_assignment_ksteph.Interfaces.InventoryBehaviors;
using w6_assignment_ksteph.Interfaces.ItemBehaviors;

namespace w6_assignment_ksteph.UI.Menus.InteractiveMenus;

public class InventoryMenu : InteractiveSelectionMenu<IItem>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    public override void Display()
    {
        throw new ArgumentException("CommandMenu(unit, prompt) requires a unit.");
    }

    public IItem Display(IEntity unit, string prompt)
    {
        IItem selection = default!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Update(unit);
            Show();
            ConsoleKey key = ReturnValidKey();
            selection = DoKeyActionReturnUnit(key, out exit);
        }
        return selection;
    }

    public override void Update()
    {
        throw new ArgumentException("Update(item) requires an item.");
    }

    public void Update(IEntity unit)
    {
        _menuItems = new();

        foreach (IItem item in unit.Inventory.Items!)
        {
            if (item is IConsumableItem consumableItem)
            {
                AddMenuItem($"{consumableItem.Name}", $"[[{consumableItem.UsesLeft}/{consumableItem.MaxUses}]] {consumableItem.Description}", item);
            }
            else if (item is IWeaponItem weaponItem)
            {
                unit.Inventory.IsEquipped(out IItem? equippedItem);
                if (weaponItem == equippedItem)
                {
                    AddMenuItem($"{weaponItem.Name}", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description} (Equipped)", item);
                }
                else
                {
                    AddMenuItem($"{weaponItem.Name}", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", item);
                }
            }
            else
            {
                AddMenuItem(item.Name, item.Description, item);
            }
        }
        AddMenuItem("Go Back", "", null!);

        BuildTable();
    }
}

