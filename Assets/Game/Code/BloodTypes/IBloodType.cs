using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBloodType : Game {

    public IBloodType() { }

    public enum Type
    {
        A = 0,
        Arh,
        B,
        Brh,
        AB,
        ABrh,
        ZERO,
        ZEROrh
    }

    private Type m_eBloodType;
    private Object m_Object;
    private Vector2 m_originalPosition;
    private string m_sText;
    private List<Type> m_bloodExchangeList;

    public Type BloodType
    {
        get { return m_eBloodType; }
        set { m_eBloodType = value; }
    }

    public string Text
    {
        get { return m_sText; }
        set { m_sText = value; }
    }

    public Object Object
    {
        get { return m_Object; }
        set { m_Object = value;}
    }

    public Vector2 OriginalPosition
    {
        get { return m_originalPosition; }
        set { m_originalPosition = value; }
    }

    protected List<Type> BloodExchangeList
    {
        get { return m_bloodExchangeList; }
        set { m_bloodExchangeList = value; }
    }

    public bool canGiveBloodTo(Type bloodType)
    {
        return BloodExchangeList.Contains(bloodType);
    }

    public void sendBackToOriginalPosition()
    {
        ((GameObject)Object).transform.position = new Vector3(m_originalPosition.x, m_originalPosition.y);
    }

    public void Update()
    {
        // Touch drag-drop.
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool isOnBlood = ((GameObject)Object).GetComponent<BoxCollider2D>().OverlapPoint(touchPosition);

        if (isOnBlood && Input.GetMouseButton(0))
        {
            ((GameObject)Object).transform.position = new Vector3(touchPosition.x, touchPosition.y);
        }
        else
        {
            sendBackToOriginalPosition();
        }

        this.OnUpdate();
    }

    protected virtual void OnUpdate()
    {
        // This method can overriden by subclasses if a subclass specific update method needed.
        // Otherwise, void Update() on subclass will hide the update method in this class, which also can be intended.
    }
}
