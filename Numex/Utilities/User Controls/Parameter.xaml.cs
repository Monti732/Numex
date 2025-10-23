using System.Windows;
using System.Windows.Controls;

namespace Numex.Utilities.User_Controls;

public partial class Parameter : UserControl {
  public Parameter() {
    InitializeComponent();
  }

  public static readonly DependencyProperty LabelProperty =
    DependencyProperty.Register(nameof(Label), typeof(string), typeof(Parameter),
      new PropertyMetadata(string.Empty));

  public string Label {
    get => (string)GetValue(LabelProperty);
    set => SetValue(LabelProperty, value);
  }
}