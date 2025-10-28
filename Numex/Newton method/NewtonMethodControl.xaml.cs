using System.Windows;
using System.Windows.Controls;
using Numex.Utilities.Services;

namespace Numex.Newton_method;

public partial class NewtonMethodControl : UserControl {
  private readonly NewtonController _controller = new();
  private readonly Style? _errorStyle = Application.Current.FindResource("TextBoxErrorStyle") as Style;
  private readonly Style? _defaultStyle = Application.Current.FindResource("DefaultTextBoxStyle") as Style;

  public NewtonMethodControl() {
    InitializeComponent();
  }
  
  public async void CalculateRoot() {
    var e = ErrorValue.TextBox.Text;
    var formula = FunctionInput.TextBox.Text;
    var precision = DecimalPrecision.TextBox.Text;
    var x = ParameterX.TextBox.Text;
    var h = ParameterH.TextBox.Text;

    ErrorValue.TextBox.Style = _defaultStyle;
    DecimalPrecision.TextBox.Style = _defaultStyle;
    ParameterX.TextBox.Style = _defaultStyle;

    var hasError = false;

    if (!InputValidator.TryParseDouble(x, out var valueX)) {
      ParameterX.TextBox.Style = _errorStyle;
      hasError = true;
    }

    if (!InputValidator.TryParseDouble(h, out var valueH)) {
      ParameterH.TextBox.Style = _errorStyle;
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

    InputValidator.TryParseDouble(e, out var valueE);

    try {
      Output.TextBlock.Text = "";
      Output.Gif.Visibility = Visibility.Visible;
      var result = await Task.Run(() => _controller.Calculate(valueX, valueE, valueH, formula, precisionValue));
      Output.Gif.Visibility = Visibility.Collapsed;
      Output.TextBlock.Text = result;
    }
    catch (Exception ex) {
      MessageBox.Show($"{ex.Message}", "Error");
    }
  }

  public void Reset() {
    FunctionInput.TextBox.Text = "";
    ParameterX.TextBox.Text = "";
    ParameterH.TextBox.Text = "";
    ErrorValue.TextBox.Text = "";
    DecimalPrecision.TextBox.Text = "";
  }
}