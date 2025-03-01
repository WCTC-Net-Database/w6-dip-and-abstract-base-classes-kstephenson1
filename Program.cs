using Microsoft.Extensions.DependencyInjection;
using w6_assignment_ksteph.Configuration;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Entities.Characters;
using w6_assignment_ksteph.Entities.Monsters;
using w6_assignment_ksteph.FileIO;
using w6_assignment_ksteph.UI;

namespace w6_assignment_ksteph;

class Program
{
    static void Main()
    {
        ServiceCollection services = new ServiceCollection();

        services.AddTransient<UnitManager>();
        //services.AddTransient<FileManager<Character>>();
        //services.AddTransient<FileManager<Monster>>();
        services.AddTransient<FileManager<Unit>>();
        services.AddTransient<UserInterface>();

        ServiceProvider provider = services.BuildServiceProvider();

        UnitManager unitManager = provider.GetRequiredService<UnitManager>();
        UserInterface userInterface = provider.GetRequiredService<UserInterface>();

        GameEngine engine = new GameEngine(unitManager, userInterface);
        engine.StartGameEngine();
    }
}
