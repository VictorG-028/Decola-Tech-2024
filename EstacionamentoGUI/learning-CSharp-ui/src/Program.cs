using learning_CSharp_ui.src;
using learning_CSharp_ui.Pages;

namespace learning_CSharp_ui;

static class Program
{
  /// <summary>
  ///  The main entry point for the application.
  /// </summary>

  [STAThread]
  static void Main()
  {
    // To customize application configuration such as set high DPI settings or default font,
    // see https://aka.ms/applicationconfiguration.
    ApplicationConfiguration.Initialize();
    Application.Run(new MainPage());
  }
}
