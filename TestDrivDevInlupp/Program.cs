using Engine;
using System;

namespace TestDrivDevInlupp
{
    class Program
    {
        public static void Main(string[] args)
        {
            SocialNetworkEngine engine = new SocialNetworkEngine();
            int inputNamePosition = 0;
            int inputCommandPosition = 1;

            Console.WriteLine("Hello and welcome to your social network!");

            while (true)
            {
                var command = Console.ReadLine()?.Split(" ");

                var inputName = string.Empty;
                var inputCommand = string.Empty;

                if (command[inputNamePosition] != null)
                    inputName = command[inputNamePosition];
                if (command[inputCommandPosition] != null)
                    inputCommand = command[inputCommandPosition];

               
                switch (inputCommand)
                {
                    // message
                    case "/send_message":
                        engine.SendMessage(inputName, command[2], MessageBuilder(command));
                        break;

                    // view message
                    case "/view_messages":
                        var messages = engine.ViewMessages(inputName);

                        foreach (var message in messages)
                            Console.WriteLine($"{message.SendDateTime} {message.Body} From: {message.Sender}");
                        break;

                    // post
                    case "/post":
                        engine.CreatePost(inputName, PostBuilder(command));
                        break;

                    // wall
                    case "/wall":
                        var postsOnWall = engine.Wall(inputName);

                        foreach (var post in postsOnWall)
                            Console.WriteLine(post.Body + " Posted by: " + post.Sender);
                        break;

                    // timeline
                    case "/timeline":
                        var posts = engine.TimeLine(inputName);
                        foreach (var post in posts)
                            Console.WriteLine(post.Body);
                        break;

                    // follow
                    case "/follow":
                        var usersToFollow = engine.Follow(inputName, command[2]);
                        foreach (var user in usersToFollow)
                        {
                            Console.WriteLine(user.UserName);
                        }

                        break;
                    default:
                        Console.WriteLine("Please write your command");
                        break;


                }


            }
        }
        static string MessageBuilder(string[] userInput)
        {
            int messageStart = 3;

            string message = "";
            for (int i = messageStart; i < userInput.Length; i++)
            {
                if (i == messageStart)
                {
                    message += userInput[i];
                }
                else
                {
                    message += " " + userInput[i];
                }
            }
            return message;
        }

        static string PostBuilder(string[] userInput)
        {
            int messageStart = 2;
            string message = "";
            for (int i = messageStart; i < userInput.Length; i++)
            {
                if (i == messageStart)
                {
                    message += userInput[i];
                }
                else
                {
                    message += " " + userInput[i];
                }
            }
            return message;
        }
    }
}
