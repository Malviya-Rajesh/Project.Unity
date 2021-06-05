using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        foreach(Item item in controller.player.currentLocation.items)
        {
            if(item.itemEnabled && item.itemName == noun)
            {
                if(item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.currentText.text = "you take the" + noun;
                    controller.currentText.text += "\n";
                    return;
                }
            }
        }
        controller.currentText.text = "you can't get that";
        controller.currentText.text += "\n";
    }
}
