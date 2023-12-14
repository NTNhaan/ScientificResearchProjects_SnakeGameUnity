using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    bool isScene1;
    bool isScene2;
    bool isScene3;
    bool isScene4;
    bool isScene5;
    bool isScene6;
    bool isScene7;

    [SerializeField] public GameObject PauseMenu;
    public static bool GameisPause = false;

    void Start()
    {
        isScene1 = SceneManager.GetActiveScene().name == "Snake";
        isScene2 = SceneManager.GetActiveScene().name == "SnakeMod";
        isScene3 = SceneManager.GetActiveScene().name == "SnakeFreeMod";
        isScene4 = SceneManager.GetActiveScene().name == "SnakeWallMod";
        isScene5 = SceneManager.GetActiveScene().name == "SnakeWall1";
        isScene6 = SceneManager.GetActiveScene().name == "SnakeWall2";
        isScene7 = SceneManager.GetActiveScene().name == "SnakeWall3";
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameisPause = false;
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPause = true;
    }
    public void Restart()
    {
        PauseMenu.SetActive(false);
        if (isScene1)
        {
            SceneManager.LoadScene("Snake");
        }
        else if (isScene2)
        {
            SceneManager.LoadScene("SnakeMod");
        }
        else if (isScene3)
        {
            SceneManager.LoadScene("SnakeFreeMod");
        }
        else if (isScene4)
        {
            SceneManager.LoadScene("SnakeWallMod");
        }
        else if (isScene5)
        {
            SceneManager.LoadScene("SnakeWallMod");
        }
        else if (isScene6)
        {
            SceneManager.LoadScene("SnakeWallMod");
        }
        else if (isScene7)
        {
            SceneManager.LoadScene("SnakeWallMod");
        }
        Time.timeScale = 1.0f;
    }
}
