using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagerScript : MonoBehaviour
{
    public GameObject playCanvas;
    public GameObject MenuCanvas;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        playCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    public void StartGame()
    {
        pc.playingGame = true;
        playCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }
}
