using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenBehavior : Game {

    private float m_fCurrentTimeLeft;
    private Text m_txtTimer;
    private Text m_txtScore;

    // Use this for initialization
    void Start () {

        m_fCurrentTimeLeft = Game.Rules.MoveTimeLimit;
        m_txtTimer = GameObject.Find("txt_timer").GetComponent<Text>();
        m_txtScore = GameObject.Find("txt_score").GetComponent<Text>();

        List<IBloodType> m_generatedBloodTypes = GenerateNewBloodElements();
    }
	
	// Update is called once per frame
	void Update () {

        m_txtScore.text = Game.State.CurrentScore.ToString();

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

    List<IBloodType> GenerateNewBloodElements()
    {
        List<IBloodType> returnList = new List<IBloodType>();

        // Maximum blood type enum index depending to the difficulty level.
        int maxBloodTypeIndex = 0;
        int maxGeneratedBloodTypeCount = 4;

        if (Game.Difficulty.Current == Game.Difficulty.Levels.eDL_EASY)
        {
            maxBloodTypeIndex = 2;
            maxGeneratedBloodTypeCount = 3;
        }
        else if (Game.Difficulty.Current == Game.Difficulty.Levels.eDL_MEDIUM)
            maxBloodTypeIndex = 3;
        else
            maxBloodTypeIndex = 7;
        
        IBloodType.Type bloodTypeForCapsule = (IBloodType.Type)Random.Range(0, maxBloodTypeIndex);
        IBloodType m_bloodCapsule = BloodCapsule.CreateInstance(bloodTypeForCapsule, GameObject.Find("capsule_position").transform.position);

        List<IBloodType.Type> generatedBloodTypes = new List<IBloodType.Type>();

        while(generatedBloodTypes.Count < maxGeneratedBloodTypeCount)
        {
            IBloodType.Type bloodTypeToGenerate = (IBloodType.Type)Random.Range(0, maxBloodTypeIndex);

            if (!generatedBloodTypes.Contains(bloodTypeToGenerate))
                generatedBloodTypes.Add(bloodTypeToGenerate);
        }

        if(!generatedBloodTypes.Contains(bloodTypeForCapsule))
        {
            int indexToChange = Random.Range(0, generatedBloodTypes.Count);
            generatedBloodTypes[indexToChange] = bloodTypeForCapsule;
        }

        int i = 1;
        foreach (IBloodType.Type bloodType in generatedBloodTypes)
        {
            if (bloodType == IBloodType.Type.A)
                returnList.Add(CBloodTypeA.CreateInstance(GameObject.Find("blood_position_" + i.ToString()).transform.position));
            else if (bloodType == IBloodType.Type.Arh)
                returnList.Add(CBloodTypeArh.CreateInstance(GameObject.Find("blood_position_" + i.ToString()).transform.position));
            else if (bloodType == IBloodType.Type.B)
                returnList.Add(CBloodTypeB.CreateInstance(GameObject.Find("blood_position_" + i.ToString()).transform.position));
            else if (bloodType == IBloodType.Type.Brh)
                returnList.Add(CBloodTypeBrh.CreateInstance(GameObject.Find("blood_position_" + i.ToString()).transform.position));
            else if (bloodType == IBloodType.Type.AB)
                returnList.Add(CBloodTypeAB.CreateInstance(GameObject.Find("blood_position_" + i.ToString()).transform.position));
            else if (bloodType == IBloodType.Type.ABrh)
                returnList.Add(CBloodTypeABrh.CreateInstance(GameObject.Find("blood_position_" + i.ToString()).transform.position));
            else if (bloodType == IBloodType.Type.ZERO)
                returnList.Add(CBloodTypeZero.CreateInstance(GameObject.Find("blood_position_" + i.ToString()).transform.position));
            else
                returnList.Add(CBloodTypeZerorh.CreateInstance(GameObject.Find("blood_position_" + i.ToString()).transform.position));

            ++i;
        }

        return returnList;
    }
}
