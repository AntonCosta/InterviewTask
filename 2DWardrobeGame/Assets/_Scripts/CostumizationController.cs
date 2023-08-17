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

	public void OpenCostumizationWindow(List<Item> playerItems)
	{
		costumizationScreen.SetActive(true);
		
		//If we previously had an item equipped and now sold it, it is no longer equipped
		//even if we buy it again
		Items.ForEach(item =>
		{
			if (item.gameObject.activeSelf)
			{
				if (!inventoryController.ReturnFullItemList().Contains(item.ItemCode))
				{
					if (item.ItemCode % 9 == 0)
					{
						shoesIndex--;
					}
					else if (item.ItemCode % 9 == 1)
					{
						pantsIndex--;
					}
					else if (item.ItemCode % 9 == 2)
					{
						shirtsIndex--;
					}
					else if (item.ItemCode % 9 == 3)
					{
						hatIndex--;
					}
					item.gameObject.SetActive(false);
				}
				else
				{
					playerItems.ForEach(pItem =>
					{
						if (!pItem.gameObject.activeSelf && pItem.ItemCode == item.ItemCode)
						{
							item.gameObject.SetActive(false);
						}
					});
				}
			}
		});
	}

	public void CloseCostumizationWindow()
	{
		costumizationScreen.SetActive(false);
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
			//This is meant to cover the case in which you are wearing something and sell it to the shop
			//If there are multiple items of one type, let's say Hair, if you sell the hair at index 1 but still have the one at index 2
			//We don't want the index to reset completely or have you press the arrow button multiple times to reach the one you own.
			if (index >= inventoryController.ReturnInventoryList(inventoryIndex).Count)
			{
				index = 0;
			}
			else
			{
				index++;
				if (index >= inventoryController.ReturnInventoryList(inventoryIndex).Count)
				{
					index = 0;
				}
			}
		}
		else
		{
			//Same reasoning as above
			if (index < 0)
			{
				index = inventoryController.ReturnInventoryList(inventoryIndex).Count - 1;
			}
			else
			{
				index--;
				if (index < 0)
				{
					index = inventoryController.ReturnInventoryList(inventoryIndex).Count - 1;
				}
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

		Items.ForEach(item =>
		{
			if (item.ItemCode == itemCode)
			{
				item.gameObject.SetActive(true);
			}
		});
	}
}
