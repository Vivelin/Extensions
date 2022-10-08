using FluentAssertions;

namespace Vivelin.Extensions.CommonTests
{
    public class UrlTests
    {
        [Theory]
        [InlineData("https", "localhost", 8080, "/api/test", "fragment",
            "https://localhost:8080/api/test?key=value&key2=value2#fragment")]
        public void Url_ToString_FormatsUrlsCorrectly(
            string scheme, string? host, int? port, string path, string? fragment,
            string expected)
        {
            var query = new KeyValuePair<string, object>[] {
                new("key", "value"),
                new("key2", "value2")
            };
            var url = new Url(scheme, host, port, path, query, fragment);

            url.ToString().Should().Be(expected);
        }
    }
}