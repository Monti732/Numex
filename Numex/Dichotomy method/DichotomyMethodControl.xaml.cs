using System.Windows;
using System.Windows.Controls;
using Numex.Utilities;

namespace Numex.Dichotomy_method;

public partial class DichotomyMethodControl : UserControl {
  private readonly DichotomyController _controller = new();

  public DichotomyMethodControl() {
    InitializeComponent();
  }

  private void BuildPlot(object sender, EventArgs e) {
    double x1 = -5, x2 = 5, step = 0.01;
    var errorStyle = (Style)FindResource("TextBoxErrorStyle");
    var isCustomRangeEnable = CustomPlotRenderPanel.InputSectionPanel.IsVisible;

    if (isCustomRangeEnable) {
      if (!double.TryParse(CustomPlotRenderPanel.X1TextBox.Text, out x1))
        CustomPlotRenderPanel.X1TextBox.Style = errorStyle;


      if (!double.TryParse(CustomPlotRenderPanel.X2TextBox.Text, out x2))
        CustomPlotRenderPanel.X2TextBox.Style = errorStyle;

      if (!double.TryParse(CustomPlotRenderPanel.StepTextBox.Text, out step))
        CustomPlotRenderPanel.StepTextBox.Style = errorStyle;
    }

    var (xPoints, yPoints) = _controller.GeneratePlotPoints(x1, x2, step, FormulaTextBox.Text);
    PlotArea.Plot.Clear();
    PlotArea.Plot.Add.Scatter(xPoints, yPoints);
    PlotArea.Refresh();
  }

  private void CalculateRoot(object sender, EventArgs eventArgs) {
    var a = ValueATextBox.Text;
    var b = ValueBTextBox.Text;
    var e = ErrorValue.Text;
    var precision = DecimalPrecisionTextBox.Text;

    var errorStyle = (Style)FindResource("TextBoxErrorStyle");
    var defaultStyle = (Style)FindResource("DefaultTextBoxStyle");

    ValueATextBox.Style = defaultStyle;
    ValueBTextBox.Style = defaultStyle;
    ErrorValue.Style = defaultStyle;
    DecimalPrecisionTextBox.Style = defaultStyle;

    if (!InputValidator.TryParseDouble(a, out var valueA))
      ValueATextBox.Style = errorStyle;

    if (!InputValidator.TryParseDouble(b, out var valueB))
      ValueBTextBox.Style = errorStyle;

    if (!InputValidator.TryParseDouble(e, out var valueE))
      ErrorValue.Style = errorStyle;

    if (!InputValidator.TryParseInt(precision, out var precisionValue))
      DecimalPrecisionTextBox.Style = errorStyle;

    OutPutTextBlock.Text = _controller.CalculateRoot(valueA, valueB, valueE, FormulaTextBox.Text, precisionValue);
  }
}