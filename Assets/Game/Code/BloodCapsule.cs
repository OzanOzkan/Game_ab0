using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BloodCapsule : IBloodType
{
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

    }

    // Update is called once per frame
    new void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IBloodType droppedBloodType = collision.gameObject.GetComponent<IBloodType>();

        if (droppedBloodType.canGiveBloodTo(BloodType))
        {
            Game.State.CurrentScore += Game.Rules.CorrectAnswerScore;
            SceneManager.LoadScene(Game.Scenes.GameScreen);
        }
        else
        {
            //SceneManager.LoadScene(Game.Scenes.InfoScreen);
            droppedBloodType.sendBackToOriginalPosition();
        }
    }
}