using System.Windows;
using NumexControls.controls;

namespace Numex;

public partial class MainWindow {
  private readonly FaqViewer _newtonFaqViewer = new(new Uri(@"file:///C:\Users\Monti XD\Desktop\Numex\Numex\Resources\FaQs\newtonFaq.pdf"));
  private readonly FaqViewer _dichotomyFaqViewer = new(new Uri(@"file:///C:\Users\Monti XD\Desktop\Numex\Numex\Resources\FaQs\dichotomyFaq.pdf"));
  private readonly FaqViewer _goldenRatioFaqViewer =
    new(new Uri(@"file:///C:\Users\Monti XD\Desktop\Numex\Numex\Resources\FaQs\goldenRatioFaq.pdf"));
  
  private enum MenuItems {
    Dichotomy,
    Newton,
    GoldenRatio,
  }

  private readonly Dictionary<MenuItems, Visibility> _menuItemsState = new() {
    { MenuItems.Dichotomy, Visibility.Collapsed },
    { MenuItems.Newton, Visibility.Collapsed },
    { MenuItems.GoldenRatio, Visibility.Collapsed}
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
    GoldenRatioMenuItem.Visibility = _menuItemsState[MenuItems.GoldenRatio];
  }
}