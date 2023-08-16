using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{

    [SerializeField] private GameObject shopScreen;
    [SerializeField] private List<GameObject> ShopItems;

    public void OpenShop()
    {
        shopScreen.SetActive(true);
    }

    public void ShopItemPressed(int itemCode)
    {
        ShopItems[itemCode].SetActive(false);
    }

    public void CloseShop()
    {
        shopScreen.SetActive(false);
    }
}
