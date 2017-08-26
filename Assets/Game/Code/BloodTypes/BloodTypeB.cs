using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBloodTypeB : IBloodType
{
    public CBloodTypeB() {}

    public static CBloodTypeB CreateInstance(Vector3 position)
    {
        Object tempObject = Resources.Load("Prefabs/blood_dark");
        tempObject = Instantiate(tempObject, position, Quaternion.identity);
        ((GameObject)tempObject).AddComponent<CBloodTypeB>();

        CBloodTypeB parameters = ((GameObject)tempObject).GetComponent<CBloodTypeB>();
        parameters.Object = tempObject;
        parameters.OriginalPosition = position;
        parameters.BloodType = Type.B;
        parameters.Text = "b-";

        parameters.BloodExchangeList = new List<Type>();
        parameters.BloodExchangeList.Add(Type.B);
        parameters.BloodExchangeList.Add(Type.AB);

        FindObjectOfType<TextMesh>().text = parameters.Text;

        return parameters;
    }
}

public class CBloodTypeBrh : IBloodType
{
    public CBloodTypeBrh() {}

    public static CBloodTypeBrh CreateInstance(Vector3 position)
    {
        Object tempObject = Resources.Load("Prefabs/blood_light");
        tempObject = Instantiate(tempObject, position, Quaternion.identity);
        ((GameObject)tempObject).AddComponent<CBloodTypeBrh>();

        CBloodTypeBrh parameters = ((GameObject)tempObject).GetComponent<CBloodTypeBrh>();
        parameters.Object = tempObject;
        parameters.OriginalPosition = position;
        parameters.BloodType = Type.Brh;
        parameters.Text = "b+";

        parameters.BloodExchangeList = new List<Type>();
        parameters.BloodExchangeList.Add(Type.Brh);
        parameters.BloodExchangeList.Add(Type.ABrh);

        FindObjectOfType<TextMesh>().text = parameters.Text;

        return parameters;
    }
}