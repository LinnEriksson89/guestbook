/* DT071G - Programmering i C#.NET
 * Moment 3
 * Linn Eriksson, HT23
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Guestbook
{
        
    class Guestbook
    {
        //Variables
        private readonly string fileName = "posts.json", testAuthor = "Linn", testContent = "Hej världen!";
        private List<Post> postList;
        private int postLength;
        
        //Constructor for guestbook.
        public Guestbook()
        {
            //Creates a list of the posts, length of the list and a testPost.
            postList = new List<Post>();

            //Read json-file and turn into list.
            if(File.Exists(fileName))
            {
                ReadList();
                postLength = postList.Count;

                //Id the list is empty, add test-data to list.
                if(postLength < 1)
                {
                    postList.Add(new Post(testAuthor, testContent));
                    
                    File.WriteAllText(@fileName, JsonSerializer.Serialize(postList));
                }
            }
            else
            {
                //Create a post and write to the file that's created.
                postList.Add(new Post(testAuthor, testContent));

                File.WriteAllText(@fileName, JsonSerializer.Serialize(postList));
            }
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
            //Variables.
            string username, content;
            int tempInt;
            Post newPost;

            //Showing the previous posts so that one knows what to add to the guestbook.
            DisplayPosts("Här är vad folk har skrivit tidigare:");

            Console.WriteLine("Nu är det din tur att skriva i gästboken!");
            Console.WriteLine("Ange det namn du vill signera med:");

            try
            {
                //Check if username is at least 3 characters long.
                username = Console.ReadLine();
                tempInt = username.Length;

                if (tempInt > 2)
                {
                    //Print information and get message.
                    Console.WriteLine("Vad vill du skriva i gästboken " + username + "?");
                    Console.WriteLine("Ditt inlägg måste vara minst 10 tecken.");
                    
                    try
                    {
                        content = Console.ReadLine();
                        tempInt = content.Length;

                        if (tempInt > 10)
                        {
                            //Create a post and push it to the list.
                            newPost = new Post(username, content);
                            postList.Add(newPost);

                            try
                            {
                                //Overwrite the file with the new list.
                                File.WriteAllText(@fileName, JsonSerializer.Serialize(postList));
                                Console.WriteLine("Ditt inlägg har lagts till.");
    
                            }
                            catch
                            {
                                Console.WriteLine("Tyvärr, något gick fel med ditt inlägg.");
                            }
                        }
                        else
                        {
                            //Inform why it didn't work.
                            Console.WriteLine("Ett inlägg måste vara minst 10 tecken långt.");
                            content = "";
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Något gick fel när du skulle skriva in ditt meddelande, försök igen från början.");
                    }


                }
                else
                {
                    Console.WriteLine("Namnet måste vara minst tre tecken långt.");
                }
            }
            catch
            {
                Console.WriteLine("Något gick fel när du skrev in användarnamnet, försök igen.");
            }

            
            ReturnToMenu();
        }

        private void RemovePosts()
        {
            //Local variables.
            int input, bugcounter = 0;
            string tempString;
            bool menu = true;
            
            //Calculate number of posts in the file.
            postLength = postList.Count;

            //If no posts, display information.
            if (postLength == 0)
            {
                Console.WriteLine("Tyvärr finns det inga inlägg i gästboken.");
            }
            else
            {
                //Othwerwise show posts + instructions.
                DisplayPosts("Vilket inlägg vill du radera?");
                Console.WriteLine("Ange id-nummer för det inlägg du vill radera:");
                
                //Decrease postLength to match 0-indexed array.
                postLength--;
                
                while (menu)
                {
                    //Try to convert the user input to int, otherwise print errormessage.
                    try
                    {
                        tempString = Console.ReadLine();
                        input = Convert.ToInt32(tempString);
                        
                        
                        //Control that the id is within the list.
                        if(input <= postLength)
                        {
                            int postId = 0;
                            //Remove the object with the inputed id.
                            foreach (var post in postList)
                            {
                                if(postId == input)
                                {
                                    postList.RemoveAt(postId);

                                    //Overwrite the file with the new list.
                                    File.WriteAllText(@fileName, JsonSerializer.Serialize(postList));
    
                                    Console.WriteLine("Inlägget med id " + input + " har raderats och du skickas tillbaka till huvudmenyn när du trycker på valfri tangent.");

                                    menu = false;
                                }

                                postId++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Du verkar ha angett ett id som inte finns, testa igen!");
                            bugcounter++;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Du verkar ha angett något som inte är en siffra.");
                        bugcounter++;

                    }

                    //Errorhandling if user gets stuck in a loop.
                    if (bugcounter > 3)
                    {
                        Console.WriteLine("Det verkar ha blivit något fel och du skickas tillbaka till startmenyn.");
                        menu = false;
                        bugcounter = 0;
                    }
                }
            }

           //Return to main menu.
            ReturnToMenu();
        }

        private void ReadPosts()
        {
            //Shows posts.
            DisplayPosts("Här finns följande inlägg:");

            ReturnToMenu();
            
        }

        private void DisplayPosts(string message)
        {
            //If the file exist, try to read it and display the posts..
            if (File.Exists(fileName))
            {
                try
                {
                    //Read the list.
                    ReadList();
                    
                    //Calculate number of posts in the file.
                    postLength = postList.Count;

                    if (postLength > 0)
                    {
                        int postId = 0;
                        Console.WriteLine("Välkommen till gästboken!");
                        Console.WriteLine(message);
                        Console.WriteLine("------------------------------------\n");

                        //Loop through posts.
                        foreach (var post in postList)
                        {
                            Console.WriteLine(post.Author + " skrev:");
                            Console.WriteLine(post.Content);
                            Console.WriteLine("\nInläggets id-nummer: " + postId);
                            Console.WriteLine("------------------------------------\n");

                            postId++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Det finns tyvärr inga inlägg i gästboken!");
                    }

                }
                catch
                {
                    Console.WriteLine("Tyvärr, filen kunde inte läsas in.");

                }
            }
            else
            {                
                Console.WriteLine("Det finns inga inlägg i gästboken.");
            }
        }

        private List<Post> ReadList()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    string json = streamReader.ReadToEnd();
                    postList = JsonSerializer.Deserialize<List<Post>>(json);

                    streamReader.Close();
                }
            }
            catch
            {
                Console.WriteLine("Filen är tom!");

                postList = postList;

            }
            
            //Return value outside of loop, error handling in other parts of program so it shouldn't be empty.
            return postList;
        }

        private void ReturnToMenu()
        {
            //So that the program pauses before returning to menu.
            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey();
        }
    
    }
}