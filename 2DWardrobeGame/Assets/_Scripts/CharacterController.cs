using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Animator animator;
    private static readonly int MOVE_FLAG = Animator.StringToHash("MoveFlag");

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetInteger(MOVE_FLAG, 1);
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetInteger(MOVE_FLAG, 2);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger(MOVE_FLAG, 3);
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger(MOVE_FLAG, 3);
        }
        else
        {
            animator.SetInteger(MOVE_FLAG, 0);

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
