using Numex.Utilities.Services;

namespace Numex.Utilities.Base;

public abstract class Controller {
  public async Task<(double[] xPoints, double[] yPoints)> GeneratePlotPoints(double x1, double x2, double step, string formula) {
    var points = new PlotPointsArrayGenerator(x1, x2, step, formula);
    return (points.GetPoints(PlotPointsArrayGenerator.Axis.X), points.GetPoints(PlotPointsArrayGenerator.Axis.Y));
  }
}