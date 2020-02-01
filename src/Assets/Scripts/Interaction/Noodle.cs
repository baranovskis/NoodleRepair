using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noodle : InteractableObject
{
    public override void Interact()
    {
        var playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            var player = playerObject.GetComponent<Player>();

            player.InventoryUI.AddInventoryItem(new Item
            {
                Type = Item.ItemType.Noodle,
                IsStackable = true
            });
        }
    }
}
