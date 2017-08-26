using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBloodTypeB : IBloodType
{
    public CBloodTypeB() { }

    protected void Initialize(Vector3 position)
    {
        BloodType = Type.B;
        Text = "b-";
        Object = Resources.Load("Prefabs/blood_dark");
        Object = Instantiate(Object, position, Quaternion.identity);
        FindObjectOfType<TextMesh>().text = Text;
    }

    public static CBloodTypeB CreateInstance(Vector3 position)
    {
        CBloodTypeB returnInstance = (CBloodTypeB)ScriptableObject.CreateInstance(typeof(CBloodTypeB));
        returnInstance.Initialize(position);

        return returnInstance;
    }
}

public class CBloodTypeBrh : IBloodType
{
    public CBloodTypeBrh() { }

    protected void Initialize(Vector3 position)
    {
        BloodType = Type.Brh;
        Text = "b+";
        Object = Resources.Load("Prefabs/blood_light");
        Object = Instantiate(Object, position, Quaternion.identity);
        FindObjectOfType<TextMesh>().text = Text;
    }

    public static CBloodTypeBrh CreateInstance(Vector3 position)
    {
        CBloodTypeBrh returnInstance = (CBloodTypeBrh)ScriptableObject.CreateInstance(typeof(CBloodTypeBrh));
        returnInstance.Initialize(position);

        return returnInstance;
    }
}