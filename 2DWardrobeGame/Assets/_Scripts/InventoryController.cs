using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryController : MonoBehaviour
{
	[SerializeField] private GameObject inventoryScreen;
	[SerializeField] private List<GameObject> InventoryItems;
	[SerializeField] private ShopController shopController;

	private List<int> Items;
	[HideInInspector] public List<int> Hats;
	[HideInInspector] public List<int> Shirts;
	[HideInInspector] public List<int> Pants;
	[HideInInspector] public List<int> Shoes;

	private void Start()
	{
		Hats = new List<int>(){-1};
		Shirts = new List<int>(){-1};
		Pants = new List<int>(){-1};
		Shoes = new List<int>(){-1};
		Items = new List<int>();
	}

	public List<int> ReturnInventoryList(int index)
	{
		if (index == 0)
		{
			return Shoes;
		}
		
		if (index == 1)
		{
			return Pants;
		}
		
		if (index == 2)
		{
			return Shirts;
		}
		
		return Hats;
	}
	
	public List<int> ReturnFullItemList()
	{
		return Items;
	}

	public void AddItem(int itemCode)
	{
		//Shop items are arranged by columns for shoes, pants, shirts and hairs
		if (itemCode / 9 == 0)
		{
			Shoes.Add(itemCode);
		}
		if (itemCode / 9 == 1)
		{
			Pants.Add(itemCode);
		}
		if (itemCode / 9 == 2)
		{
			Shirts.Add(itemCode);
		}
		if (itemCode / 9 == 3)
		{
			Hats.Add(itemCode);
		}
		InventoryItems[itemCode / 9 + itemCode % 9].SetActive(true);
		Items.Add(itemCode);
	}
	
	public void InventoryItemPressed(int itemCode)
	{
		if (itemCode / 9 == 0)
		{
			Shoes.Remove(itemCode);
		}
		if (itemCode / 9 == 1)
		{
			Pants.Remove(itemCode);
		}
		if (itemCode / 9 == 2)
		{
			Shirts.Remove(itemCode);
		}
		if (itemCode / 9 == 3)
		{
			Hats.Remove(itemCode);
		}

		shopController.AddItem(itemCode);
		InventoryItems[itemCode / 9 + itemCode % 9].SetActive(false);
		Items.Remove(itemCode);
	}

	public void OpenInventory()
	{
		inventoryScreen.SetActive(true);
	}
	
	public void CloseInventory()
	{
		inventoryScreen.SetActive(false);
	}
}
