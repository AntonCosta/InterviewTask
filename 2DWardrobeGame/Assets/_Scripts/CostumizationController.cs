using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumizationController : MonoBehaviour
{
	[SerializeField] private InventoryController inventoryController;
	[SerializeField] private GameObject costumizationScreen;
	[SerializeField] private List<Item> Items;

	private int hatIndex = 0;
	private int shirtsIndex = 0;
	private int pantsIndex = 0;
	private int shoesIndex = 0;

	private List<Item> playerItems;

	public void OpenCostumizationWindow(List<Item> items)
	{
		costumizationScreen.SetActive(true);
		playerItems = items;
		
		//If we previously had an item equipped and now sold it, it is no longer equipped
		Items.ForEach(item =>
		{
			if (item.gameObject.activeSelf)
			{
				if (!inventoryController.ReturnFullItemList().Contains(item.ItemCode))
				{
					//TODO: indexes also need to be reset, might be able to refactor after equipping items on the character
					item.gameObject.SetActive(false);
				}
			}
		});
	}

	public void CloseCostumizationWindow()
	{
		costumizationScreen.SetActive(false);
		playerItems = new List<Item>();
	}

	public void ChangeBetweenHairs(bool direction)
	{
		ChangeBetweenItems(direction, ref hatIndex, 3);
	}

	public void ChangeBetweenShirts(bool direction)
	{
		ChangeBetweenItems(direction, ref shirtsIndex, 2);
	}

	public void ChangeBetweenPants(bool direction)
	{
		ChangeBetweenItems(direction, ref pantsIndex, 1);
	}

	public void ChangeBetweenShoes(bool direction)
	{
		ChangeBetweenItems(direction, ref shoesIndex, 0);
	}

	private void ChangeBetweenItems(bool direction, ref int index, int inventoryIndex)
	{
		if (direction)
		{
			index++;
			if (index >= inventoryController.ReturnInventoryList(inventoryIndex).Count)
			{
				index = 0;
			}
		}
		else
		{
			index--;
			if (index < 0)
			{
				index = inventoryController.ReturnInventoryList(inventoryIndex).Count - 1;
			}
		}
		
		var itemCode = inventoryController.ReturnInventoryList(inventoryIndex)[index];
		
		
		Items.ForEach(item =>
		{
			if (item.ItemCode / 9 == inventoryIndex % 9)
			{
				item.gameObject.SetActive(false);
			}
		});
		
		playerItems.ForEach(item =>
		{
			if (item.ItemCode / 9 == inventoryIndex % 9)
			{
				item.gameObject.SetActive(false);
			}
		});

		Items.ForEach(item =>
		{
			if (item.ItemCode == itemCode)
			{
				item.gameObject.SetActive(true);
			}
		});
		
		playerItems.ForEach(item =>
		{
			if (item.ItemCode == itemCode)
			{
				item.gameObject.SetActive(true);
			}
		});
		
	}
}
