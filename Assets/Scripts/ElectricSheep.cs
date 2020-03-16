using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricSheep : MonoBehaviour
{
    bool deactivating = false;
    // Update is called once per frame
    void Update()
    {
        StateChecker();
    }

    void SetBubbleActive()
    {
        gameObject.SetActive(false);
        deactivating = false;
    }


    void StateChecker()
    {
        if(gameObject.activeInHierarchy == true && !deactivating)
        {
            Invoke("SetBubbleActive", 0.5f);
            deactivating = true;
        }
    }
}
