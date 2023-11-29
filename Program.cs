/* DT071G - Programmering i C#.NET
 * Moment 3
 * Linn Eriksson, HT23
 */

//Variable and object created.
Guestbook guestbook = new Guestbook();
bool showMenu = true;

//Menu-setup inspired by https://wellsb.com/csharp/beginners/create-menu-csharp-console-application.
while(showMenu)
{
    showMenu = guestbook.Menu();
}

//End of program.
Console.WriteLine("Tryck på valfri tangent för att avsluta programet.");
Console.ReadKey();