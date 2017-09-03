using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class ScoreScreenButtonController : ScoreScreenBehavior
{

    public void onShareButtonPressed()
    {

    }

    public void onMainMenuButtonPressed()
    {
        ShowOptions currentOptions = new ShowOptions();
        currentOptions.resultCallback = adVideoFinished;
        Advertisement.Show("endGame", currentOptions);
    }

    void adVideoFinished(ShowResult result)
    {
        if (result == ShowResult.Finished)
            SceneManager.LoadScene(Game.Scenes.MainMenu);
        else
            SceneManager.LoadScene(Game.Scenes.ScoreScreen);
    }

    void Start() { }
}
