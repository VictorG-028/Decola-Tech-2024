namespace learning_CSharp_ui.components;

public class InputDialog<T> : Form
{
  private readonly List<Label> promptLabels = [];
  private readonly List<TextBox> inputTextBoxes = [];
  private readonly Button okButton = new()
  {
    Text = "OK",
    DialogResult = DialogResult.OK,
    Dock = DockStyle.Top,
    // Height = 
  };

  public Dictionary<int, T> Results = [];

  public InputDialog(string[] prompts)
  {
    InitializeComponents(prompts);
  }

  private void InitializeComponents(string[] prompts)
  {
    okButton.Height += 20;
    int extraFinalHeight = 0;//10;
    int promptHeight = okButton.Height + extraFinalHeight;

    int i = 0;
    foreach (string prompt in prompts.Reverse())
    {
      inputTextBoxes.Add(new()
      {
        Dock = DockStyle.Top,
        TextAlign = HorizontalAlignment.Center,
        Top = 50
      });
      Controls.Add(inputTextBoxes[i]);

      promptLabels.Add(new()
      {
        Dock = DockStyle.Top,
        TextAlign = ContentAlignment.MiddleCenter,
        Text = prompt
      });
      Controls.Add(promptLabels[i]);

      promptHeight += inputTextBoxes[i].Height * 2 + promptLabels[i].Height * 2;
      i++;
    }
    okButton.Click += OkButton_Click;
    Controls.Add(okButton);
    AcceptButton = okButton;

    this.Height = promptHeight;
  }

  private void OkButton_Click(object? sender, EventArgs e)
  {
    try
    {
      int i = 0;
      foreach (TextBox textBox in inputTextBoxes)
      {
        // if (decimal.TryParse(tb.Text, out decimal result))
        // {
        // Use Convert.ChangeType para converter o valor da TextBox para o tipo genérico T
        T result = (T)Convert.ChangeType(textBox.Text, typeof(T));
        Results[i] = result;
        i++;
        // }
        // else
        // {
        //   throw new FormatException("Por favor, insira um número decimal válido.");
        // }
      }
      Close();
    }
    catch (FormatException ex)
    {
      MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}
