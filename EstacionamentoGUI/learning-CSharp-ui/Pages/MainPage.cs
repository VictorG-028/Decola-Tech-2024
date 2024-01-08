using learning_CSharp_ui.Models;
using learning_CSharp_ui.components;

namespace learning_CSharp_ui.Pages;

public partial class MainPage : Form
{
  private readonly Button addButton = new()
  {
    Text = "1 - Cadastrar veículo",
    // Location = new Point(10, 40),
    // Size = new Size(130, 30),
    AutoSize = true,
    AutoSizeMode = AutoSizeMode.GrowAndShrink,
    BackColor = Color.Wheat,
  };
  private readonly Button removeButton = new()
  {
    Text = "2 - Remover veículo",
    // Location = new Point(10, 70),
    // Size = new Size(130, 30),
    AutoSize = true,
    AutoSizeMode = AutoSizeMode.GrowAndShrink,
    BackColor = Color.Wheat,
  };
  private readonly Button listButton = new()
  {
    Text = "3 - Listar veículos",
    // Location = new Point(10, 100),
    // Size = new Size(130, 30),
    AutoSize = true,
    AutoSizeMode = AutoSizeMode.GrowAndShrink,
    BackColor = Color.Wheat,
  };
  private readonly Button exitButton = new()
  {
    Text = "4 - Encerrar",
    // Location = new Point(10, 130),
    // Size = new Size(130, 30),
    AutoSize = true,
    AutoSizeMode = AutoSizeMode.GrowAndShrink,
    BackColor = Color.Wheat,
  };
  private readonly Parking p = InitAskingUserInputs();

  public MainPage()
  {
    InitializeComponent();
    InitializeButtons();
    InitializeLayout();
    this.Text = "EstacionamentoGUI";
    this.BackColor = Color.Tan;
    string path = "../../../images/Avanade.ico";
    // this.BackgroundImage = Image.FromFile(path);
    try { this.Icon = new Icon(path); }// Precisa ser um arquivo .ico com resolução 32x32
    catch (Exception ex) { Console.WriteLine(ex); }
  }


  private void InitializeButtons()
  {
    // Adicione eventos e controles aos botões aqui
    addButton.Click += AddVeihicle_Click;
    removeButton.Click += RemoveVehicleButton_Click;
    listButton.Click += ListVehiclesButton_Click;
    exitButton.Click += ExitButton_Click;
  }

  private void InitializeLayout()
  {
    TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
    {
      Dock = DockStyle.Fill,
      AutoSize = true,
      Margin = new Padding(20, 20, 20, 20)  // Margens superior e inferior de 10 pixels
    };

    // Adicione os botões ao layout
    tableLayoutPanel.Controls.Add(addButton);
    tableLayoutPanel.Controls.Add(removeButton);
    tableLayoutPanel.Controls.Add(listButton);
    tableLayoutPanel.Controls.Add(exitButton);

    // Define o alinhamento vertical dos botões como central
    foreach (Control control in tableLayoutPanel.Controls)
    {
      if (control is Button button)
      {
        button.Anchor = AnchorStyles.None;
        button.Dock = DockStyle.None;
        button.TextAlign = ContentAlignment.MiddleCenter;
      }
    }

    // Adicione o layout ao formulário
    Controls.Add(tableLayoutPanel);

    int minWidth = 350;
    int minHeight = 230;
    this.MinimumSize = new Size(minWidth, minHeight);

    // Define o tamanho da janela com base no tamanho dos botões
    int maxWidth = Math.Max(
      Math.Max(addButton.Width, removeButton.Width),
      Math.Max(listButton.Width, exitButton.Width)
    );

    this.ClientSize = new Size(Math.Max(maxWidth + 20, minWidth), minHeight);
  }

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
