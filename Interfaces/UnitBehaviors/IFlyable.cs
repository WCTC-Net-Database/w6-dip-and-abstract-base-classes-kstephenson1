using w6_assignment_ksteph.Commands.Invokers;
using w6_assignment_ksteph.Commands.UnitCommands;
namespace w6_assignment_ksteph.Interfaces.UnitBehaviors;

public interface IFlyable
{
    // Interface tha allows units to fly.
    CommandInvoker Invoker { set; get; }
    FlyCommand FlyCommand { set; get; }
    void Fly();
}
