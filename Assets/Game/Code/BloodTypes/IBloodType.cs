using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBloodType : ScriptableObject {

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
}
