using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame() => Application.LoadLevel("MainGame");

    public void onClickPlayChara() => Application.LoadLevel("Game");

    public void BackToMenu() => Application.LoadLevel("Menu");

    public void exitGame() => Application.Quit();
}
