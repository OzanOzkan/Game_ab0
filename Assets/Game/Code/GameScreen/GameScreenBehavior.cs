using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenBehavior : Game {

    private float m_fCurrentTimeLeft;
    private GameObject m_txtTimer;
    private GameObject m_txtScore;

    private GameObject m_imgBlood1;
    private GameObject m_imgCapsule;

	// Use this for initialization
	void Start () {

        m_fCurrentTimeLeft = Game.Rules.MoveTimeLimit;
        m_txtTimer = GameObject.Find("txt_timer");
        m_txtScore = GameObject.Find("txt_score");

        m_imgBlood1 = GameObject.Find("blood");
        m_imgCapsule = GameObject.Find("capsule");

        IBloodType myBloodType = CBloodTypeA.CreateInstance(GameObject.Find("blood_position_1").transform.position);
        IBloodType myBloodType2 = CBloodTypeArh.CreateInstance(GameObject.Find("blood_position_2").transform.position);
        IBloodType myBloodType3 = CBloodTypeA.CreateInstance(GameObject.Find("blood_position_3").transform.position);
        IBloodType myBloodType4 = CBloodTypeArh.CreateInstance(GameObject.Find("blood_position_4").transform.position);

        if (myBloodType.BloodType == IBloodType.Type.A)
            Debug.Log("Type A");
    }
	
	// Update is called once per frame
	void Update () {

        if (m_fCurrentTimeLeft > 0)
        {
            m_fCurrentTimeLeft -= Time.deltaTime;
            m_txtTimer.GetComponent<Text>().text = m_fCurrentTimeLeft.ToString("#");


          
        }
        else
        {
            // Time is up.
            m_txtTimer.GetComponent<Text>().text = 0.ToString();
        }
	}
}
