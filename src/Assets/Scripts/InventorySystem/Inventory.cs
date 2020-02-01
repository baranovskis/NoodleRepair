using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
	private readonly List<Item> _items;

	public Inventory()
	{
		_items = new List<Item>();
	}
	
	public void AddItem(Item newItem)
	{
		if (newItem.IsStackable)
		{
			foreach (var item in _items)
			{
				if (item.Type == newItem.Type)
				{
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
}
