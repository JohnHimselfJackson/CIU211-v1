using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManagerScript : MonoBehaviour
{
    public GameObject playCanvas;
    public GameObject menuCanvas;
    public GameObject endCanvas;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        playCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        endCanvas.SetActive(false);
    }

    public void StartGame()
    {
        pc.playingGame = true;
        playCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }
    public void ReLoad()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void GameWon()
    {
        playCanvas.SetActive(false);
        endCanvas.SetActive(true);

    }
}
