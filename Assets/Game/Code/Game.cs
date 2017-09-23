using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;

public class Game : MonoBehaviour {

    #region Advertisement
    protected static class Ad
    {
        private static int m_adCount = 1;
        public static int Count { get { return m_adCount; } set { m_adCount = value; } }

        #region Unity Monetize Implementation
        public static void InitAdvertisement()
        {
            //const string AdvertisementId = "75d4b971-7374-4a0a-a66e-c646b2c5a7fe";

            //if (!Advertisement.isInitialized)
            //    Advertisement.Initialize(AdvertisementId);
        }
        #endregion

        #region Google AdMob Implementation
        private static RewardBasedVideoAd rewardBasedVideo = RewardBasedVideoAd.Instance;
        private static bool m_rewardBasedEventHandlersSet = false;
        public static bool isAdRewarded { get; set; }
        public static bool isAdFailed { get; set; }
        private static bool isAdInitialized = false;
        
        public static void InitAdMob()
        {
            //if (isAdInitialized)
            //    return;

            #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-6108754085139921/6725596933";
            #elif UNITY_IPHONE
                string adUnitId = "";
            #else
                string adUnitId = "unexpected_platform";
            #endif

            if (!m_rewardBasedEventHandlersSet)
            {
                rewardBasedVideo.OnAdLoaded += HandleOnAdLoaded;
                rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
                rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;

                m_rewardBasedEventHandlersSet = true;
            }

            AdRequest request = new AdRequest.Builder()
                .Build();

            rewardBasedVideo.LoadAd(request, adUnitId);

            isAdInitialized = true;
        }

        public static RewardBasedVideoAd RequestRewardBasedVideo()
        {
            if (rewardBasedVideo.IsLoaded())
            {
                rewardBasedVideo.Show();
            }

            return rewardBasedVideo;
        }

        public static void HandleOnAdLoaded(object sender, System.EventArgs args)
        {
            Debug.Log("Game.Ad.HandleOnAdLoaded");
        }

        public static void HandleRewardBasedVideoRewarded(object sender, Reward args)
        {
            isAdRewarded = true;
            isAdFailed = false;

            Debug.Log("Game.Ad.HandleRewardBasedVideoRewarded");
        }

        public static void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            isAdRewarded = false;
            isAdFailed = true;

