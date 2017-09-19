using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;

public class ScoreScreenButtonController : ScoreScreenBehavior
{
    private bool rewardBasedEventHandlersSet = false;

    public void onShareButtonPressed()
    {

    }

    public void onMainMenuButtonPressed()
    {
        if (Ad.Count == 1 || Ad.Count == 5)
        {
            Ad.Count++;

            // Unity Ads
            ShowOptions currentOptions = new ShowOptions();
            currentOptions.resultCallback = adVideoFinished;
            Advertisement.Show("endGame", currentOptions);

            //Game.Ad.RequestRewardBasedVideo();

            //if (Game.Ad.isAdRewarded)
            //{
            //    Debug.Log("c");
            //    Game.Ad.isAdRewarded = false;
            //    SceneManager.LoadScene(Game.Scenes.MainMenu);
            //}
            //else
            //{
            //    Debug.Log("d");
            //    SceneManager.LoadScene(Game.Scenes.ScoreScreen);
            //}
        }
        else
        {
            Ad.Count++;
            SceneManager.LoadScene(Game.Scenes.MainMenu);
        }
    }

    // Unity Ads
    void adVideoFinished(ShowResult result)
    {
        if (result == ShowResult.Finished)
            SceneManager.LoadScene(Game.Scenes.MainMenu);
        else
            SceneManager.LoadScene(Game.Scenes.ScoreScreen);
    }



    void Start() { }
}
