using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumizationController : MonoBehaviour
{
	[SerializeField] private InventoryController inventoryController;
	[SerializeField] private GameObject costumizationScreen;
	[SerializeField] private List<Item> Items;

	private int hairIndex = 0;
	private int shirtsIndex = 0;
	private int pantsIndex = 0;
	private int shoesIndex = 0;

	public void OpenCostumizationWindow()
	{
		costumizationScreen.SetActive(true);
	}

	public void CloseCostumizationWindow()
	{
		costumizationScreen.SetActive(false);
	}

	public void ChangeBetweenHairs(bool direction)
	{
		ChangeBetweenItems(GetNextInCarousel(direction, ref hairIndex, 3));
	}

	public void ChangeBetweenShirts(bool direction)
	{
		ChangeBetweenItems(GetNextInCarousel(direction, ref shirtsIndex, 2));
	}

	public void ChangeBetweenPants(bool direction)
	{
		ChangeBetweenItems(GetNextInCarousel(direction, ref pantsIndex, 1));
	}

	public void ChangeBetweenShoes(bool direction)
	{
		ChangeBetweenItems(GetNextInCarousel(direction, ref shoesIndex, 0));
	}

	private int GetNextInCarousel(bool direction, ref int index, int inventoryIndex)
	{
		if (direction)
		{
			index++;
			if (index >= inventoryController.ReturnInventoryList(inventoryIndex).Count)
			{
				index = 0;
			}
			
			return inventoryController.ReturnInventoryList(inventoryIndex)[index];
		}
		else
		{
			index--;
			if (index < 0)
			{
				index = inventoryController.ReturnInventoryList(inventoryIndex).Count - 1;
			}

			return inventoryController.ReturnInventoryList(inventoryIndex)[index];
		}
	}

	private void ChangeBetweenItems(int itemCode)
	{
		if (itemCode == -1)
		{
			Items.ForEach(item => item.gameObject.SetActive(false));
		}
		else if(inventoryController.ReturnFullItemList().Contains(itemCode))
		{
			Items.ForEach(item => item.gameObject.SetActive(false));
			Items.ForEach(item =>
			{
				if (item.ItemCode == itemCode)
				{
					item.gameObject.SetActive(true);
				}
			});
		}
	}
}
