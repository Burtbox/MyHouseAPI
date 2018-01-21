namespace MyHouseIntegrationTests.Models
{
    public class GetResponse<T>
    {
        public T Value { get; set; }
        public string[] Formatters { get; set; }
        public string[] ContentTypes { get; set; }
        public string DeclaredType { get; set; }
        public int StatusCode { get; set; }
    }

    public class PostResponse<T> : GetResponse<T>
    {
        public string Location { get; set; }
    }
}