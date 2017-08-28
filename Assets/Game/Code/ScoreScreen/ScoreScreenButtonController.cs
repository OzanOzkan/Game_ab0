using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScreenButtonController : ScoreScreenBehavior
{

    public void onShareButtonPressed()
    {

    }

    public void onMainMenuButtonPressed()
    {
        SceneManager.LoadScene(Game.Scenes.MainMenu);
    }

    void Start() { }
}
