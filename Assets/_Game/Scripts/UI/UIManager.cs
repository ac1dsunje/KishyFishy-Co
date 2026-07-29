using System;
using System.Collections.Generic;

namespace _Game.Scripts.UI
{
public class UIManager: IDisposable
{
    private readonly InputHandler _input;
    private readonly Overlay _overlay;
    private readonly InventoryUI _inventory;
    private readonly CalendarUI _calendar;
    private readonly MapUI _map;

    private readonly List<ScreenManager> _screens = new();

    public UIManager(InputHandler input, Overlay overlay, InventoryUI inventoryUI, CalendarUI calendarUI, MapUI mapUI)
    {
        _input = input;
        _overlay = overlay;
        _inventory = inventoryUI;
        _calendar = calendarUI;
        _map = mapUI;

        _screens.Add(overlay);
        _screens.Add(inventoryUI);
        _screens.Add(calendarUI);
        _screens.Add(mapUI);

        _input.OnInventory += ShowInventory;
        _input.OnCalendar += ShowCalendar;
        _input.OnMap += ShowMap;
    }

    private void CloseAll()
    {
        foreach (var screen in _screens)
        {
            screen.Hide();
        }
    }

    private void ShowInventory()
    {
        CloseAll();
        _inventory.Show();
    }

    private void ShowCalendar()
    {
        CloseAll();
        _calendar.Show();
    }

    private void ShowMap()
    {
        CloseAll();
        _map.Show();
    }

    public void Dispose()
    {
        _input.OnInventory += ShowInventory;
        _input.OnCalendar += ShowCalendar;
        _input.OnMap += ShowMap;
    }
}
}