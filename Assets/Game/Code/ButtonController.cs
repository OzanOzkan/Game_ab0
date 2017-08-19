using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void EasyPressed()
    {
        Debug.Log("Easy");
    }

    public void NormalPressed()
    {
        Debug.Log("Normal");
    }
    
    public void HardPressed()
    {
        Debug.Log("Hard");
    }

    public void InfoPressed()
    {
        Debug.Log("Info");
    }

    public void SettingsPressed()
    {
        Debug.Log("Settings");
    }
}
