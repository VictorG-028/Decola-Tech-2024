namespace learning_CSharp_ui;
static class GUIProgram
{
    [STAThread]
    public static void RunGUIVersion()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new VisualInterfaceVersionComponent());
    }
}
