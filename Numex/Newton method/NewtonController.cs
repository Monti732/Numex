using Numex.Utilities.Base;
using Numex.Utilities.Services;

namespace Numex.Newton_method;

public class NewtonController : Controller {
  public async Task<string?> Calculate(double x, double e, double h, string formula, int precision) {
    var solver = new NewtonSolver(x, e, h, formula);
    var result = await solver.Solve();
    return ResultFormatter.FormatResult(result, precision);
  }
}