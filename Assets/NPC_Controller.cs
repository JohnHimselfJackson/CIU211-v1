using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (GetComponent<Animator>())
            {
                GetComponent<Animator>().SetInteger("moveState", (int)_myCurrentAnim);
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
        print((int)myCurrentAnim);
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
