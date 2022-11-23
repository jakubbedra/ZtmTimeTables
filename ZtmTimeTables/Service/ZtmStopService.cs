using System.Net;
using ZtmTimeTables.Entity;
using JsonSerializer = System.Text.Json.JsonSerializer;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace ZtmTimeTables.Service;

public class ZtmStopService
{
    private static HttpClient _client;

    public ZtmStopService()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
        {
            return true;
        };

        _client = new HttpClient(clientHandler);
    }

    public async Task<ZtmArrivalsCollection> FindArrivalsByStopId(int id)
    {
        HttpResponseMessage message = await _client.GetAsync(
            $"http://ckan2.multimediagdansk.pl/delays?stopId={id}");
        message.EnsureSuccessStatusCode();
        string body = await message.Content.ReadAsStringAsync();
        ZtmArrivalsCollection deserialized = JsonSerializer.Deserialize<ZtmArrivalsCollection>(
            body,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        return deserialized;
    }

    public async Task<int> WriteAllToFile()
    {
        // HttpResponseMessage message = await _client.GetAsync(
        //     "https://ckan.multimediagdansk.pl/dataset/c24aa637-3619-4dc2-a171-a23eec8f2172/resource/4c4025f0-01bf-41f7-a39f-d156d201b82b/download/stops.json");
        var json = new WebClient().DownloadString(
            "https://ckan.multimediagdansk.pl/dataset/c24aa637-3619-4dc2-a171-a23eec8f2172/resource/4c4025f0-01bf-41f7-a39f-d156d201b82b/download/stops.json");
        //message.EnsureSuccessStatusCode();
        //string body = await message.Content.ReadAsStringAsync();
        Dictionary<DateOnly, ZtmStopCollection>? deserialized =
            JsonSerializer.Deserialize<Dictionary<DateOnly, ZtmStopCollection>>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        if (!File.Exists(@"./Cache/stops.json"))
        {
            File.Create(@"./Cache/stops.json");
        }

        File.WriteAllText(@"./Cache/stops.json", json);
        return 1;
    }

    public Dictionary<DateOnly, ZtmStopCollection> FindAll()
    {
        string json = File.ReadAllText(@"./Cache/stops.json");
        return JsonSerializer.Deserialize<Dictionary<DateOnly, ZtmStopCollection>>(
            json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
    }

    public ZtmStop? FindById(int stopId)
    {
        try
        {
            string json = File.ReadAllText(@"./Cache/stops.json");


            Dictionary<DateOnly, ZtmStopCollection>? deserialized =
                JsonSerializer.Deserialize<Dictionary<DateOnly, ZtmStopCollection>>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            List<ZtmStop> stops = deserialized.First().Value.Stops;

            return stops.Where(s => s.StopId == stopId).FirstOrDefault();
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}