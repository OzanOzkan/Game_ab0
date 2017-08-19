using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MainMenuBehavior {

    public void InfoButtonPressed()
    {
        SceneManager.LoadScene(Scenes.InfoScreen);
    }

	// Use this for initialization
	void Start () {	}
}
