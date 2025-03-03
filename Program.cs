using Microsoft.Extensions.DependencyInjection;
using w6_assignment_ksteph.Configuration;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Entities.Characters;
using w6_assignment_ksteph.Entities.Monsters;
using w6_assignment_ksteph.FileIO;
using w6_assignment_ksteph.UI;
using w6_assignment_ksteph.UI.Menus.InteractiveMenus;

namespace w6_assignment_ksteph;

class Program
{
    static void Main()
    {
        ServiceCollection services = new ServiceCollection();

        services.AddTransient<UserInterface>();
        services.AddTransient<CharacterUtilities>();
        services.AddTransient<CharacterUI>();
        services.AddTransient<CommandMenu>();
        services.AddTransient<InventoryMenu>();
        services.AddTransient<ItemCommandMenu>();
        services.AddTransient<ExitMenu>();
        services.AddSingleton<FileManager<Unit>>();
        services.AddTransient<MainMenu>();
        services.AddSingleton<UnitManager>();
        services.AddTransient<UnitSelectionMenu>();

        ServiceProvider provider = services.BuildServiceProvider();

        UnitManager unitManager = provider.GetRequiredService<UnitManager>();
        UserInterface userInterface = provider.GetRequiredService<UserInterface>();

        GameEngine engine = new GameEngine(unitManager, userInterface);
        engine.StartGameEngine();
    }
}
