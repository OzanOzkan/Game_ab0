using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;

public class ScoreScreenButtonController : ScoreScreenBehavior
{
    public void onShareButtonPressed()
    {

    }

    public void onMainMenuButtonPressed()
    {
        if (Ad.Count == 3)
        {
            //// Unity Ads
            //ShowOptions currentOptions = new ShowOptions();
            //currentOptions.resultCallback = adVideoFinished;
            //Advertisement.Show("endGame", currentOptions);

            Game.Ad.RequestRewardBasedVideo();

            //if (Game.Ad.isAdRewarded)
            //{
            //    Debug.Log("Game.Ad.isAdRewarded: true");
                //Game.Ad.isAdRewarded = false;
                Ad.Count = 1;

                //SceneManager.LoadScene(Game.Scenes.MainMenu);
            //}
            //else
            //{
            //    Debug.Log("Game.Ad.isAdRewarded: false");
            //    SceneManager.LoadScene(Game.Scenes.ScoreScreen);
            //}
        }
        else
        {
            Ad.Count++;
            //SceneManager.LoadScene(Game.Scenes.MainMenu);
        }

        SceneManager.LoadScene(Game.Scenes.MainMenu);
    }

    //// Unity Ads
    //void adVideoFinished(ShowResult result)
    //{
    //    if (result == ShowResult.Finished)
    //        SceneManager.LoadScene(Game.Scenes.MainMenu);
    //    else
    //        SceneManager.LoadScene(Game.Scenes.ScoreScreen);
    //}



    void Start() { }
}
