/* DT071G - Programmering i C#.NET
 * Moment 3
 * Linn Eriksson, HT23
 */

using System;

namespace Guestbook
{
    class Post
    {
        //Variable.
        private static int id = 0;
    
        //Constructor for post-class
        public Post (string author, string content)
        {
            Id = Convert.ToString(generateId());
            Author = author;
            Content = content;
        }

        //Get and set-methods.
        public string Id {get; set;}
        public string Author {get; set;}
        public string Content {get; set;}

        static int generateId()
        {
            return id++;
        }
    }
}