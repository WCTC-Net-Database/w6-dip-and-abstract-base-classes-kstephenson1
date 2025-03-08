using w6_assignment_ksteph.Commands.Invokers;
using w6_assignment_ksteph.Commands.ItemCommands;
using w6_assignment_ksteph.Interfaces.ItemBehaviors;
using w6_assignment_ksteph.Inventories;
using w6_assignment_ksteph.Items;

namespace w6_assignment_ksteph.Interfaces.UnitBehaviors;

public interface IUseItems
{
    // Interface tha allows units to hold items.
    CommandInvoker Invoker { get; set; }
    UseItemCommand UseItemCommand { get; set; }
    void UseItem(IItem item);
}
