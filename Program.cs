using Microsoft.Extensions.DependencyInjection;
using w6_assignment_ksteph.Commands;
using w6_assignment_ksteph.Entities;
using w6_assignment_ksteph.Entities.Abstracts;
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
        services.AddTransient<CommandHandler>();
        services.AddTransient<CommandMenu>();
        services.AddTransient<ExitMenu>();
        services.AddSingleton<FileManager<UnitBase>>();
        services.AddTransient<InventoryMenu>();
        services.AddTransient<ItemCommandMenu>();
        services.AddTransient<MainMenu>();
        services.AddSingleton<UnitClassMenu>();
        services.AddSingleton<UnitManager>();
        services.AddTransient<UnitSelectionMenu>();

        ServiceProvider provider = services.BuildServiceProvider();

        UnitManager unitManager = provider.GetRequiredService<UnitManager>();
        UserInterface userInterface = provider.GetRequiredService<UserInterface>();
        CommandHandler commandHandler = provider.GetRequiredService<CommandHandler>();

        GameEngine engine = new GameEngine(unitManager, userInterface, commandHandler);
        engine.StartGameEngine();
    }
}
