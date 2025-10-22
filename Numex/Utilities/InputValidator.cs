using System.Globalization;
using System.Text.RegularExpressions;
using Flee.PublicTypes;

namespace Numex.Utilities;

public static class InputValidator {
  private static readonly NumberFormatInfo NumberFormat = CultureInfo.InvariantCulture.NumberFormat;

  public static bool IsValidFormula(double x, string formula, ExpressionContext context) {
    try {
      context.Variables["x"] = x;
      var expr = context.CompileGeneric<double>(formula);
      expr.Evaluate();
      return true;
    }
    catch {
      return false;
    }
  }

  public static bool TryParseDouble(string input, out double value) {
    return double.TryParse(input, NumberFormat, out value);
  }

  public static bool ValidateErrorValue(string input) {
    var regex = new Regex(@"^0(.|,)0*1$");
    return regex.IsMatch(input) || input == "1";
  }

  public static bool TryParseInt(string input, out int value) {
    return int.TryParse(input, out value);
  }
}