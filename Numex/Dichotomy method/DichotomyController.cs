using Numex.Utilities;

namespace Numex.Dichotomy_method;

public class DichotomyController {
  private readonly DichotomySolver _solver = new();

  public string CalculateRoot(double a, double b, double e, string formula, int precision) {
    var result = _solver.Solve(a, b, e, formula);
    return ResultFormatter.FormatResult(result, precision);
  }

  public (double[] xPoints, double[] yPoints) GeneratePlotPoints(double x1, double x2, double step, string formula) {
    var points = new PlotPointsArrayGenerator(x1, x2, step, formula);
    return (points.GetPoints(PlotPointsArrayGenerator.Axis.X), points.GetPoints(PlotPointsArrayGenerator.Axis.Y));
  }
}