using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DataAccess
{
    public class DataAccessService
    {
        private readonly string baseUrl;

        public DataAccessService(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public async Task<List<Participant>> GetAllParticipants()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Participant");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Participant> participants = JsonConvert.DeserializeObject<List<Participant>>(json);
                    return participants;
                }

                return null;
            }
        }

        public async Task<List<Participant>> GetParticipantsByName(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"api/Participant/{name}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Participant> participants = JsonConvert.DeserializeObject<List<Participant>>(json);
                    return participants;
                }

                return null;
            }
        }

        public async Task DeleteParticipant(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"api/Participant/{id}");

                response.EnsureSuccessStatusCode();
            }
        }

        public async Task UpdateParticipant(int id, string name, string gemStone)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var participant = new Participant { ID = id, Name = name, GemStone = gemStone };
                string json = JsonConvert.SerializeObject(participant);
                HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"api/Participant/{id}", content);

                response.EnsureSuccessStatusCode();
            }
        }

        public async Task AddParticipant(Participant participant)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(participant);
                HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/Participant", content);

                response.EnsureSuccessStatusCode();
            }
        }
    }
}