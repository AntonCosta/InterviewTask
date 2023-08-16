using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumizationController : MonoBehaviour
{
	[SerializeField] private InventoryController inventoryController;
	[SerializeField] private GameObject costumizationScreen;
	[SerializeField] private List<GameObject> Hairs;
	[SerializeField] private List<GameObject> Shirts;
	[SerializeField] private List<GameObject> Pants;
	[SerializeField] private List<GameObject> Shoes;

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
		ChangeBetweenItems(direction, ref hairIndex, Hairs, 3);
	}

	public void ChangeBetweenShirts(bool direction)
	{
		ChangeBetweenItems(direction, ref shirtsIndex, Shirts, 2);
	}

	public void ChangeBetweenPants(bool direction)
	{
		ChangeBetweenItems(direction, ref pantsIndex, Pants, 1);
	}

	public void ChangeBetweenShoes(bool direction)
	{
		ChangeBetweenItems(direction, ref shoesIndex, Shoes, 0);
	}

	private void ChangeBetweenItems(bool direction, ref int index, List<GameObject> ItemList, int inventoryIndex)
	{
		if (index != 0)
		{
			ItemList[index].SetActive(false);
		}

		if (direction)
		{
			index++;
			if (index >= ItemList.Count || index >= inventoryController.ReturnInventoryList(inventoryIndex).Count)
			{
				index = 0;
			}

			if (index != 0 && index <= inventoryController.ReturnInventoryList(inventoryIndex).Count)
			{
				ItemList[index].SetActive(true);
			}
		}
		else
		{
			index--;
			if (index < 0)
			{
				index = inventoryController.ReturnInventoryList(inventoryIndex).Count - 1;
			}

			if (index != 0 && index <= inventoryController.ReturnInventoryList(inventoryIndex).Count)
			{
				ItemList[index].SetActive(true);
			}
		}
	}
}
