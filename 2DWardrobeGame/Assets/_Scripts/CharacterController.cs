using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	private static readonly int MOVE_FLAG = Animator.StringToHash("MoveFlag");
	private const float SPEED_MODIFIER = 1f / 80f;

	[SerializeField] private Animator animator;
	private bool shopAvailable = false;
	private bool costumizationAvailable = false;
	private ShopController shopController;
	private CostumizationController costumizationController;

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			animator.SetInteger(MOVE_FLAG, 1);
			transform.position += new Vector3(0f, -1 * SPEED_MODIFIER, 0f);
		}
		else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			animator.SetInteger(MOVE_FLAG, 2);
			transform.position += new Vector3(0f, 1 * SPEED_MODIFIER, 0f);
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			animator.SetInteger(MOVE_FLAG, 3);
			transform.position += new Vector3(1 * SPEED_MODIFIER, 0f, 0f);
		}
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			animator.SetInteger(MOVE_FLAG, 3);
			transform.position += new Vector3(-1 * SPEED_MODIFIER, 0f, 0f);
		}
		else
		{
			animator.SetInteger(MOVE_FLAG, 0);

			transform.eulerAngles = new Vector3(0, 0, 0);
		}

		if (Input.GetKey(KeyCode.E))
		{
			if (shopAvailable)
			{
				shopController.OpenShop();
			}

			if (costumizationAvailable)
			{
				costumizationController.OpenCostumizationWindow();
			}
				
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		var otherShopController = other.GetComponent<ShopController>();
		if (otherShopController != null)
		{
			shopAvailable = true;
			shopController = otherShopController;
		}

		var otherCostumizationController = other.GetComponent<CostumizationController>();
		if (otherCostumizationController != null)
		{
			costumizationAvailable = true;
			costumizationController = otherCostumizationController;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		shopAvailable = false;
		costumizationAvailable = false;
	}
}
