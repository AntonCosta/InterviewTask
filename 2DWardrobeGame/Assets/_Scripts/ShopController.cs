using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
	[SerializeField] private GameObject shopScreen;
	[SerializeField] private List<GameObject> ShopItems;
	[SerializeField] private InventoryController InventoryController;

	public void OpenShop()
	{
		shopScreen.SetActive(true);
	}

	public void ShopItemPressed(int itemCode)
	{
		if (itemCode / 9 == 0)
		{
			InventoryController.Shoes.Add(0);
		}
		if (itemCode / 9 == 1)
		{
			InventoryController.Pants.Add(0);
		}
		if (itemCode / 9 == 2)
		{
			InventoryController.Shirts.Add(0);
		}
		if (itemCode / 9 == 3)
		{
			InventoryController.Hairs.Add(0);
		}
		ShopItems[itemCode / 9 + itemCode % 9].SetActive(false);
	}

	public void CloseShop()
	{
		shopScreen.SetActive(false);
	}
}
