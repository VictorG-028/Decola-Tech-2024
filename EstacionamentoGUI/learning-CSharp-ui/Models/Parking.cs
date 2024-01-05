namespace DesafioFundamentos.Models
{
  public class Parking
  {
    private readonly decimal initialPrice = 0;
    private readonly decimal pricePerHour = 0;
    private readonly List<string> vehicles = [];

    public Parking(decimal initialPrice, decimal pricePerHour)
    {
      this.initialPrice = initialPrice;
      this.pricePerHour = pricePerHour;
    }

    public void AddVehicle()
    {
      Console.WriteLine("Digite a placa do veículo para estacionar:");
      vehicles.Add(Utils.ReadNonNullString());
    }

    public void RemoveVehicle()
    {
      Console.WriteLine("Digite a placa do veículo para remover:");


      string placa = Utils.ReadNonNullString();

      // Verifica se o veículo existe
      if (vehicles.Any(
        x => x.Equals(placa, StringComparison.CurrentCultureIgnoreCase)
      ))
      {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

        int horas = 0;
        while (!int.TryParse(Console.ReadLine(), out horas)) { };
        decimal valorTotal = initialPrice + pricePerHour * horas;

        vehicles.Remove(placa);

        Console.WriteLine($"{valorTotal:c} = {initialPrice:c} + {pricePerHour:c} * {horas}");
        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal:c}");
      }
      else
      {
        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
      }
    }

    public void ListVehicles()
    {
      if (vehicles.Count != 0) // Verifica se há veículos no estacionamento
      {
        Console.WriteLine("Os veículos estacionados são:");
        foreach (string v in vehicles)
        {
          Console.WriteLine(v);
        }
      }
      else
      {
        Console.WriteLine("Não há veículos estacionados.");
      }
    }
  }
}
