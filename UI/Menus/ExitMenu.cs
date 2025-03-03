using Spectre.Console;

namespace w6_assignment_ksteph.UI;

public class ExitMenu : Menu
{
    // The Menus class is an abstract(ish) class to build other menus off of.  The Menus class holds a table which is part of the user interface
    // which is displayed to the user.  The Menu also holds menu items, which can store different types of data.  It can be used by itself if you
    // want a simple message box.

    protected Table _table = new();
    protected List<MenuItem> _menuItems = new();

    public ExitMenu()
    {
        Update();
        BuildTable();
    }

    public void Display()
    {
        Update();
        Show();
    }

    public void Update()
    {
        _menuItems = new();
        AddMenuItem("                                                                      ");
        AddMenuItem("           Thank you for using the RPG Character Simulator.           ");
        AddMenuItem("                              By Kyle S.                              ");
        AddMenuItem("                                                                      ");
    }
}

