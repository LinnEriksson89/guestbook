/* DT071G - Programmering i C#.NET
 * Moment 3
 * Linn Eriksson, HT23
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace Guestbook
{
        
    class Guestbook
    {
        //Variables
        private string fileName = "posts.json";
        
        //Constructor for guestbook.
        public Guestbook()
        {
            //This constructor does nothing but is required to make an object.
        }
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

            //Reading from the json-file with try-catch as errorhandling.
            try
            {
                if(File.Exists(fileName))
                {
                    using(StreamReader streamReader = new StreamReader(fileName))
                    {
                        //Deserialisera och läsa json här typ?
                    }

                    //Tillfällig felhanteringshjälp som ska raderas.
                    Console.WriteLine("Filen finns!");
                }
                else{
                    using(FileStream fileStream = File.Create(fileName))
                    {
                        string jsonTest = "{\"posts\": [{\"Author\": \"Testanvändare\", \"Content\": \"Testinnehåll\"]";

                        StreamWriter streamWriter = new StreamWriter(fileName, true);

                        streamWriter.WriteLine(jsonTest);

                        Console.WriteLine("Filen fanns inte men har skapats!");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Tyvärr, filen kunde inte läsas in.");
            }

            Console.ReadKey();
        }
    }
}