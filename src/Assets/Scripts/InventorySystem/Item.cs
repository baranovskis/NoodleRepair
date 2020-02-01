using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Glue,
        Noodle,
        Tape,
        Paint
    }

    public ItemType Type;
    public bool IsStackable;
    public int Amount = 1;

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
            case ItemType.Paint:
                return ItemAssets.Instance.Paint;
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
            case ItemType.Paint:
                return ItemAssets.Instance.PaintObject;
        }

        return null;
    }
}
