using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    private Transform _itemContainer;
    private Transform _itemTemplate;

    public Sprite NormalSlot;
    public Sprite ActiveSlot;

    public float ItemCellSize = 75f;

    private void Awake()
    {
        _itemContainer = transform.Find("ItemContainer");
        _itemTemplate = _itemContainer.Find("ItemTemplate");

        _inventory.OnItemChanged += _inventory_OnItemChanged;
    }

    private void _inventory_OnItemChanged(Item item)
    {
        DrawInventory();
    }

    public void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                _inventory.SelectNextItem();
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                _inventory.SelectPrevItem();
            }
        }
    }

    public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;
        DrawInventory();
    }

    public void AddInventoryItem(Item item)
    {
        _inventory.AddItem(item);
        DrawInventory();
    }

    public Item GetItem(Item.ItemType itemType)
    {
        return _inventory.GetItem(itemType);
    }

    private void DrawInventory()
    {
        if (_itemContainer == null)
            return;

        foreach (Transform child in _itemContainer)
        {
            if (child != _itemTemplate)
            {
                Destroy(child.gameObject);
            }
        }

        var items = _inventory.GetItems();
        float pos = items.Count / 2f * -1f;

        foreach (var item in items)
        {
            var itemRect = Instantiate(_itemTemplate, _itemContainer).GetComponent<RectTransform>();

            itemRect.gameObject.SetActive(true);
            itemRect.anchoredPosition = new Vector2(pos * ItemCellSize, 0);

            var icon = itemRect.Find("Icon").GetComponent<Image>();
            icon.sprite = item.GetSprite();

            var bg = itemRect.Find("Bg").GetComponent<Image>();
            bg.sprite = item == _inventory.ActiveItem ? ActiveSlot : NormalSlot;

            ++pos;
        }
    }
}
