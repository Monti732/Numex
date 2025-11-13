using System.Windows;
using Numex.Utilities.Base;
using Numex.Utilities.Services;

namespace Numex.Golden_Ratio_Method;

public class GoldenRatioSolver(double a, double b, double epsilon, string formula, bool findMax, int precision)
  : Solver(epsilon, formula) {
  private const double _phi = 1.6180339887498948482;

  public override async Task<string> Solve() {
    if (!InputValidator.IsValidFormula(a, Formula, Context)) {
      MessageBox.Show("Неверное значение уравнения");
      return "";
    }

    var result = 0.0;

    while (Math.Abs(b - a) > Epsilon) {
      var x1 = b - (b - a) / _phi;
      var x2 = a + (b - a) / _phi;

      var fx1 = Evaluate(x1);
      var fx2 = Evaluate(x2);

      if (findMax) {
        if (fx1 < fx2)
          b = x2;
        else
          a = x1;
      }
      else {
        if (fx1 > fx2)
          b = x2;
        else
          a = x1;
      }

      result = (a + b) / 2.0;
    }

    if (double.IsNaN(result))
      return "Корней нет";

    var y = Evaluate(result);

    var formatResult = ResultFormatter.FormatResult(result.ToString(), precision);
    var formatY = ResultFormatter.FormatResult(y.ToString(), precision);
    
    return $"({formatResult}, {formatY})";
  }
}