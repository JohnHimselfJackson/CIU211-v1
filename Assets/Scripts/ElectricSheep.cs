using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricSheep : MonoBehaviour
{
    GenericGroup conversing;
    int baa = 5;
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void StartBaa()
    {
        StartCoroutine(BaaBaa());
    }

    private void OnTriggerEnter(Collider collision)
    {
        StartCoroutine(Baa());
    }

    IEnumerator Baa()
    {
        gameObject.SetActive(true);

        yield return new WaitForSeconds(50);

        gameObject.SetActive(false);
    }

    IEnumerator BaaBaa()
    {
        gameObject.SetActive(true);

        yield return 20;

        gameObject.SetActive(false);
    }
    
}
