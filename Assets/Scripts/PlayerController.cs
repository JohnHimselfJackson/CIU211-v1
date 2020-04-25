using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool playingGame;
    public int movementStrength;

    private bool movingUp = false,
         movingDown = false,
         movingLeft = false,
         movingRight = false,
         draggingCamera = false;
    private Vector2 playerInput;
    private Vector3 mousePosition;

    public GameObject selectedGroup;
    public Joystick playerJoystick;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (playingGame)
        {
            JoystickTest();
            if (selectedGroup != null)
            {
                MoveSelectedGroup();
            }
            GroupSelection();
            CameraZoom();
            Movement();
            CameraDrag();
        }
        
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
        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    if (selectedGroup != null)
        //    {
        //        selectedGroup.GetComponent<GenericGroup>().selected = false;
        //    }
        //    selectedGroup = null;
        //}
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData; 
            if(Physics.Raycast(ray, out hitData))
            {
                if (hitData.collider.gameObject.CompareTag("Group"))
                {
                    if(selectedGroup != null)
                    {
                        selectedGroup.GetComponent<GenericGroup>().selected = false;
                    }
                    selectedGroup = hitData.collider.gameObject;
                    hitData.collider.gameObject.GetComponent<GenericGroup>().selected = true;
                }
            }
            else if(Input.mousePosition.x >645 && Input.mousePosition.y > 960)
            {
                if (selectedGroup != null)
                {
                    selectedGroup.GetComponent<GenericGroup>().selected = false;
                }
                selectedGroup = null;
            }
        }
    }

    void CameraZoom()
    {
        float newcamsize = playerCamera.orthographicSize - Input.mouseScrollDelta.y;
        if (newcamsize > 3 && newcamsize < 15)
        {
            playerCamera.orthographicSize -= Input.mouseScrollDelta.y;
        }
    }

    void Movement()
    {
        #region Getting Input
        if (Input.GetKeyDown(KeyCode.W))
        {
            movingUp = true;
            movingDown = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movingUp = false;
            movingDown = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
            movingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movingLeft = false;
            movingRight = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            movingUp = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movingDown = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movingLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movingRight = false;
        }
        #endregion
        #region Sort Input
        playerInput = new Vector2(0, 0);
        if (movingUp)
        {
            playerInput += new Vector2(0, 1);
        }
        else if (movingDown)
        {
            playerInput += new Vector2(0, -1);
        }

        if (movingLeft & movingRight)
        {
            //does nothings
        }
        else if (movingLeft)
        {
            playerInput += new Vector2(-1, 0);
        }
        else if (movingRight)
        {
            playerInput += new Vector2(1, 0);
        }
        playerInput = playerInput.normalized;
        #endregion
        #region Moving
        GetComponent<Rigidbody2D>().velocity = playerInput * movementStrength;
        #endregion
    }

    void CameraDrag()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            draggingCamera = true;
            mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (draggingCamera)
        {
            transform.position += mousePosition - playerCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        if (Input.GetMouseButtonUp(1))
        {
            draggingCamera = false;
            mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }


    }




}
