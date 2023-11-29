/* DT071G - Programmering i C#.NET
 * Moment 3
 * Linn Eriksson, HT23
 */

class Guestbook
{
    public bool Menu()
    {
        //Variable for user input.
        int menuInput = 0;

        //The text of the menu.
        Console.Clear();
        Console.WriteLine("Hej och välkommen till den här gästboken!");
        Console.WriteLine("Skriv den siffra som motsvarar ditt menyval:\n");
        Console.WriteLine("1. Skriv nytt inlägg i gästboken.");
        Console.WriteLine("2. Ta bort inlägg ur gästboken.");
        Console.WriteLine("3. Läs alla inlägg i gästboken.");
        Console.WriteLine("4. Avsluta programet.");

        //Error handling of user-input with try-catch.
        try
        {
            menuInput = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Du gjorde ett ogiltigt menyval.");
        }

        //Switch for the actual menu.
        switch(menuInput)
        {
            case 1:
                Console.Clear();
                AddPosts();
                return true;

            case 2:
                Console.Clear();
                RemovePosts();
                return true;
            
            case 3:
                Console.Clear();
                ReadPosts();
                return true;

            case 4:
                Console.Clear();
                return false;

            default:
                Console.Clear();
                Console. WriteLine("Du valde ett ogiltigt alternativ, försök igen.");
                Console.ReadKey();
                return true;
        }
    }

    private void AddPosts()
    {
        //
    }

    private void RemovePosts()
    {
        //
    }

    private void ReadPosts()
    {
        //
    }
}