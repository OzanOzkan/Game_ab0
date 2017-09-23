using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScreenButtonController : SettingsScreenBehavior {

    public void onMainMenuButtonPressed()
    {
        SceneManager.LoadScene(Game.Scenes.MainMenu);
    }
    
    public void onSoundButtonPressed()
    {
        if (Game.SoundSettings.IsSoundOn == 1)
            Game.SoundSettings.IsSoundOn = 0;
        else
            Game.SoundSettings.IsSoundOn = 1;

        SceneManager.LoadScene(Game.Scenes.SettingsScreen);
    }

    public void onLanguageButtonPressed()
    {
        if (Game.Localization.CurrentLanguage == "English")
            Game.Localization.SetLanguage("Turkish");
        else
            Game.Localization.SetLanguage("English");

        SceneManager.LoadScene(Game.Scenes.SettingsScreen);
    }
}
