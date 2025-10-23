using System.Diagnostics;
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

  public async void BuildPlot() {
    CustomPlotRenderPanel.X1TextBox.Style = _defaultStyle;
    CustomPlotRenderPanel.X2TextBox.Style = _defaultStyle;
    CustomPlotRenderPanel.StepTextBox.Style = _defaultStyle;

    double x1Value = -5, x2Value = 5, stepValue = 0.01;
    var isCustomRangeEnable = CustomPlotRenderPanel.InputSectionPanel.IsVisible;

    var x1 = CustomPlotRenderPanel.X1TextBox.Text;
    var x2 = CustomPlotRenderPanel.X2TextBox.Text;
    var step = CustomPlotRenderPanel.StepTextBox.Text;
    var formula = FunctionInput.TextBox.Text;

    var hasError = false;

    if (isCustomRangeEnable) {
      if (!InputValidator.TryParseDouble(x1, out x1Value)) {
        CustomPlotRenderPanel.X1TextBox.Style = _errorStyle;
        hasError = true;
      }

      if (!InputValidator.TryParseDouble(x2, out x2Value)) {
        CustomPlotRenderPanel.X2TextBox.Style = _errorStyle;
        hasError = true;
      }

      if (!InputValidator.TryParseDouble(step, out stepValue)) {
        CustomPlotRenderPanel.StepTextBox.Style = _errorStyle;
        hasError = true;
      }
    }

    Console.WriteLine("Error");
    if (hasError) return;


    var (xPoints, yPoints) = await Task.Run(() =>
      _controller.GeneratePlotPoints(x1Value, x2Value, stepValue, formula));

    PlotArea.Plot.Clear();
    PlotArea.Plot.Add.Scatter(xPoints, yPoints);
    PlotArea.Refresh();
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
      var result = await Task.Run(() => _controller.Calculate(valueX, valueE, valueH, formula, precisionValue));
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
    CustomPlotRenderPanel.X1TextBox.Text = "";
    CustomPlotRenderPanel.X2TextBox.Text = "";
    CustomPlotRenderPanel.StepTextBox.Text = "";
  }
}