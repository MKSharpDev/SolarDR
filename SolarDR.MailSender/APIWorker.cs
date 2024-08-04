
using Newtonsoft.Json;

namespace SolarDR.MailSender
{
    public class APIWorker
    {
        private readonly string _apiAdress;
        public APIWorker(string apiAdress) 
        {
            _apiAdress = apiAdress;
        }


        public async Task<ICollection<PersonForEmail>> GetPersonsAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(_apiAdress);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var personResponse = JsonConvert.DeserializeObject<ICollection<PersonForEmail>>(responseContent);
                 
                    return personResponse;
                    
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return null;
        }

    }
}
