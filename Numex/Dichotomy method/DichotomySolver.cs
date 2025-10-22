using System.Windows;
using Flee.PublicTypes;
using Numex.Utilities;

namespace Numex.Dichotomy_method;

public class DichotomySolver {
  private readonly ExpressionContext _context = new ExpressionContext();

  public DichotomySolver() {
    _context.Options.StringComparison = StringComparison.OrdinalIgnoreCase;
    _context.Imports.AddType(typeof(Math));
  }

  private double Evaluate(double x, string formula) {
    _context.Variables["x"] = x;
    var expr = _context.CompileGeneric<double>(formula);
    return expr.Evaluate();
  }

  public string Solve(double a, double b, double e, string formula) {
    if (!InputValidator.IsValidFormula(a, formula, _context)) {
      MessageBox.Show("Неверное значение уравнения");
      return "0";
    }
    
    double fa = Evaluate(a, formula);
    double fb = Evaluate(b, formula);

    if (fa * fb > 0)
      return "Нет корней на промежутке [a,b] или их больше одного";

    double c = 0;
    while (Math.Abs(fb - fa) > e) {
      c = (a + b) / 2.0;
      double fc = Evaluate(c, formula);

      if (fa * fc < 0) {
        b = c;
        fb = fc;
      }
      else {
        a = c;
        fa = fc;
      }
    }

    return c.ToString();
  }
}