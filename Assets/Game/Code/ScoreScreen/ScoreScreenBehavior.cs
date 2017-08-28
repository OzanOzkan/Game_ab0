﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreenBehavior : Game {

    private Text m_txtScore;
    private Text m_txtMaxScore;

	// Use this for initialization
	void Start () {

        m_txtScore = GameObject.Find("txt_score_nr").GetComponent<Text>();
        m_txtScore.text = Game.State.CurrentScore.ToString();

        m_txtMaxScore = GameObject.Find("subtitle_maxscore").GetComponent<Text>();
        m_txtMaxScore.text += Game.State.MaxScore.ToString();

        Game.State.CurrentScore = 0;
	}
}
