﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryUI InventoryUI;

    public TaskSystemUI TaskSystemUI;

    public Transform HoldItemPosition;

    public Animator ArmsAnimator;

    private Inventory _inventory;

    private TaskSystem _taskSystem;

    private FPMovementController _movementController;

    private GameObject _activeItem;

    private void Awake()
    {
        _inventory = new Inventory();
        _inventory.OnItemChanged += _inventory_OnItemChanged;
        InventoryUI.SetInventory(_inventory);

        _taskSystem = new TaskSystem();
        TaskSystemUI.SetTaskSystem(_taskSystem);

        _movementController = GetComponent<FPMovementController>();
    }

    private void _inventory_OnItemChanged(Item item)
    {
        if (_activeItem != null)
        {
            Destroy(_activeItem);
            _activeItem = null;
        }

        if (item == null)
        {
            return;
        }

        var obj = item.GetGameObject();

        _activeItem = Instantiate(obj, HoldItemPosition.transform.position, obj.transform.rotation);
        _activeItem.transform.parent = HoldItemPosition;
    }

    public void Update()
    {
        ArmsAnimator.SetBool("ItemEquipped", _inventory.ActiveItem != null);
        ArmsAnimator.SetBool("IsRunning", _movementController.IsRunning);
    }
}
