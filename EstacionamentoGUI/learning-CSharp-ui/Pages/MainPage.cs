using learning_CSharp_ui.Models;
using learning_CSharp_ui.components;

namespace learning_CSharp_ui.Pages;

public partial class MainPage : Form
{
  // private readonly TextBox userTextInputField = new()
  // {
  //   Location = new Point(10, 10),
  //   Size = new Size(200, 20)
  // };
  private readonly Button addButton = new()
  {
    Text = "1 - Cadastrar veículo",
    Location = new Point(10, 40),
    Size = new Size(130, 30)
  };
  private readonly Button removeButton = new()
  {
    Text = "2 - Remover veículo",
    Location = new Point(10, 70),
    Size = new Size(130, 30)
  };
  private readonly Button listButton = new()
  {
    Text = "3 - Listar veículos",
    Location = new Point(10, 100),
    Size = new Size(130, 30)
  };
  private readonly Button exitButton = new()
  {
    Text = "4 - Encerrar",
    Location = new Point(10, 130),
    Size = new Size(130, 30)
  };
  private readonly Parking p = InitAskingUserInputs();

  public MainPage()
  {
    InitializeComponent();

    // TextBox
    // Controls.Add(userTextInputField);
    // userTextInputField.TextChanged += InputField_TextChanged;

    // Botões
    addButton.Click += AddVeihicle_Click;
    Controls.Add(addButton);

    removeButton.Click += RemoveVehicleButton_Click;
    Controls.Add(removeButton);

    listButton.Click += ListVehiclesButton_Click;
    Controls.Add(listButton);

    exitButton.Click += ExitButton_Click;
    Controls.Add(exitButton);
  }

  // private void InputField_TextChanged(object? sender, EventArgs e)
  // {
  //   Console.WriteLine("Texto no TextBox: " + userTextInputField.Text);
  // }

  private void AddVeihicle_Click(object? sender, EventArgs e)
  {
    InputDialog<string> dialog = new(["Digite a placa do vehículo:"]);
    if (dialog.ShowDialog() != DialogResult.OK)
    {
      throw new ArgumentException("Algo deu errado. Tente novamente.");
    }

    string plate = dialog.Results[0];
    p.AddVehicle(plate);
  }

  private void RemoveVehicleButton_Click(object? sender, EventArgs e)
  {
    InputDialog<string> dialog = new(["Digite a placa do vehículo:"]);
    if (dialog.ShowDialog() != DialogResult.OK)
    {
      throw new ArgumentException("Algo deu errado. Tente novamente.");
    }

    string plate = dialog.Results[0];

    InputDialog<int> dialog2 = new(["Digite a quantidade de horas que o veículo ficou no estacionamento:"]);
    if (dialog2.ShowDialog() != DialogResult.OK)
    {
      throw new ArgumentException("Algo deu errado. Tente novamente.");
    }

    int hours = dialog2.Results[0];
    p.RemoveVehicle(plate, hours);
  }

  private void ListVehiclesButton_Click(object? sender, EventArgs e)
  {
    p.ListVehicles();
  }

  private void ExitButton_Click(object? sender, EventArgs e)
  {
    Application.Exit();
  }

  public static Parking InitAskingUserInputs()
  {

    InputDialog<decimal> dialog = new(
      ["Digite o preço inicial:", "Agora digite o preço por hora:"]
    );
    if (dialog.ShowDialog() != DialogResult.OK)
    {
      throw new ArgumentException("Preço inicial inválido.");
    }

    decimal initialPrice = dialog.Results[0];
    decimal pricePerHour = dialog.Results[1];

    return new Parking(initialPrice, pricePerHour);
  }
}
