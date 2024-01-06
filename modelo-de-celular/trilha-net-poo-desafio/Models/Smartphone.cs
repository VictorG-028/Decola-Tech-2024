namespace DesafioPOO.Models
{
  public abstract class Smartphone
  {
    public string Number { get; set; }
    protected string Model { get; set; }
    protected string IMEI { get; set; }
    protected int Memory { get; set; }

    public Smartphone(string number, string model, string IMEI, int memory)
    {
      Number = number;
      Model = model;
      this.IMEI = IMEI;
      Memory = memory;
    }

    public void Call()
    {
      Console.WriteLine("Ligando...");
    }

    public void ReceiveCall()
    {
      Console.WriteLine("Recebendo ligação...");
    }

    public abstract void InstallApp(string nomeApp);
  }
}
