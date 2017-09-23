using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreenBehavior : Game {

    protected static List<GameObject> m_lCanvasList;
    protected static GameObject m_btnNext;
    protected static GameObject m_btnBack;

    // Use this for initialization
    void Start () {
        // Localization Texts
        Game.Localization.InitLocalization();

        //GameObject.Find("subtitle_info").GetComponent<Text>().text
        //    = Game.Localization.GetText(Application.systemLanguage.ToString(), "infoscreen_subtitle_1");
        //GameObject.Find("subtitle_info").GetComponent<Text>().text
        //    = Game.Localization.GetText(Application.systemLanguage.ToString(), "infoscreen_subtitle_1");

        // Initialize the canvas list
        m_lCanvasList = new List<GameObject>();

        // Fill the list.
        int i = 1;
        GameObject currentCanvas;

        while ((currentCanvas = GameObject.Find("canvas_info_" + i.ToString())) != null)
        {
            currentCanvas.SetActive(false);
            m_lCanvasList.Add(currentCanvas);
            ++i;
        }

        // Set the first canvas active.
        m_lCanvasList[0].SetActive(true);

        // Get the next button.
        m_btnNext = GameObject.Find("btn_next");
        m_btnBack = GameObject.Find("btn_back");
        m_btnBack.SetActive(false);
    }
}
