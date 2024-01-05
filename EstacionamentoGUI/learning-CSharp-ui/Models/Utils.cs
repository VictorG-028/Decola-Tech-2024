namespace DesafioFundamentos.Models
{
    public class Utils
    {
        public static string ReadNonNullString()
        {
            string? s;
            do
            {
                s = Console.ReadLine();
            } while (s == null);
            return s;
        }
    }
}
