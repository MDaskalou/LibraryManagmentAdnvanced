namespace LibraryManagmentAdnvanced
{
    public class Program
    {
        static void Main(string[] args)
        {
            


            string filePath = "LibraryData.json"; // Förutsatt att filen ligger i samma katalog

            UserMenu userMenu = new UserMenu(filePath);

            userMenu.ShowMenu();




        }
    }
}
