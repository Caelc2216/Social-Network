using System.Runtime.CompilerServices;

SocialNetwork network = new SocialNetwork();
List<string> people = new List<string>();

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
            AddUser(name);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D2:
            Console.Clear();
            Console.WriteLine("Enter the name of the first person: ");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter the name of the second person: ");
            string name2 = Console.ReadLine();
            AddFriend(name1, name2);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D3:
            Console.Clear();
            Console.WriteLine("Enter the name of the first person: ");
            string n1 = Console.ReadLine();
            Console.WriteLine("Enter the name of the second person: ");
            string n2 = Console.ReadLine();
            RemoveFriend(n1, n2);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D4:
            Console.Clear();
            Console.WriteLine("Enter the name of the person: ");
            string n = Console.ReadLine();
            DisplayFriends(n);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D5:
            Console.Clear();
            Console.WriteLine("Enter the name of the person you want to remove: ");
            string person = Console.ReadLine();
            RemoveUser(person);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D6:
            Console.Clear();
            Console.WriteLine("Enter the name of the first person: ");
            string user1 = Console.ReadLine();
            Console.WriteLine("Enter the name of the second person: ");
            string user2 = Console.ReadLine();
            FindMutualFriends(user1, user2);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D7:
            Console.Clear();
            Console.WriteLine("Enter the name of the user you want suggested friends for: ");
            string user = Console.ReadLine();
            SuggestFriends(user);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            break;

        case ConsoleKey.D8:
            running = false;
            break;
    }
}


void AddUser(string name)
{
    if (network.HasUser(name))
    {
        Console.WriteLine($"{name} already exists.");
        return;
    }
    network.AddUser(name);
    people.Add(name);
    Console.WriteLine($"{name} has been added.");
}

string FindUser(string name)
{
    foreach (string person in people)
    {
        if (person == name)
        {
            return person;
        }
    }
    return null;
}

void AddFriend(string user1, string user2)
{
    string person1 = FindUser(user1);
    string person2 = FindUser(user2);
    if (person1 == null || person2 == null)
    {
        Console.WriteLine($"One or both users do not exist.");
        return;
    }

    if (network.AreFriends(person1, person2))
    {
        Console.WriteLine($"{person1} and {person2} are already friends.");
        return;
    }

    network.AddFriend(person1, person2);
    Console.WriteLine($"{person1} and {person2} are now friends.");
}

void RemoveFriend(string user1, string user2)
{
    string person1 = FindUser(user1);
    string person2 = FindUser(user2);
    if (person1 == null || person2 == null)
    {
        Console.WriteLine($"One or both users do not exist.");
        return;
    }

    if (!network.AreFriends(person1, person2))
    {
        Console.WriteLine($"{person1} and {person2} are not friends.");
        return;
    }

    network.RemoveFriend(person1, person2);
    Console.WriteLine($"{person1} and {person2} are no longer friends.");
}

void DisplayFriends(string user)
{
    string person = FindUser(user);
    if (person == null)
    {
        Console.WriteLine($"{user} does not exist.");
        return;
    }

    network.DisplayFriends(person);
}

void RemoveUser(string name)
{
    string person = FindUser(name);
    if (person == null)
    {
        Console.WriteLine($"{name} does not exist.");
        return;
    }

    network.RemoveUser(person);
    people.Remove(person);
    Console.WriteLine($"{person} has been removed from the network.");
}

void FindMutualFriends(string user1, string user2)
{
    List<string> mutualFriends = new();
    string person1 = FindUser(user1);
    string person2 = FindUser(user2);

    if(person1 == null || person2 == null)
    {
        Console.WriteLine($"One or both users do not exist.");
        return;
    }

    foreach (var friend in network.UserFriendList[user1])
    {
        if (network.UserFriendList[user1].Contains(friend)
            && network.UserFriendList[user2].Contains(friend))
        {
            mutualFriends.Add(friend);
        }
    }

    if (mutualFriends.Count == 0)
    {
        Console.WriteLine($"{user1} and {user2} have no mutual friends.");
        return;
    }

    Console.WriteLine($"Mutual friends of {user1} and {user2}: ");
    foreach (var friend in mutualFriends)
    {
        Console.Write($"{friend}, ");
    }
}

void SuggestFriends(string user)
{
    List<string> suggestedFriends = new();
    if(!network.HasUser(user))
    {
        Console.WriteLine($"{user} does not exist.");
        return;
    }

    foreach(var friend in network.UserFriendList[user])
    {
        foreach(var f in network.UserFriendList[friend])
        {
            if(!network.UserFriendList[user].Contains(f) && f != user)
            {
                suggestedFriends.Add(f);
            }
        }
    }

    if(suggestedFriends.Count == 0)
    {
        Console.WriteLine($"No suggested friends for {user}.");
        return;
    }
    
    Console.WriteLine($"Friend suggestions for {user}: ");
    foreach(var friend in suggestedFriends)
    {
        Console.Write($"{friend}, ");
    }
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