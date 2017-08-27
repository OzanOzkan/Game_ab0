using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBloodTypeAB : IBloodType {

    public CBloodTypeAB() { }

    public static CBloodTypeAB CreateInstance(Vector3 position)
    {
        Object tempObject = Resources.Load("Prefabs/blood_dark");
        tempObject = Instantiate(tempObject, position, Quaternion.identity);
        ((GameObject)tempObject).AddComponent<CBloodTypeAB>();

        CBloodTypeAB parameters = ((GameObject)tempObject).GetComponent<CBloodTypeAB>();
        parameters.Object = tempObject;
        parameters.OriginalPosition = position;
        parameters.BloodType = Type.AB;
        parameters.Text = getBloodTypeAsString(parameters.BloodType).ToLower();

        parameters.BloodExchangeList = new List<Type>();
        parameters.BloodExchangeList.Add(Type.AB);

        FindObjectOfType<TextMesh>().text = parameters.Text;

        return parameters;
    }
}

public class CBloodTypeABrh : IBloodType
{
    public CBloodTypeABrh() { }

    public static CBloodTypeABrh CreateInstance(Vector3 position)
    {
        Object tempObject = Resources.Load("Prefabs/blood_light");
        tempObject = Instantiate(tempObject, position, Quaternion.identity);
        ((GameObject)tempObject).AddComponent<CBloodTypeABrh>();

        CBloodTypeABrh parameters = ((GameObject)tempObject).GetComponent<CBloodTypeABrh>();
        parameters.Object = tempObject;
        parameters.OriginalPosition = position;
        parameters.BloodType = Type.ABrh;
        parameters.Text = getBloodTypeAsString(parameters.BloodType).ToLower();

        parameters.BloodExchangeList = new List<Type>();
        parameters.BloodExchangeList.Add(Type.ABrh);

        FindObjectOfType<TextMesh>().text = parameters.Text;

        return parameters;
    }
}
