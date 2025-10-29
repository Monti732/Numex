using System.Windows;
using System.Windows.Controls;
using Numex.Utilities.Services;

namespace Numex.Golden_Ratio_Method;

public partial class GoldenRatioControl : UserControl {
  private readonly GoldenRatioController _controller = new();
  private readonly Style? _errorStyle = Application.Current.FindResource("TextBoxErrorStyle") as Style;
  private readonly Style? _defaultStyle = Application.Current.FindResource("DefaultTextBoxStyle") as Style;
  
  public GoldenRatioControl() {
    InitializeComponent();
  }
  
  public async void CalculateRoot() {
    var a = RangeParameters.TextBoxA.Text;
    var b = RangeParameters.TextBoxB.Text;
    var e = ErrorValue.TextBox.Text;
    var precision = DecimalPrecision.TextBox.Text;
    var formula = FunctionInput.TextBox.Text;
    var findMax = FindMax.SelectedIndex == 1 ? true : false;

    RangeParameters.TextBoxA.Style = _defaultStyle;
    RangeParameters.TextBoxB.Style = _defaultStyle;
    ErrorValue.TextBox.Style = _defaultStyle;
    DecimalPrecision.TextBox.Style = _defaultStyle;

    var hasError = false;

    if (!InputValidator.TryParseDouble(a, out var valueA)) {
      RangeParameters.TextBoxA.Style = _errorStyle;
      hasError = true;
    }

    if (!InputValidator.TryParseDouble(b, out var valueB)) {
      RangeParameters.TextBoxB.Style = _errorStyle;
      hasError = true;
    }

    if (!InputValidator.ValidateErrorValue(e)) {
      ErrorValue.TextBox.Style = _errorStyle;
      hasError = true;
    }

    if (!InputValidator.TryParseInt(precision, out var precisionValue)) {
      DecimalPrecision.TextBox.Style = _errorStyle;
      hasError = true;
    }

    if (hasError) return;

    InputValidator.TryParseDouble(e, out var eValue);

    try {
      Output.TextBlock.Text = "";
      Output.Gif.Visibility = Visibility.Visible;
      var result = await Task.Run(() => _controller.Calculate(valueA, valueB, eValue, formula, findMax, precisionValue));
      Output.Gif.Visibility = Visibility.Collapsed;
      Output.TextBlock.Text = result;
    }
    catch (Exception ex) {
      MessageBox.Show($"{ex.Message}", "Error");
    }
  }

  public void Reset() {
    RangeParameters.TextBoxB.Text = "";
    RangeParameters.TextBoxA.Text = "";
    FunctionInput.TextBox.Text = "";
    ErrorValue.TextBox.Text = "";
    DecimalPrecision.TextBox.Text = "";
    Output.TextBlock.Text = "";
  }
}