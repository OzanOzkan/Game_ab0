using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCapsule : Game
{
    private IBloodType.Type m_bloodType;

    public IBloodType.Type BloodType { get { return m_bloodType; } set { m_bloodType = value; } }

    // Use this for initialization
    void Start()
    {
        FindObjectOfType<TextMesh>().text = m_bloodType.ToString().ToLower(); 
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log("a");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IBloodType droppedBloodType = collision.gameObject.GetComponent<IBloodType>();

        if (droppedBloodType.canGiveBloodTo(m_bloodType))
            Debug.Log("Can get dropped blood type.");
        else
            droppedBloodType.sendBackToOriginalPosition();
    }
}