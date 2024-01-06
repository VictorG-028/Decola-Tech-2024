using learning_CSharp_ui.components;

namespace learning_CSharp_ui.Models
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

    public void AddVehicle(string plate)
    {
      vehicles.Add(plate);
    }

    public void RemoveVehicle(string plate, int hours)
    {
      // Verifica se o veículo existe
      if (vehicles.Any(
        x => x.Equals(plate, StringComparison.CurrentCultureIgnoreCase)
      ))
      {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

        decimal valorTotal = initialPrice + pricePerHour * hours;

        vehicles.Remove(plate);

        // TODO usar o popup component aqui
        Popup p = new([
          $"{valorTotal:c} = {initialPrice:c} + {pricePerHour:c} * {hours}",
          $"O veículo {plate} foi removido e o preço total foi de: {valorTotal:c}"
        ]);
        p.ShowDialog();
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
        Popup p = new([.. vehicles]);
        p.ShowDialog();
      }
    }
  }
}
