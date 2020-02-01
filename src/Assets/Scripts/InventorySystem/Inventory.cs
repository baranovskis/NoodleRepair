using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
	private readonly List<Item> _items;

	public delegate void ItemChanged(Item item);
	public event ItemChanged OnItemChanged;

	private Item _activeItem;
	public Item ActiveItem
	{
		get { return _activeItem; }
		set
		{
			_activeItem = value;
			OnItemChanged?.Invoke(_activeItem);
		}
	}

	public Inventory()
	{
		_items = new List<Item>();
	}
	
	public void AddItem(Item newItem)
	{
		ActiveItem = newItem;

		if (newItem.IsStackable)
		{
			foreach (var item in _items)
			{
				if (item.Type == newItem.Type)
				{
					ActiveItem = item;
					++item.Amount;
					return;
				}
			}
		}
		_items.Add(newItem);
	}
	
	public void UseItem(Item item)
	{
		if (item.IsStackable)
		{
			if (--item.Amount > 0)
			{
				return;
			}
		}

		_items.Remove(item);
	}

	public Item GetItem(Item.ItemType itemType)
	{
		foreach (var item in _items)
		{
			if (item.Type == itemType)
			{
				return item;
			}
		}
		return null;
	}

	public List<Item> GetItems()
	{
		return _items;
	}

	public bool SelectNextItem()
	{
		if (_items == null)
			return false;

		for (int i = 0; i < _items.Count; i++)
		{
			if (_items[i] == ActiveItem)
			{
				var index = (i + 1 > _items.Count - 1) ? 0 : i + 1;
				ActiveItem = _items[index];
				break;
			}
		}

		return true;
	}

	public bool SelectPrevItem()
	{
		if (_items == null)
			return false;

		for (int i = 0; i < _items.Count; i++)
		{
			if (_items[i] == ActiveItem)
			{
				var index = (i - 1 < 0) ? _items.Count - 1 : i - 1;
				ActiveItem = _items[index];
				break;
			}
		}

		return true;
	}
}
