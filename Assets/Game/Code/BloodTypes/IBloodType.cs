using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBloodType : ScriptableObject {

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

    protected static Type m_eBloodType;
    protected static Object m_Object;
    protected static string m_sText;
    protected static List<Type> m_bloodExchangeList;
    

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

    public Object GetObject
    {
        get { return m_Object; }
    }
}
