using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBloodTypeA : IBloodType
{
    public CBloodTypeA() {}

    public static CBloodTypeA CreateInstance(Vector3 position)
    {
        Object tempObject = Resources.Load("Prefabs/blood_dark");
        tempObject = Instantiate(tempObject, position, Quaternion.identity);
        ((GameObject)tempObject).AddComponent<CBloodTypeA>();

        CBloodTypeA parameters = ((GameObject)tempObject).GetComponent<CBloodTypeA>();
        parameters.Object = tempObject;
        parameters.OriginalPosition = position;
        parameters.BloodType = Type.A;
        parameters.Text = getBloodTypeAsString(parameters.BloodType).ToLower();

        parameters.BloodExchangeList = new List<Type>();
        parameters.BloodExchangeList.Add(Type.A);
        parameters.BloodExchangeList.Add(Type.AB);

        FindObjectOfType<TextMesh>().text = parameters.Text;

        return parameters;
    }
}

public class CBloodTypeArh : IBloodType
{
    public CBloodTypeArh() {}

    public static CBloodTypeArh CreateInstance(Vector3 position)
    {
        Object tempObject = Resources.Load("Prefabs/blood_light");
        tempObject = Instantiate(tempObject, position, Quaternion.identity);
        ((GameObject)tempObject).AddComponent<CBloodTypeArh>();

        CBloodTypeArh parameters = ((GameObject)tempObject).GetComponent<CBloodTypeArh>();
        parameters.Object = tempObject;
        parameters.OriginalPosition = position;
        parameters.BloodType = Type.Arh;
        parameters.Text = getBloodTypeAsString(parameters.BloodType).ToLower();

        parameters.BloodExchangeList = new List<Type>();
        parameters.BloodExchangeList.Add(Type.Arh);
        parameters.BloodExchangeList.Add(Type.ABrh);

        FindObjectOfType<TextMesh>().text = parameters.Text;

        return parameters;
    }
}