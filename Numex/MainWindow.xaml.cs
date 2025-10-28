using System.Windows;
using Numex.Dichotomy_method;
using Numex.Newton_method;

namespace Numex;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
  private readonly DichotomyMethodControl _dichotomyMethodControl = new();
  private readonly NewtonMethodControl _newtonMethodControl = new();

  public MainWindow() {
    InitializeComponent();
  }

  private void DichotomyShow(object sender, RoutedEventArgs e) {
    MainContent.Content = _dichotomyMethodControl;
    DisplayItem(MenuItems.Dichotomy);
  }

  private void DichotomyCalculate(object sender, RoutedEventArgs e) => _dichotomyMethodControl.CalculateRoot();

  private void DichotomyReset(object sender, RoutedEventArgs e) =>
    _dichotomyMethodControl.Reset();

  private void DichotomyFaq(object sender, RoutedEventArgs e) => _dichotomyFaqViewer.ShowDialog();

  private void NewtonShow(object sender, RoutedEventArgs e) {
    MainContent.Content = _newtonMethodControl;
    DisplayItem(MenuItems.Newton);
  }

  private void NewtonCalculate(object sender, RoutedEventArgs e) => _newtonMethodControl.CalculateRoot();

  private void NewtonReset(object sender, RoutedEventArgs e) => _newtonMethodControl.Reset();

  private void NewtonFaq(object sender, RoutedEventArgs e) => _newtonFaqViewer.ShowDialog();
}