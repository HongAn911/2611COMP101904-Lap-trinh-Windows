namespace Lab09_StudentCard;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FrmStudentCard());
    }
}
