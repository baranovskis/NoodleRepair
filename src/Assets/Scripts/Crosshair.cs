using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct CrosshairSize
{
    public Vector2 Small;
    public Vector2 Medium;
    public Vector2 Big;
}


public class Crosshair : MonoBehaviour
{

    // Sprites
    [Header("Icons")]
    [SerializeField]
    private Sprite PickupSprite;
    [SerializeField]
    private Sprite InteractableObjectSprite;
    [SerializeField]
    private Sprite CrosshairSprite;
    [SerializeField]
    private Sprite FixableObjectSprite;

    // Crosshair image
    private Image img;
    public CrosshairSize CrosshairSize = new CrosshairSize();

    [SerializeField]
    private InteractionRayCaster _raycaster;

    // Use this for initialization
    void Start()
    {
        _raycaster = Camera.main.GetComponent<InteractionRayCaster>();

        _raycaster.onTargetChange += ChangeCrosshair;
        _raycaster.onNoTarget += ChangeCrosshair;

        img = gameObject.GetComponent<Image>();
    }

    private void OnDisable()
    {
        _raycaster.onTargetChange -= ChangeCrosshair;
        _raycaster.onNoTarget -= ChangeCrosshair;
    }

    void ChangeCrosshair()
    {
        if (_raycaster.Hit.collider != null)
        {
            switch (_raycaster.Hit.collider.tag)
            {
                case "Pickup":
                    SetIcon(PickupSprite);
                    SetSize(CrosshairSize.Medium);
                    break;
                case "InteractableObject":
                    SetIcon(InteractableObjectSprite);
                    SetSize(CrosshairSize.Medium);
                    break;
                case "FixableObject":
                    SetIcon(FixableObjectSprite);
                    SetSize(CrosshairSize.Medium);
                    break;
                default:
                    SetIcon(CrosshairSprite);
                    SetSize(CrosshairSize.Medium);
                    break;
            }
        }
        else
        {
            SetIcon(CrosshairSprite);
            SetSize(CrosshairSize.Medium);
            return;
        }
    }

    void SetIcon(Sprite icon)
    {
        img.sprite = icon;
    }

    void SetSize(Vector2 size)
    {
        img.GetComponent<RectTransform>().sizeDelta = size;
    }

}
