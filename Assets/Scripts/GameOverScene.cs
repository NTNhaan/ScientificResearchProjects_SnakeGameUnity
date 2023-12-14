using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    bool isScene1;
    bool isScene2;
    bool isScene3;
    bool isScene4;
    bool isScene5;
    bool isScene6;
    bool isScene7;

    public void Start(){
        // Scene scene = SceneManager.GetActiveScene();
        // if(scene.name == "Snake")
        // {
        //     isScene1 = scene.name;
        // }
        // else if(scene.name == "SnakeMod")
        // {
        //     isScene2 = scene.name;
        // }
        isScene1 = SceneManager.GetActiveScene().name == "Snake";
        isScene2 = SceneManager.GetActiveScene().name == "SnakeMod";
        isScene3 = SceneManager.GetActiveScene().name == "SnakeFreeMod";
        isScene4 = SceneManager.GetActiveScene().name == "SnakeWallMod";
        isScene5 = SceneManager.GetActiveScene().name == "SnakeWall1";
        isScene6 = SceneManager.GetActiveScene().name == "SnakeWall2";
        isScene7 = SceneManager.GetActiveScene().name == "SnakeWall3";
    }
    public void Setup(int Score)
    {
        gameObject.SetActive(true);
    }
    public void Menu(int Score)
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();  //
        gameObject.SetActive(false);
    }
    public void Restart(){ //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameObject.SetActive(false);
        if(isScene1)
        {
            SceneManager.LoadScene("Snake");
        }
        else if(isScene2)
        {
            SceneManager.LoadScene("SnakeMod");
        }
        else if(isScene3)
        {
            SceneManager.LoadScene("SnakeFreeMod");
        }
        else if(isScene4)
        {
            SceneManager.LoadScene("SnakeWallMod");
        }
        else if(isScene5)
        {
            SceneManager.LoadScene("SnakeWallMod");
        }
        else if(isScene6)
        {
            SceneManager.LoadScene("SnakeWallMod");
        }
        else if(isScene7)
        {
            SceneManager.LoadScene("SnakeWallMod");
        }
        Time.timeScale = 1.0f;
    }
    // vấn đề là khi loadscene lại thì timescale của object = 0 đó là lí do khi hold button thì object ko hoạt động
}
