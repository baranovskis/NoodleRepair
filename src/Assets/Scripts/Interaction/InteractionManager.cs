using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private InteractionRayCaster _raycaster;

    private Player _player;

    void Start()
    {
        _raycaster = Camera.main.GetComponent<InteractionRayCaster>();
        _raycaster.onTargetHit += InteractWithObject;

        _player = GetComponent<Player>();
    }

    private void OnDisable()
    {
        _raycaster.onTargetChange -= InteractWithObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InteractWithObject()
    {
        if (_raycaster.Hit.collider != null)
        {
            switch (_raycaster.Hit.collider.tag)
            {
                case "Pickup":
                    Pickup(_raycaster.Hit.collider.gameObject);
                    break;
                case "InteractableObject":
                    Interact(_raycaster.Hit.collider.gameObject);
                    break;
                case "FixableObject":
                    InitiateFix(_raycaster.Hit.collider.gameObject);
                    break;
                case "FixablePart":
                    FixPart(_raycaster.Hit.collider.gameObject);
                    break;
            }

            _player.ArmsAnimator.SetTrigger("Punch");
        }
    }

    private void FixPart(GameObject gameObject)
    {
        var fixManager = GetComponent<FixManager>();

        if (fixManager != null)
        {
            var fixablePart = gameObject.GetComponent<FixablePart>();
            if (fixablePart != null)
            {
                fixManager.FixArea(fixablePart.FixableArea);
            }
        }
    }

    private void InitiateFix(GameObject gameObject)
    {
        var fixManager = GetComponent<FixManager>();

        if (fixManager != null)
        {
            var fixableArea = gameObject.GetComponent<FixableArea>();
            if (fixableArea != null)
            {
                fixManager.FixArea(fixableArea);
            }
        }
    }

    private void Interact(GameObject gameObject)
    {
        var interactableObject = gameObject.GetComponent<InteractableObject>();
        if (interactableObject != null)
        {
            interactableObject.Interact();
        }
    }

    private void Pickup(GameObject gameObject)
    {
        var noodleObject = gameObject.GetComponent<Noodle>();
        if (noodleObject != null)
        {
            var player = GetComponent<Player>();

            player.InventoryUI.AddInventoryItem(new Item
            {
                Type = Item.ItemType.Noodle,
                IsStackable = true
            });
        }

        var glueObject = gameObject.GetComponent<Glue>();
        if (glueObject != null)
        {
            var player = GetComponent<Player>();

            player.InventoryUI.AddInventoryItem(new Item
            {
                Type = Item.ItemType.Glue,
                IsStackable = true
            });
        }

        var flexTapeObject = gameObject.GetComponent<FlexTape>();
        if (flexTapeObject != null)
        {
            var player = GetComponent<Player>();

            player.InventoryUI.AddInventoryItem(new Item
            {
                Type = Item.ItemType.Tape,
                IsStackable = true
            });
        }

        Destroy(_raycaster.Hit.collider.gameObject);
    }
}
