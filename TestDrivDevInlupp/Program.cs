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
            int inputMessangePosition = 2;

            Console.WriteLine("Hello and welcome to our social network!");

            while (true)
            {
                var command = Console.ReadLine()?.Split(" ");

                var inputName = string.Empty;
                var inputCommand = string.Empty;
                var inputMessage = string.Empty;

                if (command != null && command.Length > inputNamePosition)
                    inputName = command?[inputNamePosition];

                if (command != null && command.Length > inputCommandPosition)
                    inputCommand = command?[inputCommandPosition];

                if (command != null && command.Length > inputMessangePosition)
                    for (var i = 2; i < command.Length; i++)
                        inputMessage = string.IsNullOrEmpty(inputMessage) ? command?[i] : $"{inputMessage} {command?[i]}";

                if (command != null)
                    switch (command.Length)
                    {
                        // No commandinput
                        case 0: continue;

                        // Single word commandinput
                        case 1: break;

                        // 2 or more words commandinput
                        default:

                            switch (inputCommand)
                            {
                                // message
                                case "/send_message":
                                    engine.SendMessage(inputName, command[2], command[3]);
                                    break;

                                // view message
                                case "/view_messages":
                                    var messages = engine.ViewMessages(inputName);

                                    foreach (var message in messages)
                                        Console.WriteLine($"{message.SendDateTime} {message.Body} From: {message.Sender}");
                                    break;

                                // post
                                case "/post":
                                    engine.CreatePost(inputName, inputMessage);
                                    break;

                                // wall
                                case "/wall":
                                    var postsOnWall = engine.Wall(inputName);

                                    foreach (var post in postsOnWall)
                                        Console.WriteLine(post.Body + " Posted by: " + post.Sender);
                                    break;

                                // timeline
                                case "/timeline":
                                    var posts = engine.TimeLine(command[2]);
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


                            }
                            break;
                    }
                
            }
        }
    }
}
