using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MainMenuBehavior {

    public void OnInfoButtonPressed()
    {
        SceneManager.LoadScene(Scenes.InfoScreen);
    }

    public void OnEasyButtonPressed()
    {
        Game.Difficulty.Current = Difficulty.Levels.eDL_EASY;
        SceneManager.LoadScene(Scenes.GameScreen);
    }

    public void OnMediumButtonPressed()
    {
        Game.Difficulty.Current = Difficulty.Levels.eDL_MEDIUM;
        SceneManager.LoadScene(Scenes.GameScreen);
    }

    public void OnHardButtonPressed()
    {
        Game.Difficulty.Current = Difficulty.Levels.eDL_HARD;
        SceneManager.LoadScene(Scenes.GameScreen);
    }
}
