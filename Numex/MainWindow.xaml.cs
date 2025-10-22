using System.Windows;
using Numex.Dichotomy_method;

namespace Numex;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
  public MainWindow() {
    InitializeComponent();
  }

  private void DichotomyMethod_Click(object sender, RoutedEventArgs e) {
    MainContent.Content = new DichotomyMethodControl();
  }
}