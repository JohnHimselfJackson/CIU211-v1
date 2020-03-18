using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPC_Controller : MonoBehaviour
{
    public Animator anim;

    public enum animationOptions {idle, movingLeft, movingRight, movingDown, movingUp, conversing }; // idle = 0, moveLeft = 1, moveRight = 2, movingDown = 3, movingUp = 4, conversing = 5;
    private animationOptions _myCurrentAnim;
    public animationOptions myCurrentAnim
    {
        get
        {
            return _myCurrentAnim;
        }
        set
        {
            _myCurrentAnim = value;
            if (anim)
            {
                anim.SetInteger("moveState", (int)_myCurrentAnim);
            }

            if (value == 0)
            {

            }
            else if ((int)value == 1)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetInteger("moveState", 0);
        //InvokeRepeating("NextAnimation", 1f, 4f);
    }




    void NextAnimation()
    {
        myCurrentAnim = (animationOptions)(OverflowCheck((int)myCurrentAnim + 1));
    }

    int OverflowCheck(int numToCheck)
    {
        if(numToCheck < 0 || numToCheck > 5)
        {
            return 0;
        }
        else
        {
            return numToCheck;
        }
    }




}
