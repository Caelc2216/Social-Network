public class SocialNetwork
{
    public Dictionary<string, List<string>> UserFriendList { get; set; }

    public SocialNetwork()
    {
        UserFriendList = new Dictionary<string, List<string>>();
    }

    public void AddUser(string vertex)
    {
        if (!UserFriendList.ContainsKey(vertex))
        {
            UserFriendList[vertex] = new List<string>();
        }
    }

    public void AddFriend(string vertex1, string vertex2)
    {
        if (UserFriendList.ContainsKey(vertex1) && UserFriendList.ContainsKey(vertex2)) /* if directional delete && AdjacencyList.ContainsKey(vertex2) */
        {
            if (!UserFriendList[vertex1].Contains(vertex2))
            {
                UserFriendList[vertex1].Add(vertex2);
            }

            // if directional delete this
            if (!UserFriendList[vertex2].Contains(vertex1))
            {
                UserFriendList[vertex2].Add(vertex1);
            }
        }
    }

    public void RemoveUser(string person)
    {
        // Remove all edges that contain this vertex
        foreach (var user in UserFriendList.Keys)
        {
            if(UserFriendList[user].Contains(person))
            {
                UserFriendList[user].Remove(person);
            }
        }
        // Remove vertex
        UserFriendList.Remove(person);
    }

    public bool AreFriends(string startVertex, string endVertex)
    {
        return UserFriendList[startVertex].Contains(endVertex);
    }

    public bool HasUser(string vertex)
    {
        return UserFriendList.ContainsKey(vertex);
    }

    // Breadth-First Search
    public bool BFS(string start, string target)
    {
        Queue<string> queue = new();
        HashSet<string> visited = new ();
        Dictionary<string, string> parent = new ();

        queue.Enqueue(start);
        visited.Add(start);
        parent[start] = null;

        while (queue.Count > 0)
        {
            string currentVertex = queue.Dequeue();

            if (currentVertex == target)
            {
                List<string> path = new List<string>();
                while (currentVertex != null)
                {
                    path.Add(currentVertex);
                    currentVertex = parent[currentVertex];
                }

                path.Reverse();
                Console.Write("Path: ");
                foreach (var item in path)
                {
                    Console.Write($"{item} ");
                }
                return true;
            }

            foreach (var vertex in UserFriendList[currentVertex])
            {
                if (!visited.Contains(vertex))
                {
                    queue.Enqueue(vertex);
                    visited.Add(vertex);
                    parent[vertex] = currentVertex;
                }
            }
        }
        return false;
    }

    // Depth-First Search
    public bool DepthFirstSearch(string start, string target)
    {
        HashSet<string> visited = new HashSet<string>();
        List<string> path = new List<string>();
        return DepthFirstSearchRecursive(start, target, visited, path);
    }

    public bool DepthFirstSearchRecursive(string currentVertex, string target, HashSet<string> visited, List<string> path)
    {
        path.Add(currentVertex);
        visited.Add(currentVertex);

        if (currentVertex == target)
        {
            Console.Write("Path: ");
            foreach (var item in path)
            {
                Console.Write($"{item} ");
            }
            return true;
        }

        foreach (var vertex in UserFriendList[currentVertex])
        {
            if (!visited.Contains(vertex))
            {
                if (DepthFirstSearchRecursive(vertex, target, visited, path))
                {
                    return true;
                }
            }
        }
        return false;
    }

    // public Dictionary<string, string> Dijkstra(string start)
    // {
    //     var distances = new Dictionary<string, string>();
    //     // Priority Queue
    //     var pq = new PriorityQueue<string, string>();
    // }

    public void RemoveFriend(string startVertex, string endVertex)
    {
        UserFriendList[startVertex].Remove(endVertex);
    }

    public void DisplayFriends(string p)
    {
        List<string> friends = UserFriendList[p];
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
}


