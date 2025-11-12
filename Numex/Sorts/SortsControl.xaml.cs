using System.Windows;
using System.Windows.Controls;
using NumexControls.controls;

namespace Numex.Sorts;

public partial class SortsControl : UserControl {
  private ArrayWindow arrayWindow = new();
  
  public SortsControl() {
    InitializeComponent();
    arrayWindow = new ArrayWindow();
  }

  private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
    try {
      arrayWindow.Show();
    }
    catch (Exception ex) {
      MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
  }
}