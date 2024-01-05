using Estacionamento.Models;

namespace Estacionamento.src;
static class ConsoleVersion
{
  public static void RunConsoleVersion()
  {
    // Coloca o encoding para UTF8 para exibir acentuação
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    Parking p = Parking.InitAskingUserInputs();

    string opcao = string.Empty;
    bool exibirMenu = true;

    while (exibirMenu) // loop do menu
    {
      Console.Clear();
      Console.WriteLine("Digite a sua opção:");
      Console.WriteLine("1 - Cadastrar veículo");
      Console.WriteLine("2 - Remover veículo");
      Console.WriteLine("3 - Listar veículos");
      Console.WriteLine("4 - Encerrar");

      switch (Console.ReadLine())
      {
        case "1":
          p.AddVehicle();
          break;

        case "2":
          p.RemoveVehicle();
          break;

        case "3":
          p.ListVehicles();
          break;

        case "4":
          exibirMenu = false;
          break;

        default:
          Console.WriteLine("Opção inválida. Tente novamente.");
          break;
      }

      Console.WriteLine("Pressione [ENTER] para continuar");
      Console.ReadLine();
    }

    Console.WriteLine("O programa se encerrou");
  }
}
