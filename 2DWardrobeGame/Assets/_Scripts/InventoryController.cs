using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
	[HideInInspector] public List<int> Hairs;
	[HideInInspector] public List<int> Shirts;
	[HideInInspector] public List<int> Pants;
	[HideInInspector] public List<int> Shoes;

	private void Start()
	{
		Hairs = new List<int>(){0};
		Shirts = new List<int>(){0};
		Pants = new List<int>(){0};
		Shoes = new List<int>(){0};
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
		
		return Hairs;
	}
}
