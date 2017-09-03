using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BloodCapsule : IBloodType
{
    private bool triggered;

    private SoundManager m_soundManager;
    private AudioClip m_audioCorrect;
    private AudioClip m_audioIncorrect;

    public static BloodCapsule CreateInstance(Type bloodType, Vector3 position)
    {
        Object tempObject = Resources.Load("Prefabs/blood_capsule");
        tempObject = Instantiate(tempObject, position, Quaternion.identity);
        ((GameObject)tempObject).AddComponent<BloodCapsule>();

        BloodCapsule parameters = ((GameObject)tempObject).GetComponent<BloodCapsule>();
        parameters.Object = tempObject;
        parameters.OriginalPosition = position;
        parameters.BloodType = bloodType;
        parameters.Text = getBloodTypeAsString(bloodType).ToLower();

        FindObjectOfType<TextMesh>().text = parameters.Text;

        return parameters;
    }

    // Use this for initialization
    void Start()
    {
        triggered = false;

        m_soundManager = GameObject.Find("soundManager").GetComponent<SoundManager>();
        m_audioCorrect = (AudioClip)Resources.Load("Sounds/correct");
        m_audioIncorrect = (AudioClip)Resources.Load("Sounds/incorrect");
    }

    // Update is called once per frame
    new void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered)
        {
            IBloodType droppedBloodType = collision.gameObject.GetComponent<IBloodType>();

            if (droppedBloodType.canGiveBloodTo(BloodType))
            {
                Game.State.CurrentScore += Game.Rules.CorrectAnswerScore;

                if (Game.State.CurrentScore > Game.State.MaxScore)
                    Game.State.MaxScore = Game.State.CurrentScore;

                if (Game.State.CorrectAnswers < 5)
                    ++Game.State.CorrectAnswers;

                m_soundManager.Play(m_audioCorrect);
                SceneManager.LoadScene(Game.Scenes.GameScreen);
            }
            else
            {
                m_soundManager.Play(m_audioIncorrect);
                SceneManager.LoadScene(Game.Scenes.ScoreScreen);
            }

            triggered = true;
        }
    }
}