using System.Windows;
using System.Windows.Controls;

namespace Numex.Utilities.User_Controls;

public partial class CustomPlotRenderPanel : UserControl {
  public CustomPlotRenderPanel() {
    InitializeComponent();
  }
  
  private void AllowCustomRange_OnChecked(object sender, RoutedEventArgs e) =>
    InputSectionPanel.Visibility = Visibility.Visible;

  private void AllowCustomRangeCheckBox_OnUnchecked(object sender, RoutedEventArgs e) =>
    InputSectionPanel.Visibility = Visibility.Collapsed;
}