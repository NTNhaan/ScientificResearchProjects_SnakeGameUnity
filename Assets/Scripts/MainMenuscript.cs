using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuscript : MonoBehaviour
{
    bool isScene1;
    bool isScene2;
    bool isScene3;
    bool isScene4;
    public void Start()
    {
        isScene1 = SceneManager.GetActiveScene().name == "Snake";
        isScene2 = SceneManager.GetActiveScene().name == "SnakeMod";
        isScene3 = SceneManager.GetActiveScene().name == "SnakeFreeMod";
        isScene4 = SceneManager.GetActiveScene().name == "SankeWallMod";
    }
    /////
    public void Playgame()
    {
        SceneManager.LoadScene("Snake");
        Time.timeScale = 1.0f;
    }
    public void SpawnScene()
    {
        SceneManager.LoadScene("SnakeMod");
        Time.timeScale = 1.0f;
    }
    public void FreeMod()
    {
        SceneManager.LoadScene("SnakeFreeMod");
        Time.timeScale = 1.0f;
    }
    public void ObstacleMod()
    {
        SceneManager.LoadScene("SnakeWallMod");
        Time.timeScale = 1.0f;
    }
    public void QuitGame()
    {
        Debug.Log("Quitt!");
        Application.Quit();
    }
}
