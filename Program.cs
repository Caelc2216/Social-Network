using System.Runtime.CompilerServices;

SocialNetwork network = new SocialNetwork();

Console.WriteLine(@"Welcome to the Social Network App!
What would you like to do?
1. Add a user
2. Add a friend
3. Remove a friend
4. Display friends
5. Remove a user
6. Find Mutual Friends
7. Suggested Friends
8. Exit");

bool running = true;
while (running)
{
    ConsoleKeyInfo input = Console.ReadKey();

    switch (input.Key)
    {
        case ConsoleKey.D1:
            Console.Clear();
            Console.WriteLine("Enter the name of the person you want to add: ");
            string name = Console.ReadLine();
            network.AddUser(name);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D2:
            Console.Clear();
            Console.WriteLine("Enter the name of the first person: ");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter the name of the second person: ");
            string name2 = Console.ReadLine();
            network.AddFriend(name1, name2);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D3:
            Console.Clear();
            Console.WriteLine("Enter the name of the first person: ");
            string n1 = Console.ReadLine();
            Console.WriteLine("Enter the name of the second person: ");
            string n2 = Console.ReadLine();
            network.RemoveFriend(n1, n2);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D4:
            Console.Clear();
            Console.WriteLine("Enter the name of the person: ");
            string n = Console.ReadLine();
            network.DisplayFriends(n);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D5:
            Console.Clear();
            Console.WriteLine("Enter the name of the person you want to remove: ");
            string person = Console.ReadLine();
            network.RemoveUser(person);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D6:
            Console.Clear();
            Console.WriteLine("Enter the name of the first person: ");
            string user1 = Console.ReadLine();
            Console.WriteLine("Enter the name of the second person: ");
            string user2 = Console.ReadLine();
            network.FindMutualFriends(user1, user2);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D7:
            Console.Clear();
            Console.WriteLine("Enter the name of the user you want suggested friends for: ");
            string user = Console.ReadLine();
            network.SuggestFriends(user);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D8:
            running = false;
            break;
    }

    Console.Clear();
    DisplayMenu();
}

void DisplayMenu()
{
    Console.WriteLine(@"Welcome to the Social Network App!
What would you like to do?
1. Add a user
2. Add a friend
3. Remove a friend
4. Display friends
5. Remove a user
6. Find Mutual Friends
7. Suggested Friends
8. Exit");
}