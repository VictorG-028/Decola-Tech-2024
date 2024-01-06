namespace DesafioPOO.Models
{
  public class Nokia : Smartphone
  {
    public Nokia(string number, string model, string IMEI, int memory)
          : base(number, model, IMEI, memory) { }
    public override void InstallApp(string name)
    {
      Console.WriteLine($"{Model} (IMEI {IMEI}) está instalando aplicativo {name} (Memória total {Memory})");
    }
  }
}
