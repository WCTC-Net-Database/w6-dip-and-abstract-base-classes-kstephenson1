using w6_assignment_ksteph.FileIO;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Inventories;
using w6_assignment_ksteph.Items;

namespace w6_assignment_ksteph.UI;

public static class InventoryUI
{
    // The inventoryUI class contains methods to show the inventory UI.  Will probably be rededigned later.

    [Obsolete]
    public static void DisplayInventory(Inventory inventory) // takes in an inventory and displays it to the user
    {
        DisplayInventory(InventorySerializer.Serialize(inventory)!);
    }

    [Obsolete]
    private static void DisplayInventory(string inventoryString) // Takes the inventory string, splits it, and displays the inventory to the user.
    {
        Console.WriteLine($"Inventory:");

        if (inventoryString == "" || inventoryString == null)
        {
            Console.WriteLine("    - (Empty)");
        }
        else
        {
            List<IItem> items = InventorySerializer.Deserialize(inventoryString).Items!;

            foreach (IItem item in items)
            {
                Console.WriteLine($"    - {item.Name}");
            }

            Console.WriteLine("\n");
        }
    }
}
