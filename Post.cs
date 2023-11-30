/* DT071G - Programmering i C#.NET
 * Moment 3
 * Linn Eriksson, HT23
 */

using System;

namespace Guestbook
{
    class Post
    {
        //Constructor for post-class
        public Post (string author, string content)
        {

            Author = author;
            Content = content;
        }

        //Get and set-methods.
        public string Author {get; set;}
        public string Content {get; set;}
    }
}