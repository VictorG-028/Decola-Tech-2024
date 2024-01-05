namespace learning_CSharp_ui;

public class InputDialog : Form
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

  public Dictionary<int, decimal> Results = [];

  public InputDialog(string[] prompts)
  {
    InitializeComponents(prompts);
  }

  private void InitializeComponents(string[] prompts)
  {
    okButton.Height += 20;
    int extraFinalHeight = 10;
    int promptHeight = okButton.Height + extraFinalHeight;

    int i = 0;
    foreach (string prompt in prompts.Reverse())
    {
      inputTextBoxes.Add(new()
      {
        Dock = DockStyle.Top,
        TextAlign = HorizontalAlignment.Center
      });
      Controls.Add(inputTextBoxes[i]);

      promptLabels.Add(new()
      {
        Dock = DockStyle.Top,
        TextAlign = ContentAlignment.MiddleCenter,
        Text = prompt
      });
      Controls.Add(promptLabels[i]);

      i++;
      promptHeight += inputTextBoxes[i].Height + promptLabels[i].Height;
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
      foreach (TextBox tb in inputTextBoxes)
      {
        if (decimal.TryParse(tb.Text, out decimal result))
        {
          Results[i] = result;
          i++;
        }
        else
        {
          throw new FormatException("Por favor, insira um número decimal válido.");
        }
      }
      Close();
    }
    catch (FormatException ex)
    {
      MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}
