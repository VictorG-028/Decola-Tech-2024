namespace learning_CSharp_ui.components;

public class Popup : Form
{
  private readonly List<Label> promptLabels = [];
  private readonly Button okButton = new()
  {
    Text = "OK",
    DialogResult = DialogResult.OK,
    Dock = DockStyle.Top,
    Height = 30
  };

  public Popup(string[] prompts)
  {
    InitializeComponents(prompts);
  }

  private void InitializeComponents(string[] prompts)
  {
    int extraFinalWidth = 20;
    int extraFinalHeight = 0;
    int maxWidth = 0;
    int cummulativePromptHeight = okButton.Height + extraFinalHeight;

    foreach (string prompt in prompts.Reverse())
    {
      Label l = new()
      {
        Dock = DockStyle.Top,
        TextAlign = ContentAlignment.MiddleCenter,
        Text = prompt
      };
      promptLabels.Add(l);
      Controls.Add(l);

      cummulativePromptHeight += l.Height;

      // Increase the windows Width if prompt is large
      if (l.Width > maxWidth)
      {
        maxWidth = l.Width;
      }
    }

    okButton.Click += OkButton_Click;
    Controls.Add(okButton);
    AcceptButton = okButton;

    this.Width += maxWidth + extraFinalWidth;
    // this.Height += cummulativePromptHeight;
  }

  private void OkButton_Click(object? sender, EventArgs e)
  {
    Close();
  }
}
