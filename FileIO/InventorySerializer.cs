﻿namespace w6_assignment_ksteph.FileIO;

using System.Collections.Generic;
using w6_assignment_ksteph.Inventories;
using w6_assignment_ksteph.DataHelper;
using w6_assignment_ksteph.Items;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Items.WeaponItems;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.Items.ConsumableItems;
using w6_assignment_ksteph.Entities.Abstracts;

public class InventorySerializer
{
    // InventorySerializer contains fuctions to turn a string into List<Item> to Inventories and vice versa.
    public static Inventory Deserialize(string inventoryString)         // Converts String into Inventories
    {
        List<string> items = ToStringList(inventoryString);
        return DeserializeList(items);
    }

    public static string? Serialize(Inventory inventory)                // Converts Inventories into String
    {
        return ToString(ToItemList(inventory)!);
    }

    public static Inventory DeserializeList(List<string> itemArray)     // Converts String into Inventories
    {
        Inventory inventory = new();
        foreach (string item in itemArray)
        {
            var convertedItem = ConvertToItem(item);
            inventory.Items!.Add(convertedItem);
        }
        return inventory;
    }

    public static List<string>? SerializeList(Inventory inventory)      // Converts Inventories into String
    {
        List<string> itemArray = new();
        foreach (IItem item in inventory.Items!)
        {
            itemArray.Add(item.ID);
        }
        return itemArray;
    }

    private static List<string> ToStringList(string itemString)             //Converts String into List<string>
    {
        string[] items = itemString.Split('|');
        return items.ToList();
    }

    private static string ToString(List<IItem> items)                    // Converts List<Item> to String
    {
        if (items == null)
            return "";
        else
        {
            string inventory = "";

            foreach (IItem item in items)
            {
                if (inventory == "")
                    inventory += StringHelper.ToItemIdFormat(item.ID);
                else
                    inventory += "|" + StringHelper.ToItemIdFormat(item.ID);
            }

            return inventory;
        }
    }

    private static List<IItem>? ToItemList(Inventory inventory)          // Converts Inventories to List<Item>
    {
        return inventory.Items;
    }

    private static IItem ConvertToItem(string itemString)
    {
        return itemString switch
        {
            // Weapons
            "dagger" => new WeaponItem("dagger", "Dagger", WeaponType.Sword, WeaponRank.E, 45, 4, 80, 0, 1, 4, 1),
            "mace" => new WeaponItem("mace", "Mace", WeaponType.Axe, WeaponRank.E, 45, 4, 80, 0, 1, 4, 1),
            "staff" => new WeaponItem("staff", "Staff", WeaponType.Lance, WeaponRank.E, 45, 4, 80, 0, 1, 4, 1),
            "sword" => new WeaponItem("sword", "Sword", WeaponType.Sword, WeaponRank.E, 45, 4, 80, 0, 1, 4, 1),
            "bow" => new WeaponItem("bow", "Bow", WeaponType.Bow, WeaponRank.E, 45, 6, 70, 0, 2, 4, 1),

            "book_lightning" => new MagicWeaponItem("book_lightning", "Lightning", WeaponType.Elemental, WeaponRank.E, 30, 5, 80, 5, 2, 4, 1),
            "book_decay" => new MagicWeaponItem("book_decay", "Decay", WeaponType.Dark, WeaponRank.E, 30, 10, 60, 0, 2, 4, 1),
            "book_smite" => new MagicWeaponItem("book_smite", "Smite", WeaponType.Light, WeaponRank.E, 30, 4, 100, 15, 2, 4, 1),

            // Monster Only Weapons
            "ghostly_axe" => new WeaponItem("ghostly_axe", "Ghostly Axe", WeaponType.Axe, WeaponRank.E, 45, 6, 70, 2, 1, 0, 1),

            // Consumables
            "potion" => new ItemPotion(),
            //"book" => new ItemBook(),
            "lockpick" => new ItemLockpick(),

            "shield" => new Item(itemString),
            "robe" => new Item(itemString),
            "horse" => new Item(itemString),
            "cloak" => new Item(itemString),
            "armor" => new Item(itemString),

            _ => throw new ArgumentOutOfRangeException($"Item name out of range when converting from json: {itemString}")
        };
    }
}
