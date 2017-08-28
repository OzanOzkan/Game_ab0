using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBloodType : Game {

    public IBloodType() { }

    public enum Type
    {
        Arh = 0,
        Brh,
        ZEROrh,
        ABrh,
        A,
        B,
        ZERO,
        AB,
    }

    private Type m_eBloodType;
    private Object m_Object;
    private Vector2 m_originalPosition;
    private string m_sText;
    private List<Type> m_bloodExchangeList;

    private static GameObject m_currentDraggedBlood;

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

    public static string getBloodTypeAsString(Type type)
    {
        if (type == Type.Arh)
            return "A+";
        else if (type == Type.ABrh)
            return "AB+";
        else if (type == Type.Brh)
            return "B+";
        else if (type == Type.ZEROrh)
            return "0+";
        else if (type == Type.ZERO)
            return "0-";
        else
            return type.ToString() + "-";
    }

    public void Update()
    {
        // Touch drag-drop.
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool isOnBlood = ((GameObject)Object).GetComponent<BoxCollider2D>().OverlapPoint(touchPosition);

        if (isOnBlood && Input.GetMouseButton(0))
        {
            if (!m_currentDraggedBlood)
                m_currentDraggedBlood = ((GameObject)Object);

            if(m_currentDraggedBlood == gameObject)
                ((GameObject)Object).transform.position = new Vector3(touchPosition.x, touchPosition.y);
        }
        else
        {
            m_currentDraggedBlood = null;
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
