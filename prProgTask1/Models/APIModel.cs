using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace prProgTask1.Models
{
    public class APIModel
    {
        public static async void LoadUsers()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://wordapidata.000webhostapp.com/?getuserdb";
                HttpResponseMessage message = client.GetAsync(url).Result;
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    List<UserDTO> users = JsonConvert.DeserializeObject<List<UserDTO>>(json);
                    UserDTO.InsertUsers(users);
                }
            }
        }
        public static async Task<List<string>> GetWords(string Request)
        {
            List<string> words= new List<string>();
            string result = "";
            switch (Request)
            {
                case "Eng":
                    result = "getnamesenglish";
                    break;
                case "Afr":
                    result = "getnamesafrikaans";
                    break;
                case "Xho":
                    result = "getnamesxhosa";
                    break;
                default:
                    result = "getnamesenglish";
                    break;
            }
            using (HttpClient client = new HttpClient())
            {
                string url = "https://wordapidata.000webhostapp.com/?" + result;
                HttpResponseMessage message = client.GetAsync(url).Result;
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    words = JsonConvert.DeserializeObject<List<string>>(json);
                }
                else
                    words = null;
            }
            return words;
        }
    }
}
