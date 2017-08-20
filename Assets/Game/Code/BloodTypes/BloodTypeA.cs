using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBloodTypeA : IBloodType {

    public static IBloodType CreateInstance(Vector3 position)
    {
        m_eBloodType = Type.A;
        m_sText = "a-";
        m_Object = Resources.Load("Prefabs/blood_dark");
        m_Object = Instantiate(m_Object, position, Quaternion.identity);
        FindObjectOfType<TextMesh>().text = m_sText;

        return ScriptableObject.CreateInstance<CBloodTypeA>();
    }
}

public class CBloodTypeArh : IBloodType
{
    public static IBloodType CreateInstance(Vector3 position)
    {
        m_eBloodType = Type.Arh;
        m_sText = "a+";
        m_Object = Resources.Load("Prefabs/blood_light");
        m_Object = Instantiate(m_Object, position, Quaternion.identity);
        FindObjectOfType<TextMesh>().text = m_sText;

        return ScriptableObject.CreateInstance<CBloodTypeArh>();
    }
}
