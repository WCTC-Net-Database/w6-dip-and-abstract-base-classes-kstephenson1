﻿using w6_assignment_ksteph.Commands;
using w6_assignment_ksteph.Commands.ItemCommands;
using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.CharacterBehaviors;
using w6_assignment_ksteph.Interfaces.InventoryBehaviors;
using w6_assignment_ksteph.Interfaces.ItemBehaviors;

namespace w6_assignment_ksteph.UI.Menus.InteractiveMenus;

public class ItemCommandMenu : InteractiveSelectionMenu<ICommand>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    public override void Display()
    {
        throw new ArgumentException("CommandMenu(unit, prompt) requires a unit.");
    }

    public ICommand Display(IItem item, string prompt)
    {
        ICommand selection = default!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Update(item);
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

    public void Update(IItem item)
    {
        _menuItems = new();

        AddMenuItem($"Drop Item", $"Get rid of the item forever.", new DropItemCommand(null!, null!));
        AddMenuItem($"Trade Item", $"Gives this item to someone else.", new TradeItemCommand(null!, null!, null!));

        if (item is IConsumableItem consumableItem)
        {
            AddMenuItem($"Use Item", $"{consumableItem.Description}", new UseItemCommand(null!));
        }

        if (item is IWeaponItem weaponItem)
        {
            weaponItem.Inventory.IsEquipped(out IItem? equippedItem);
            if (weaponItem == equippedItem)
            {
                AddMenuItem($"[dim]Equip Item[/]", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", null!);
            }
            else
            {
                AddMenuItem($"Equip Item", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", new EquipCommand(null!, null!));
            }
        }

        AddMenuItem("Go Back", "", null!);

        BuildTable();
    }
}

