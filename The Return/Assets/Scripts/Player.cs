using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentLocation;

    public List<Item> inventory = new List<Item>();

    public bool ChangeLocation(GameController controller,string connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);

        if(connection != null)
        {
            if(connection.connectionEnabled)
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }
}
