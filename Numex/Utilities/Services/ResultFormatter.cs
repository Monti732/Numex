namespace Numex.Utilities.Services;

public static class ResultFormatter {
  public  static string FormatResult(string result, int decimalPlaces) {
    var indexOfComma = result.IndexOfAny([',', '.']);
    if (indexOfComma < 0) return result;

    var lengthAfterComma = result.Length - indexOfComma - 1;
    if (lengthAfterComma >= decimalPlaces)
      return result.Substring(0, indexOfComma + decimalPlaces + 1);

    var zerosToAdd = decimalPlaces - lengthAfterComma;
    return (result + new string('0', zerosToAdd));
  }
}