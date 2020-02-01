using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite Glue;
    public Sprite Noodle;
    public Sprite Tape;
}
