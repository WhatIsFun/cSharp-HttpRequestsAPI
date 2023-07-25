using System.Text.Json;

namespace cSharp_HttpRequest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<CountryInfo> response = await callAPI();
            //HttpRequests http = new HttpRequests(response);
            foreach (var country in response) 
            {
                Console.WriteLine(country);
            }

        }

        public async static Task<List<CountryInfo>> callAPI()
        {
            String api = "https://restcountries.com/v3.1/all?fields=name,capital,area";
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(api);
            List<CountryInfo> countries = new List<CountryInfo>();
            if (responseMessage.IsSuccessStatusCode)
            {
                String stringResponse = await responseMessage.Content.ReadAsStringAsync();
                JsonDocument document = JsonDocument.Parse(stringResponse);
                JsonElement root = document.RootElement;
                if (root.ValueKind == JsonValueKind.Array)
                {
                    var enumrator = root.EnumerateArray;
                    foreach (JsonElement country in root.EnumerateArray())
                    {
                        String capital = "";
                        if (country.GetProperty("capital").GetArrayLength() > 0)
                        {
                            capital = country.GetProperty("capital")[0].GetString();
                        }
                        Double area = country.GetProperty("area").GetDouble();
                        String officialName = country.GetProperty("name").GetProperty("official").GetString();
                        countries.Add(new CountryInfo(officialName, capital, area));
                    }
                }
            }
            return countries;
        }
    }
}