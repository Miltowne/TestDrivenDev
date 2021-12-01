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
            int inputMessangeOrReceiverPosition = 2;

            Console.WriteLine("Hello and welcome to our social network!");

            while (true)
            {
                var command = Console.ReadLine()?.Split(" ");

                var inputName = string.Empty;
                var inputCommand = string.Empty;
                var inputMessageOrReceiver = string.Empty;
                var inputReceiverName = string.Empty;

                if (command[inputNamePosition] != null)
                    inputName = command[inputNamePosition];
                if (command[inputCommandPosition] != null)
                    inputCommand = command[inputCommandPosition];
                if (command[inputMessangeOrReceiverPosition] != null)
                {
                    inputMessageOrReceiver = command[inputMessangeOrReceiverPosition];
                    for (int i = inputMessangeOrReceiverPosition +1; i < command.Length; i++)
                        inputMessageOrReceiver = $"{inputMessageOrReceiver} {command[i]}";
                    string[] receiverName = inputMessageOrReceiver.Split(' ');
                    inputReceiverName = receiverName[0];
                }

                //if (command != null && command.Length > inputNamePosition)
                //    inputName = command?[inputNamePosition];

                //if (command != null && command.Length > inputCommandPosition)
                //    inputCommand = command?[inputCommandPosition];

                //if (command != null && command.Length > inputMessangePosition)
                //    for (var i = 2; i < command.Length; i++)
                //        inputMessage = string.IsNullOrEmpty(inputMessage) ? command?[i] : $"{inputMessage} {command?[i]}";

                switch (inputCommand)
                {
                    // message
                    case "/send_message":
                        engine.SendMessage(inputName, inputReceiverName, inputMessageOrReceiver);
                        break;

                    // view message
                    case "/view_messages":
                        var messages = engine.ViewMessages(inputName);

                        foreach (var message in messages)
                            Console.WriteLine($"{message.SendDateTime} {message.Body} From: {message.Sender}");
                        break;

                    // post
                    case "/post":
                        engine.CreatePost(inputName, inputMessageOrReceiver);
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
                        var usersToFollow = engine.Follow(inputName, inputReceiverName);
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
    }
}
