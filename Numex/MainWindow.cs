using System.Windows;
using Numex.Utilities.Services;
using Numex.Utilities.User_Controls;

namespace Numex;

public partial class MainWindow {
  private readonly FaqViewer _newtonFaqViewer = new(new Uri(@"file:///C:\Users\Monti XD\Desktop\Numex\Numex\FaQs\newtonFaq.pdf"));
  private readonly FaqViewer _dichotomyFaqViewer = new(new Uri(@"file:///C:\Users\Monti XD\Desktop\Numex\Numex\FaQs\dichotomyFaq.pdf"));
  
  private enum MenuItems {
    Dichotomy,
    Newton,
  }

  private readonly Dictionary<MenuItems, Visibility> _menuItemsState = new() {
    { MenuItems.Dichotomy, Visibility.Collapsed },
    { MenuItems.Newton, Visibility.Collapsed }
  };

  private void DisplayItem(MenuItems menuItem) {
    foreach (var item in _menuItemsState.Keys.ToList()) {
      _menuItemsState[item] = Visibility.Collapsed;
    }

    _menuItemsState[menuItem] = Visibility.Visible;
    UpdateMenuItems();
  }

  private void UpdateMenuItems() {
    DichotomyMenuItem.Visibility = _menuItemsState[MenuItems.Dichotomy];
    NewtonMenuItem.Visibility = _menuItemsState[MenuItems.Newton];
  }
}