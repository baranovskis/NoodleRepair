using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite Glue;
    public GameObject GlueObject;

    public Sprite Noodle;
    public GameObject NoodleObject;

    public Sprite Tape;
    public GameObject TapeObject;

    public Sprite Paint;
    public GameObject PaintObject;
}
