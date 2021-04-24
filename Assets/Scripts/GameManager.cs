using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                SceneManager.LoadScene("MainScene");
            }
            else if (SceneManager.GetActiveScene().name == "MainScene")
            {
                SceneManager.LoadScene("MainMenu");
            }
            else if (SceneManager.GetActiveScene().name == "EndScene")
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game_Level");
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How_To_Play");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game_Level");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
