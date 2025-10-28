using System.Windows;
using Flee.PublicTypes;

namespace Numex.Utilities.Services;

public class PlotPointsArrayGenerator {
  private readonly ExpressionContext _context = new();
  private readonly double _startX, _endX, _step;
  private readonly string _formula;

  public enum Axis {
    X,
    Y
  }

  public PlotPointsArrayGenerator(double startX, double endX, double step, string formula) {
    _context.Options.StringComparison = StringComparison.OrdinalIgnoreCase;
    _context.Imports.AddType(typeof(Math));
    _startX = startX;
    _endX = endX;
    _step = step;
    _formula = formula;
  }
 
  private double[] GetYPoints() {
    List<double> pointsY = [];
    var xPoints = GetXPoints();

    if (!InputValidator.IsValidFormula(xPoints[0], _formula, _context)) {
      MessageBox.Show("Неверное значение уравнения");
      return pointsY.ToArray();
    }

    foreach (var x in xPoints) {
      _context.Variables["x"] = x;
      var expr = _context.CompileGeneric<double>(_formula);
      pointsY.Add(expr.Evaluate());
    }

    return pointsY.ToArray();
  }

  private double[] GetXPoints() {
    List<double> pointsX = [];
    int steps = (int)((_endX - _startX) / _step);
    for (int i = 0; i <= steps; i++) pointsX.Add(Math.Round(_startX + i * _step, 2));

    return pointsX.ToArray();
  }

  public double[] GetPoints(Axis axis) {
    return axis switch {
      Axis.X => GetXPoints(),
      Axis.Y => GetYPoints(),
      _ => throw new ArgumentOutOfRangeException(nameof(axis))
    };
  }
}