            Debug.Log("Game.Ad.HandleRewardBasedVideoFailedToLoad");
        }
        #endregion
    }
    #endregion

    #region Scenes
    protected static class Scenes
    {
        public static string MainMenu { get { return "MainMenu"; } }
        public static string InfoScreen { get { return "InfoScreen"; } }
        public static string GameScreen { get { return "GameScreen"; } }
        public static string ScoreScreen { get { return "ScoreScreen"; } }
        public static string SettingsScreen { get { return "SettingsScreen"; } }
    }
    #endregion

    #region Rules
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
    #endregion

    #region Difficulty
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
    #endregion

    #region States
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
    #endregion

    #region Localization
    public static class Localization
    {
        private static string m_currentLanguage;
        public static string CurrentLanguage { get { return m_currentLanguage; } }
        private static Dictionary<string, Dictionary<string, string>> m_dTexts;
        private static bool isLocalizationInitialized = false;

        public static void InitLocalization()
        {
            if (!isLocalizationInitialized)
            {
                Dictionary<string, string> tr_TR = new Dictionary<string, string> {
                    { "game_title", "ab0" },
                    { "mainmenu_subtitle_1", "Seviye Seçiniz" },
                    { "mainmenu_button_easy", "kolay" },
                    { "mainmenu_button_medium", "normal" },
                    { "mainmenu_button_hard", "zor" },
                    { "infoscreen_subtitle_1", "Biraz Bilgi Edinelim" },
                    { "infoscreen_info_1_title", "Gruplar" },
                    { "infoscreen_info_1_body", "a\nb\nab\n0" },
                    { "infoscreen_info_2_title", "RH Faktörü" },
                    { "infoscreen_info_2_body", "Rhesus (Rh), kan dolaşımında alyuvarların yüzeyinde bulunan bir proteine verilen isimdir. Eğer kişinin kanında bulunuyorsa, kan grubu yanına Rh pozitif (+) yazılır. Kanda bu faktör yoksa, kişi Rh negatif (-) kan grubuna sahiptir." },
                    { "infoscreen_info_3_title", "RH Faktörü ile Gruplar" },
                    { "infoscreen_info_3_body", "a+, a-\nb+, b-\nab+, ab-\n0+, 0-" },
                    { "infoscreen_info_4_title", "Temel Bilgiler" },
                    { "infoscreen_info_4_body", "Negatif (-) olan guruplar asla pozitif (+) guruplara veremezler.\n\nA grubu, B grubuna veya B grubu A grubuna kan veremez ve alamazlar.\n\n0 gurubu zor durumlarda tüm guruplara verebilir ama alamazlar.\n\nAb gurubu ise zor durumlarda tüm gruplardan alabilir." },
                    { "infoscreen_button_back", "Geri" },
                    { "scorescreen_title", "Tebrikler!" },
                    { "scorescreen_subtitle_1", "Skorunuz" },
                    { "scorescreen_subtitle_2", "En yüksek skor: " },
                    { "settingsscreen_title", "Ayarlar" },
                    { "settingsscreen_option_1_btn_title", "Ses : " },
                    { "settingsscreen_option_2_btn_title", "Dil : Türkçe" },
                    { "text_on", "Açık" },
                    { "text_off", "Kapalı" },
                };

                Dictionary<string, string> en_US = new Dictionary<string, string> {
                    { "game_title", "ab0" },
                    { "mainmenu_subtitle_1", "Choose Your Level" },
                    { "mainmenu_button_easy", "easy" },
                    { "mainmenu_button_medium", "normal" },
                    { "mainmenu_button_hard", "hard" },
                    { "infoscreen_subtitle_1", "Groups in a Nutshell" },
                    { "infoscreen_info_1_title", "Groups" },
                    { "infoscreen_info_1_body", "a\nb\nab\n0" },
                    { "infoscreen_info_2_title", "RH Factor" },
                    { "infoscreen_info_2_body", "Rhesus (Rh) factor is an inherited protein found on the surface of red blood cells. If your blood has the protein, you're Rh positive (+). If your blood has not the protein, you're Rh negative (-)." },
                    { "infoscreen_info_3_title", "Groups with RH Factor" },
                    { "infoscreen_info_3_body", "a+, a-\nb+, b-\nab+, ab-\n0+, 0-" },
                    { "infoscreen_info_4_title", "Basic Information" },
                    { "infoscreen_info_4_body", "Negative (-) blood groups cannot give blood to positive (+) blood groups.\n\nA group cannot give or get blood to/from B group or vice-versa.\n\n0 group can give blood to all groups in upmost emergency situations, but cannot get blood from other different groups.\n\nAb group can get blood from other groups in upmost emergency situations." },
                    { "infoscreen_button_back", "Back" },
                    { "scorescreen_title", "Way to Go!" },
                    { "scorescreen_subtitle_1", "Your Score" },
                    { "scorescreen_subtitle_2", "Best score: " },
                    { "settingsscreen_title", "Settings" },
                    { "settingsscreen_option_1_btn_title", "Sounds : " },
                    { "settingsscreen_option_2_btn_title", "Language : English" },
                    { "text_on", "On" },
                    { "text_off", "Off" },
                };

                m_dTexts = new Dictionary<string, Dictionary<string, string>>
                {
                    { "English", en_US },
                    { "Turkish", tr_TR }
                };

                if (!PlayerPrefs.HasKey("ab0_language"))
                {
                    if (Application.systemLanguage.ToString() == "Turkish")
                        m_currentLanguage = "Turkish";
                    else
                        m_currentLanguage = "English";

                    PlayerPrefs.SetString("ab0_language", m_currentLanguage);
                }

                m_currentLanguage = PlayerPrefs.GetString("ab0_language");

                isLocalizationInitialized = true;
            }

            Text[] texts = GameObject.FindObjectsOfType<Text>();
            foreach (Text text in texts)
            {
                string localizedText = GetText(text.name);

                if (localizedText != "")
                    text.text = localizedText;
            }
        }

        public static string GetText(string language, string key)
        {
            Dictionary<string, string> tempLangTree;
            if (!m_dTexts.TryGetValue(language, out tempLangTree))
                language = "English";

            m_dTexts.TryGetValue(language, out tempLangTree);

            string returnValue = "";
            tempLangTree.TryGetValue(key, out returnValue);

            if (returnValue != "")
                return returnValue;

            return "";
        }

        public static string GetText(string key)
        {
            Dictionary<string, string> tempLangTree;
            m_dTexts.TryGetValue(m_currentLanguage, out tempLangTree);

            string returnValue = "";
            if (tempLangTree.TryGetValue(key, out returnValue))
                return returnValue;

            return "";
        }

        public static bool SetLanguage(string language)
        {
            PlayerPrefs.SetString("ab0_language", language);
            m_currentLanguage = language;

            return true;
        }
    }
    #endregion

    #region Sound Settings
    public static class SoundSettings
    {
        private static int m_IsSoundOn = 1;
        public static int IsSoundOn
        {
            get { return m_IsSoundOn; }
            set
            {
                m_IsSoundOn = value;
                PlayerPrefs.SetInt("ab0_soundsetting", value);
            }
        }

        public static void InitSoundSettings()
        {
            if(!PlayerPrefs.HasKey("ab0_soundsetting"))
            {
                PlayerPrefs.SetInt("ab0_soundsetting", 1);
            }

            m_IsSoundOn = PlayerPrefs.GetInt("ab0_soundsetting");
        }
    }
    #endregion
}
