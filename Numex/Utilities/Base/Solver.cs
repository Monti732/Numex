using Flee.PublicTypes;

namespace Numex.Utilities.Base;

public abstract class Solver {
  protected readonly ExpressionContext Context = new();
  protected readonly double Epsilon;
  protected readonly string Formula;

  protected Solver(double epsilon, string formula) {
    Epsilon = epsilon;
    Formula = formula;
    Context.Options.StringComparison = StringComparison.OrdinalIgnoreCase;
    Context.Imports.AddType(typeof(Math));
  }

  protected double Evaluate(double x) {
    Context.Variables["x"] = x;
    var expr = Context.CompileGeneric<double>(Formula);
    return expr.Evaluate();
  }

  public abstract Task<string> Solve();
}