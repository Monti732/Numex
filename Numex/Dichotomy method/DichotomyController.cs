using Numex.Utilities.Base;
using Numex.Utilities.Services;

namespace Numex.Dichotomy_method;

public class DichotomyController : Controller {
  public async Task<string?> Calculate(double a, double b, double e, string formula, int precision) {
    var solver = new DichotomySolver(a, b, e,formula);
    var result = await solver.Solve();
    return ResultFormatter.FormatResult(result, precision);
  }
}