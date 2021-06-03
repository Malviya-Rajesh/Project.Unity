using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{

    public string locationName;

    [TextArea]
    public string description;

    public Connection[] connections;

    public string GetConnectionText()
    {
        string result = "";

        foreach (Connection connection in connections)
        {
            if (connection.connectionEnabled)
                result += connection.description + "\n";
        }
        
        return result;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach(Connection connection in connections)
        {
            if (connection.locationName.ToLower() == connectionNoun.ToLower())
                return connection;
        }
        return null;
    }
}
