using FluentBuilder.Url;

namespace FluentBuilder.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            // http(s)://www.travel.eu/countries/romania?city=iasi
            var url = UrlBuilder.Http("www.travel.eu")
                .WithSegment("countries")
                .WithSegment("romania")
                .WithQueryString(q => q.HavingKey("city").WithValue("iasi"))
                .WithQueryString(q => q.HavingKey("hotel").WithValue("ramada"))
                .ToUrl();

            Console.WriteLine(url);
        }

    }
}
