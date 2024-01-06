using learning_CSharp_ui.Pages;

namespace learning_CSharp_ui.src;

static class GraphicProgram
{
  public static void RunGraphicVersion()
  {
    // To customize application configuration such as set high DPI settings or default font,
    // see https://aka.ms/applicationconfiguration.
    ApplicationConfiguration.Initialize();
    Application.Run(new MainPage());
  }
}
