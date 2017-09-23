using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreenBehavior : Game {

	// Use this for initialization
	void Start () {
        Game.Localization.InitLocalization();

        if (Game.SoundSettings.IsSoundOn == 1)
            GameObject.Find("settingsscreen_option_1_btn_title").GetComponent<Text>().text
                += Game.Localization.GetText("text_on");
        else
            GameObject.Find("settingsscreen_option_1_btn_title").GetComponent<Text>().text
                += Game.Localization.GetText("text_off");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
