using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoScreenButtonController : InfoScreenBehavior {
    
    private int m_iCurrentScreen = 0;

    public void NextButtonPressed()
    {
        if (m_iCurrentScreen < m_lCanvasList.Count - 1)
        {
            m_lCanvasList[m_iCurrentScreen].SetActive(false);
            m_lCanvasList[++m_iCurrentScreen].SetActive(true);
        }

        if(m_iCurrentScreen == m_lCanvasList.Count - 1)
        {
            m_btnNext.SetActive(false);
            m_btnBack.SetActive(true);
        }
    }

    public void BackButtonPressed()
    {
        SceneManager.LoadScene(Scenes.MainMenu);
    }

    void Start() {
    }
}
