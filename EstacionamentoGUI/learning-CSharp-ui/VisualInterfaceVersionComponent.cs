using DesafioFundamentos.Models;

namespace learning_CSharp_ui;

public partial class VisualInterfaceVersionComponent : Form
{
  private readonly TextBox userTextInputField = new()
  {
    Location = new Point(10, 10),
    Size = new Size(200, 20)
  };
  private readonly Button addButton = new()
  {
    Text = "1 - Cadastrar veículo",
    Location = new Point(10, 40),
    Size = new Size(130, 20)
  };
  private readonly Button removerButton = new()
  {
    Text = "2 - Remover veículo",
    Location = new Point(10, 70),
    Size = new Size(130, 20)
  };
  private readonly Button listarButton = new()
  {
    Text = "3 - Listar veículos",
    Location = new Point(10, 100),
    Size = new Size(130, 20)
  };
  private readonly Button encerrarButton = new()
  {
    Text = "4 - Encerrar",
    Location = new Point(10, 130),
    Size = new Size(130, 20)
  };
  private readonly Parking p = InitAskingUserInputs();

  public VisualInterfaceVersionComponent()
  {
    InitializeComponent();

    // TextBox
    Controls.Add(userTextInputField);
    userTextInputField.TextChanged += InputField_TextChanged;

    // Botões
    addButton.Click += AddVeihicle_Click;
    Controls.Add(addButton);

    removerButton.Click += RemoverButton_Click;
    Controls.Add(removerButton);

    listarButton.Click += ListarButton_Click;
    Controls.Add(listarButton);

    encerrarButton.Click += EncerrarButton_Click;
    Controls.Add(encerrarButton);
  }

  private void InputField_TextChanged(object? sender, EventArgs e)
  {
    Console.WriteLine("Texto no TextBox: " + userTextInputField.Text);
  }

  private void AddVeihicle_Click(object? sender, EventArgs e)
  {
    Console.WriteLine("Botão 'Cadastrar veículo' pressionado.");
    p.AddVehicle();
  }

  private void RemoverButton_Click(object? sender, EventArgs e)
  {
    Console.WriteLine("Botão 'Remover veículo' pressionado.");
    p.RemoveVehicle();
  }

  private void ListarButton_Click(object? sender, EventArgs e)
  {
    Console.WriteLine("Botão 'Listar veículos' pressionado.");
    p.ListVehicles();
  }

  private void EncerrarButton_Click(object? sender, EventArgs e)
  {
    Console.WriteLine("Botão 'Encerrar' pressionado.");
  }

  public static Parking InitAskingUserInputs()
  {

    InputDialog dialog = new(
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
