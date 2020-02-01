using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryUI InventoryUI;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new Inventory();
        InventoryUI.SetInventory(_inventory);
    }
}
