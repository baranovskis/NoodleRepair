using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Glue,
        Noodle,
        Tape
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
            case ItemType.Tape:
                return ItemAssets.Instance.Tape;
        }

        return null;
    }

    public GameObject GetGameObject()
    {
        switch (Type)
        {
            case ItemType.Glue:
                return ItemAssets.Instance.GlueObject;
            case ItemType.Noodle:
                return ItemAssets.Instance.NoodleObject;
            case ItemType.Tape:
                return ItemAssets.Instance.TapeObject;
        }

        return null;
    }
}
