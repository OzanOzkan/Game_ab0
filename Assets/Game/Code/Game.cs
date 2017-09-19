using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;

public class Game : MonoBehaviour {

    // Advertisement
    protected static class Ad
    {
        private static int m_adCount = 1;
        public static int Count { get { return m_adCount; } set { m_adCount = value; } }

        private static bool m_rewardBasedEventHandlersSet = false;
        public static bool isAdRewarded { get; set; }
        public static bool isAdFailed { get; set; }

        // Unity Monetize implementation.
        public static void InitAdvertisement()
        {
            const string AdvertisementId = "75d4b971-7374-4a0a-a66e-c646b2c5a7fe";

            //if (!Advertisement.isInitialized)
            //    Advertisement.Initialize(AdvertisementId);
        }
        // End of Unity Monetize implementation.

        // Google Admob implementation.
        public static RewardBasedVideoAd RequestRewardBasedVideo()
        {
            #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-6108754085139921/6725596933";
            #elif UNITY_IPHONE
                string adUnitId = "";
            #else
                string adUnitId = "unexpected_platform";
            #endif

            RewardBasedVideoAd rewardBasedVideo = RewardBasedVideoAd.Instance;

            AdRequest request = new AdRequest.Builder().Build();
            rewardBasedVideo.LoadAd(request, adUnitId);

            if (rewardBasedVideo.IsLoaded())
            {
                rewardBasedVideo.Show();
            }

            if(!m_rewardBasedEventHandlersSet)
            {
                rewardBasedVideo.OnAdLoaded += HandleOnAdLoaded;
                rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
                rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;

                m_rewardBasedEventHandlersSet = true;
            }

            return rewardBasedVideo;
        }

        public static void HandleOnAdLoaded(object sender, System.EventArgs args)
        {
            Debug.Log("OnAdLoaded event received.");
            // Handle the ad loaded event.
        }

        public static void HandleRewardBasedVideoRewarded(object sender, Reward args)
        {
            isAdRewarded = true;
            isAdFailed = false;

            Debug.Log("a");
        }

        public static void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            isAdRewarded = false;
            isAdFailed = true;

            Debug.Log("b");
        }
        // End of Google Admob Implementation.
    }

    // Scenes
    protected static class Scenes
    {
        public static string MainMenu { get { return "MainMenu"; } }
        public static string InfoScreen { get { return "InfoScreen"; } }
        public static string GameScreen { get { return "GameScreen"; } }
        public static string ScoreScreen { get { return "ScoreScreen"; } }
    }

    // Rules
    protected static class Rules
    {
        private static float m_fMoveTimeLimit = 20;
        public static float MoveTimeLimit { get { return m_fMoveTimeLimit; } set { m_fMoveTimeLimit = value; } }

        public static float MoveTimeLimitReduceAmount { get { return 2; } }
        public static float MinReducedTimeLimit { get { return 3; } }
        public static int CorrectAnswerScore { get { return 10; } }

        public static void ResetMoveTime()
        {
            m_fMoveTimeLimit = 20;
        }
    }

    // Difficulty
    protected static class Difficulty
    {
        public enum Levels
        {
            eDL_EASY = 0,
            eDL_MEDIUM,
            eDL_HARD
        }

        private static Difficulty.Levels m_currentDifficulty;
        public static Difficulty.Levels Current
        {
            get { return m_currentDifficulty; }
            set { m_currentDifficulty = value; }
        }
    }

    // States
    protected static class State
    {
        private static int m_iCurrentScore = 0;
        public static int CurrentScore
        {
            get { return m_iCurrentScore; }
            set { m_iCurrentScore = value; }
        }

        private static int m_iMaxScore = 0;
        public static int MaxScore
        {
            get { return m_iMaxScore; }
            set { m_iMaxScore = value; }
        }

        private static int m_iCorrectAnswers = 0;
        public static int CorrectAnswers
        {
            get { return m_iCorrectAnswers; }
            set { m_iCorrectAnswers = value; }
        }

        public static void ResetCurrentScore()
        {
            m_iCurrentScore = 0;
        }
    }
}
