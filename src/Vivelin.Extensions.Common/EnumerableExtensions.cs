namespace Vivelin.Extensions;

/// <summary>
/// Provides additional functionality for enumerable collections.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Concatenates the members of a sequence, using the specified separator
    /// between each member.
    /// </summary>
    /// <param name="source">A collection of strings to concatenate.</param>
    /// <param name="separator">The character to use as a separator.</param>
    /// <returns>
    /// A string that consists of the values in <paramref name="source"/>
    /// delimited by the <paramref name="separator"/> character, or an empty
    /// string if <paramref name="source"/> has no values.
    /// </returns>
    public static string Join(this IEnumerable<string> source, char separator)
    {
        return string.Join(separator, source);
    }

    /// <summary>
    /// Concatenates the members of a sequence, using the specified separator
    /// between each member.
    /// </summary>
    /// <param name="source">A collection of strings to concatenate.</param>
    /// <param name="separator">The string to use as a separator.</param>
    /// <returns>
    /// A string that consists of the values in <paramref name="source"/>
    /// delimited by the <paramref name="separator"/> string, or an empty string
    /// if <paramref name="source"/> has no values.
    /// </returns>
    public static string Join(this IEnumerable<string> source, string separator)
    {
        return string.Join(separator, source);
    }
}
