using System.Windows;
using Numex.Utilities.Base;
using Numex.Utilities.Services;

namespace Numex.Dichotomy_method;

public class DichotomySolver(double a, double b, double epsilon, string formula) : Solver(epsilon, formula) {
  public async override Task<string> Solve() {
    if (!InputValidator.IsValidFormula(a, Formula, Context)) {
      MessageBox.Show("Неверное значение уравнения");
      return "";
    }

    var fa = Evaluate(a);
    var fb = Evaluate(b);
    var maxIter = 1 / Epsilon;

    if (fa * fb > 0)
      return "Нет корней на промежутке [a,b] или их больше одного";

    double c = 0;
    for (int i = 0; i < maxIter; i++) {
      c = (a + b) / 2.0;
      var fc = Evaluate(c);

      if (fa * fc < 0) {
        b = c;
        fb = fc;
      }
      else {
        a = c;
        fa = fc;
      }

      if (c is double.NaN) return "Корней нет";
    }

    return c.ToString();
  }
}