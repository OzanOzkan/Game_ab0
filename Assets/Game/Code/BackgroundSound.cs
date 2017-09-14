using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundSound : Game {

    private static BackgroundSound instance = null;
    public static BackgroundSound Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != Game.Scenes.GameScreen)
        {

        }
    }
}
