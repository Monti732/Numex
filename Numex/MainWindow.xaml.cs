using System.Windows;
using Numex.Dichotomy_method;
using Numex.Golden_Ratio_Method;
using Numex.Newton_method;

namespace Numex;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
  private readonly DichotomyMethodControl _dichotomyMethodControl = new();
  private readonly NewtonMethodControl _newtonMethodControl = new();
  private readonly GoldenRatioControl _goldenRatioControl = new();

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
  
  private void GoldenRatioShow(object sender, RoutedEventArgs e) {
    MainContent.Content = _goldenRatioControl;
    DisplayItem(MenuItems.GoldenRatio);
  }
  
  private void GoldenRatioCalculate(object sender, RoutedEventArgs e) => _goldenRatioControl.CalculateRoot();
  
  private void GoldenRatioReset(object sender, RoutedEventArgs e) => _goldenRatioControl.Reset();
  
  private void GoldenRatioFaq(object sender, RoutedEventArgs e) => _goldenRatioFaqViewer.ShowDialog();
}