using System.IO;

using FluentAssertions;

namespace Vivelin.Extensions.CommonTests
{
    public class UrlTests
    {
        [Theory]
        [InlineData("https", "localhost", null, "/", "fragment",
            "https://localhost/#fragment")]
        [InlineData("https", "localhost", 8080, "/", "fragment",
            "https://localhost:8080/#fragment")]
        [InlineData("https", "localhost", 8080, "/api/test", null,
            "https://localhost:8080/api/test")]
        [InlineData("https", "localhost", 8080, "/api/test", "fragment",
            "https://localhost:8080/api/test#fragment")]
        [InlineData("data", null, null, "text/html,<script>alert('hi');</script>", null,
            "data:text/html,<script>alert('hi');</script>")]
        public void Url_ToString_FormatsUrlsCorrectly(
            string scheme, string? host, int? port, string path, string? fragment,
            string expected)
        {
            var url = new Url(scheme, host, port, path, null, fragment);

            url.ToString().Should().Be(expected);
        }

        [Fact]
        public void Url_ToString_FormatsQueryWithInvariantCultureByDefault()
        {
            var query = new KeyValuePair<string, object>[]
            {
                new("key", 1234.56)
            };
            var url = new Url("https", "localhost", 8080, "/api/test", query, null);

            url.ToString().Should().Be("https://localhost:8080/api/test?key=1234.56");
        }

        [Theory]
        [InlineData("key", "1=2", "key=1%3D2")]
        [InlineData("1=2", "value", "1%3D2=value")]
        public void Url_ToString_EncodesQueryValues(string key, string value, string expected)
        {
            var query = new KeyValuePair<string, object>[]
            {
                new(key, value)
            };
            var url = new Url("https", "localhost", 8080, "/api/test", query, null);

            url.ToString().Should().Be($"https://localhost:8080/api/test?{expected}");
        }
    }
}