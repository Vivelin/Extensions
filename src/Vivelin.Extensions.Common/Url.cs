using System.Globalization;
using System.Text;

namespace Vivelin.Extensions.Common;

public class Url
{
    public Url(string scheme, string? host, int? port, string path,
        IEnumerable<KeyValuePair<string, object>>? query, string? fragment)
    {
        Scheme = scheme;
        Host = host;
        Port = port;
        Path = path;
        Query = query ?? Enumerable.Empty<KeyValuePair<string, object>>();
        Fragment = fragment;
    }

    public string Scheme { get; }

    public string? Host { get; }

    public int? Port { get; }

    public string Path { get; }

    public IEnumerable<KeyValuePair<string, object>> Query { get; }

    public string? Fragment { get; }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append(Scheme);
        builder.Append(':');
        if (!string.IsNullOrEmpty(Host))
        {
            builder.Append("//");
            builder.Append(Host);
            if (Port != null)
            {
                builder.Append(':');
                builder.Append(Port.Value.ToString("0"));
            }
        }
        builder.Append(Path);
        if (Query.Any())
        {
            builder.Append('?');
            var queryString = Query
                .Select(x => FormatKeyValuePair(x))
                .Join('&');
            builder.Append(queryString);
        }
        if (!string.IsNullOrEmpty(Fragment))
        {
            builder.Append('#');
            builder.Append(Fragment);
        }
        return builder.ToString();
    }

    private static string FormatKeyValuePair(KeyValuePair<string, object> element)
    {
        var valueString = Convert.ToString(element.Value, CultureInfo.InvariantCulture) ?? "";
        var key = Uri.EscapeDataString(element.Key);
        var value = Uri.EscapeDataString(valueString);
        return $"{key}={value}";
    }
}
