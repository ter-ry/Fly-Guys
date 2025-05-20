using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartTheGame : MonoBehaviour
{
    /*public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        Debug.Log("Button clicked!");
        SceneManager.LoadScene("Level 1");
    }*/

    public void startPage(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
