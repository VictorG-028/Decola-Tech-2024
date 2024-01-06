using DesafioPOO.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json; // https://www.nuget.org/packages/Newtonsoft.Json/
// using System.Text.Json;

namespace DesafioPOO
{

  public class Result
  {
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("difficulty")]
    public string Difficulty { get; set; }

    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("question")]
    public string Question { get; set; }

    [JsonProperty("correct_answer")]
    public string CorrectAnswer { get; set; }

    [JsonProperty("incorrect_answers")]
    public List<string> IncorrectAnswers { get; set; }
  }

  public class ResponseObject
  {
    [JsonProperty("response_code")]
    public int ResponseCode { get; set; }

    [JsonProperty("results")]
    public List<Result> Results { get; set; }
  }


  class Program
  {

    private static List<string> retrievedNames = new List<string>();

    static void Main()
    {
      Console.WriteLine("Consumindo API (demora 11segundos para fazer 2 requisições)\n");
      GetRequestToRetrieveNames().Wait();

      // Instanciando 2 celulares
      Nokia n = new Nokia("123456789", "Nokia Model", "NokiaIMEI", 64);
      Iphone i = new Iphone("987654321", "iPhone Model", "iPhoneIMEI", 64);
      List<Smartphone> phones = new List<Smartphone> { n, i };

      var zippedList = retrievedNames.Zip(phones, (name, phone) => new { Name = name, Phone = phone });
      foreach (var item in zippedList)
      {
        // Testando os métodos
        Console.WriteLine("=----= + =----=");
        Console.WriteLine($"Número: {item.Phone.Number}");
        item.Phone.Call();
        item.Phone.ReceiveCall();
        item.Phone.InstallApp(item.Name);
      }
      Console.WriteLine("=----= + =----=");
    }

    static async Task GetRequestToRetrieveNames()
    {
      // Faz chamada para uma API para pegar strings usada como se fossem nome de aplicativo
      int[] categories = { 20, 21 };
      foreach (int category in categories)
      {
        string apiUrl = $"https://opentdb.com/api.php?amount=1&category={category}"; // Categoria de jogos
        using (HttpClient client = new HttpClient())
        {
          HttpResponseMessage response = await client.GetAsync(apiUrl);

          if (response.IsSuccessStatusCode)
          {
            // var teste = response.Content.ReadAsStringAsync<IEnumerable<DataObject>>().Result;
            // Console.WriteLine(teste);
            string jsonResult = await response.Content.ReadAsStringAsync();

            // Corrigindo o acesso ao valor correto no JSON
            // ResponseObject mockAppName = JsonSerializer.Deserialize<ResponseObject>(jsonResult);
            ResponseObject parsedJson = JsonConvert.DeserializeObject<ResponseObject>(jsonResult);
            string mockAppName = parsedJson.Results[0].Category;
            retrievedNames.Add(mockAppName);
            // break;
          }
          else
          {
            Console.WriteLine($"Erro na solicitação: {response.StatusCode}");
          }
          await Task.Delay(10500); // Espera 10,5 segundos antes de próxima requisição
        }
      }
    } // Fim da função assíncrona
  }
}
