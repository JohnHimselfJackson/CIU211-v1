using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject selectedGroup;
    public Joystick playerJoystick;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JoystickTest();
        MoveSelectedGroup();
    }



    void MoveSelectedGroup()
    {
        //get angle
        Vector2 inputDirection = new Vector2(playerJoystick.Horizontal, playerJoystick.Vertical);
        //set move angle
        if(inputDirection.x == 0 && inputDirection.y == 0)
        {
            //return to idle
            SetDirection(0);
        }
        else if(Mathf.Abs(inputDirection.x) > Mathf.Abs(inputDirection.y))
        {
            //moving laterally
            if(inputDirection.x > 0)
            {
                //moving right
                SetDirection(2);
            }
            else
            {
                //moving left
                SetDirection(1);
            }
        }
        else
        {
            //moving veritcally
            if (inputDirection.y > 0)
            {
                //moving up
                SetDirection(4);
            }
            else
            {
                //moving down
                SetDirection(3);
            }
        }
        //move group
        selectedGroup.transform.Translate(inputDirection * Time.deltaTime, Space.World);
    }

    void JoystickTest()
    {
        if(selectedGroup == null)
        {
            playerJoystick.gameObject.SetActive(false);
        }
        else
        {
            playerJoystick.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// idle = 0, moveLeft = 1, moveRight = 2, movingDown = 3, movingUp = 4
    /// </summary>
    void SetDirection(int moveDirection)
    {
        //print(moveDirection);
        for(int nn = 0; nn < selectedGroup.GetComponent<GenericGroup>().npcs.Length; nn++)
        {
            selectedGroup.GetComponent<GenericGroup>().npcs[nn].GetComponent<NPC_Controller>().myCurrentAnim = (NPC_Controller.animationOptions)moveDirection;
        }
    }

    void GroupSelection()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            selectedGroup = null;
        }
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hitData = Physics2D.Raycast(playerCamera.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 100);
            if(hitData == true)
            {
                if (hitData.collider.gameObject.CompareTag("Group"))
                {
                    selectedGroup = hitData.collider.gameObject;
                }
            }
        }
    }




}
