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
		InventoryController.AddItem(itemCode);
		ShopItems[itemCode / 9 + itemCode % 9].SetActive(false);
	}

	public void CloseShop()
	{
		shopScreen.SetActive(false);
	}
	
	public void AddItem(int itemCode)
	{
		ShopItems[itemCode / 9 + itemCode % 9].SetActive(true);
	}
}
