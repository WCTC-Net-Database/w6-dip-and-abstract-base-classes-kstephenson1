using System.Text.Json;
using w6_assignment_ksteph.Entities.Characters;
using w6_assignment_ksteph.Entities.Monsters;
using w6_assignment_ksteph.FileIO;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Items;
using w6_assignment_ksteph.Items.WeaponItems;

namespace w6_assignment_ksteph.Inventories;

public static class ItemManager
{
    // The ItemManager class is a static class that holds lists of items for reference.
    public static List<IItem> Items { get; set; } = new();

    public static void Import<TItem>() where TItem : Item                       //Imports the items from the files and stores them.
    {
        List<TItem> importedItemList = new FileManager<TItem>().Import<TItem>();
        foreach (TItem item in importedItemList)
        {
            Items.Add(item);
        }
    }

    public static void Export<TItem>(List<TItem> items)                         //Exports the stored items into the specified file
    {
        new FileManager<TItem>().Export<TItem>(items);
    }

    public static void AddItem(Item item)                                       // Adds a new item to the stored item list.
    {
        Items.Add( item);
    }

    public static void DeleteItem(Item item)                                    // Removes a item from the stored item list.
    {
        Items.Remove(item);
    }


}
