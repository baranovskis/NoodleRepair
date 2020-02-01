using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Glue,
        Noodle
    }

    public ItemType Type;
    public bool IsStackable;
    public int Amount;

    public Sprite GetSprite()
    {
        switch (Type)
        {
            case ItemType.Glue:
                return ItemAssets.Instance.Glue;
            case ItemType.Noodle:
                return ItemAssets.Instance.Noodle;
        }

        return null;
    }
}
