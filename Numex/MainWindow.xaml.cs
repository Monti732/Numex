using System.Windows;
using Numex.Dichotomy_method;
using Numex.Newton_method;

namespace Numex;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
  private readonly DichotomyMethodControl _dichotomyMethodControl = new();
  private readonly NewtonMethodControl _newtonMethodControl = new();

  public MainWindow() {
    InitializeComponent();
  }

  private void DichotomyShow(object sender, RoutedEventArgs e) {
    MainContent.Content = _dichotomyMethodControl;
    DichotomyMenuItem.Visibility = Visibility.Visible;
  }
  
  private void DichotomyCalculate(object sender, RoutedEventArgs e) =>
    _dichotomyMethodControl.CalculateRoot();

  private void DichotomyBuildPlot(object sender, RoutedEventArgs e) =>
    _dichotomyMethodControl.BuildPlot();

  private void DichotomyReset(object sender, RoutedEventArgs e) =>
    _dichotomyMethodControl.Reset();
  
  private void NewtonShow(object sender, RoutedEventArgs e) {
    MainContent.Content = _newtonMethodControl;
    NewtonMenuItem.Visibility = Visibility.Visible;
  }

  private void NewtonCalculate(object sender, RoutedEventArgs e) => _newtonMethodControl.CalculateRoot();

  private void NewtonBuildPlot(object sender, RoutedEventArgs e) => _newtonMethodControl.BuildPlot();
  
  private void NewtonReset(object sender, RoutedEventArgs e) => _newtonMethodControl.Reset();
}