using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenBehavior : Game {

    private float m_fCurrentTimeLeft;
    private Text m_txtTimer;
    private Text m_txtScore;

    private GameObject m_bloodCapsule;

    // Use this for initialization
    void Start () {

        m_fCurrentTimeLeft = Game.Rules.MoveTimeLimit;
        m_txtTimer = GameObject.Find("txt_timer").GetComponent<Text>();
        m_txtScore = GameObject.Find("txt_score").GetComponent<Text>();

        IBloodType myBloodType = CBloodTypeA.CreateInstance(GameObject.Find("blood_position_1").transform.position);
        IBloodType myBloodType2 = CBloodTypeArh.CreateInstance(GameObject.Find("blood_position_2").transform.position);
        IBloodType myBloodType3 = CBloodTypeB.CreateInstance(GameObject.Find("blood_position_3").transform.position);
        IBloodType myBloodType4 = CBloodTypeBrh.CreateInstance(GameObject.Find("blood_position_4").transform.position);

        m_bloodCapsule = (GameObject)Resources.Load("Prefabs/blood_capsule");
        m_bloodCapsule = Instantiate(m_bloodCapsule, GameObject.Find("capsule_position").transform.position, Quaternion.identity);
        m_bloodCapsule.GetComponent<BloodCapsule>().BloodType = IBloodType.Type.A;
    }
	
	// Update is called once per frame
	void Update () {

        m_txtScore.text = "0";

        if (m_fCurrentTimeLeft > 0)
        {
            m_fCurrentTimeLeft -= Time.deltaTime;
            m_txtTimer.text = m_fCurrentTimeLeft.ToString("#");
        }
        else
        {
            // Time is up.
            m_txtTimer.text = 0.ToString();
        }
	}
}
