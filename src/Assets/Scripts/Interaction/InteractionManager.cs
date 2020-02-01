using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private InteractionRayCaster _raycaster;

    void Start()
    {
        _raycaster = Camera.main.GetComponent<InteractionRayCaster>();

        _raycaster.onTargetHit += InteractWithObject;
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
                    InitializeFix();
                    break;
            }
        }
    }

    private void InitializeFix()
    {

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
        var interactableObject = gameObject.GetComponent<InteractableObject>();
        if (interactableObject != null)
        {
            interactableObject.Interact();
        }
    }
}
