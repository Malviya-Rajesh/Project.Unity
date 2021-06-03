using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{

    public string locationName;

    [TextArea]
    public string description;

    public Connection[] connections;

    public List<Item> items = new List<Item>();

    public string GetItemText()
    {
        if (items.Count == 0)
            return "";

        string result = "You see";

        bool first = true;

        foreach(Item item in items)
        {
            if(!first)
                result += " and ";

            result += item.description;
            first = false;
        }

        result += "\n";
        return result;
    }

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
