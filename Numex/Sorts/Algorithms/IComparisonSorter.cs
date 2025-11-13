namespace Numex.Sorts.Algorithms;

public interface IComparisonSorter<T> {
  /// <summary>
  ///     Sorts array in ascending order.
  /// </summary>
  /// <param name="array">Array to sort.</param>
  /// <param name="comparer">Comparer to compare items of <paramref name="array" />.</param>
  void Sort(T[] array, IComparer<T> comparer);
}