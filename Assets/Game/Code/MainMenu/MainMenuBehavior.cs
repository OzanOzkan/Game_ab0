using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class MainMenuBehavior : Game {

	// Use this for initialization
	void Start () {
        Game.Ad.InitAdMob();
        Game.Localization.InitLocalization();
        Game.SoundSettings.InitSoundSettings();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
