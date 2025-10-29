using Numex.Utilities.Base;
using Numex.Utilities.Services;

namespace Numex.Golden_Ratio_Method;

public class GoldenRatioController : Controller {
  public async Task<string?> Calculate(double a, double b, double e, string formula, bool findMax, int precision) {
    var solver = new GoldenRatioSolver(a, b, e, formula, findMax, precision);
    var result = await solver.Solve();
    return result;
  }
}