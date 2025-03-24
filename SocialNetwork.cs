public class SocialNetwork
{
    public Dictionary<string, List<string>> UserFriendList { get; set; }

    public SocialNetwork()
    {
        UserFriendList = new Dictionary<string, List<string>>();
    }

    public void AddUser(string name)
    {
        if (HasUser(name))
        {
            Console.WriteLine($"{name} already exists.");
            return;
        }

        if (!UserFriendList.ContainsKey(name))
        {
            UserFriendList[name] = new List<string>();
            Console.WriteLine($"{name} has been added.");
        }
    }

    public Dictionary<string, List<string>> GetNetwork()
    {
        return UserFriendList;
    }

    public void AddFriend(string user1, string user2)
    {
        if (!HasUser(user1) || !HasUser(user2))
        {
            Console.WriteLine($"One or both users do not exist.");
            return;
        }

        if (AreFriends(user1, user2))
        {
            Console.WriteLine($"{user1} and {user2} are already friends.");
            return;
        }

        if (UserFriendList.ContainsKey(user1) && UserFriendList.ContainsKey(user2)) /* if directional delete && AdjacencyList.ContainsKey(vertex2) */
        {
            if (!UserFriendList[user1].Contains(user2))
            {
                UserFriendList[user1].Add(user2);
            }

            // if directional delete this
            if (!UserFriendList[user2].Contains(user1))
            {
                UserFriendList[user2].Add(user1);
            }

            Console.WriteLine($"{user1} and {user2} are now friends.");
        }
    }

    public void RemoveUser(string name)
    {
        if (!HasUser(name))
        {
            Console.WriteLine($"{name} does not exist.");
            return;
        }
        // Remove all edges that contain this vertex
        foreach (var user in UserFriendList.Keys)
        {
            if (UserFriendList[user].Contains(name))
            {
                UserFriendList[user].Remove(name);
            }
        }
        // Remove vertex
        UserFriendList.Remove(name);
        Console.WriteLine($"{name} has been removed from the network.");
    }

    public bool AreFriends(string startVertex, string endVertex)
    {
        return UserFriendList[startVertex].Contains(endVertex);
    }

    public bool HasUser(string vertex)
    {
        return UserFriendList.ContainsKey(vertex);
    }

    public void RemoveFriend(string user1, string user2)
    {
        if (!HasUser(user1) || !HasUser(user2))
        {
            Console.WriteLine($"One or both users do not exist.");
            return;
        }

        if (!AreFriends(user1, user2))
        {
            Console.WriteLine($"{user1} and {user2} are not friends.");
            return;
        }

        UserFriendList[user1].Remove(user2);
        UserFriendList[user2].Remove(user1);
        Console.WriteLine($"{user1} and {user2} are no longer friends.");
    }

    public void DisplayFriends(string p)
    {
        List<string> friends = UserFriendList[p];
        if (!HasUser(p))
        {
            Console.WriteLine($"{p} does not exist.");
            return;
        }
        Console.WriteLine($"{p}'s friends: ");
        foreach (var friend in friends)
        {
            Console.Write($"{friend},");
        }
        if (friends.Count == 0)
        {
            Console.WriteLine($"{p} has no friends");
        }
    }

    public void FindMutualFriends(string user1, string user2)
    {
        List<string> mutualFriends = new();

        if (!HasUser(user1) || !HasUser(user2))
        {
            Console.WriteLine($"One or both users do not exist.");
            return;
        }

        foreach (var friend in UserFriendList[user1])
        {
            if (UserFriendList[user1].Contains(friend)
                && UserFriendList[user2].Contains(friend))
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

    public void SuggestFriends(string user)
    {
        List<string> suggestedFriends = new();
        if (!HasUser(user))
        {
            Console.WriteLine($"{user} does not exist.");
            return;
        }

        foreach (var friend in UserFriendList[user])
        {
            foreach (var f in UserFriendList[friend])
            {
                if (!UserFriendList[user].Contains(f) && f != user)
                {
                    suggestedFriends.Add(f);
                }
            }
        }

        if (suggestedFriends.Count == 0)
        {
            Console.WriteLine($"No suggested friends for {user}.");
            return;
        }

        Console.WriteLine($"Friend suggestions for {user}: ");
        foreach (var friend in suggestedFriends)
        {
            Console.Write($"{friend}, ");
        }
    }
}

//UI in notepad

