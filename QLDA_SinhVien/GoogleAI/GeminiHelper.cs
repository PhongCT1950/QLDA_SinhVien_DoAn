using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class GeminiHelper
{
    private const string ApiKey = "Your API Key";
    private const string ApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key=";

    public async Task<string> AskAI(string prompt)
    {
        using (var client = new HttpClient())
        {
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var jsonContent = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(ApiUrl + ApiKey, content);
                if (!response.IsSuccessStatusCode)
                {
                    var err = await response.Content.ReadAsStringAsync();
                    return $"Lỗi {response.StatusCode}: {err}";
                }

                var responseString = await response.Content.ReadAsStringAsync();
                var jsonResponse = JObject.Parse(responseString);

                string result = jsonResponse["candidates"][0]["content"]["parts"][0]["text"].ToString();
                return result;
            }
            catch (Exception ex)
            {
                return "Lỗi kết nối AI + : " + ex.Message;
            }
        }
    }
}