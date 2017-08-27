using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBloodTypeZero : IBloodType
{
    public CBloodTypeZero() { }

    public static CBloodTypeZero CreateInstance(Vector3 position)
    {
        Object tempObject = Resources.Load("Prefabs/blood_dark");
        tempObject = Instantiate(tempObject, position, Quaternion.identity);
        ((GameObject)tempObject).AddComponent<CBloodTypeZero>();

        CBloodTypeZero parameters = ((GameObject)tempObject).GetComponent<CBloodTypeZero>();
        parameters.Object = tempObject;
        parameters.OriginalPosition = position;
        parameters.BloodType = Type.ZERO;
        parameters.Text = getBloodTypeAsString(parameters.BloodType).ToLower();

        parameters.BloodExchangeList = new List<Type>();
        parameters.BloodExchangeList.Add(Type.ZERO);
        parameters.BloodExchangeList.Add(Type.A);
        parameters.BloodExchangeList.Add(Type.AB);
        parameters.BloodExchangeList.Add(Type.B);

        FindObjectOfType<TextMesh>().text = parameters.Text;

        return parameters;
    }
}

public class CBloodTypeZerorh : IBloodType
{
    public CBloodTypeZerorh() { }

    public static CBloodTypeZerorh CreateInstance(Vector3 position)
    {
        Object tempObject = Resources.Load("Prefabs/blood_light");
        tempObject = Instantiate(tempObject, position, Quaternion.identity);
        ((GameObject)tempObject).AddComponent<CBloodTypeZerorh>();

        CBloodTypeZerorh parameters = ((GameObject)tempObject).GetComponent<CBloodTypeZerorh>();
        parameters.Object = tempObject;
        parameters.OriginalPosition = position;
        parameters.BloodType = Type.ZEROrh;
        parameters.Text = getBloodTypeAsString(parameters.BloodType).ToLower();

        parameters.BloodExchangeList = new List<Type>();
        parameters.BloodExchangeList.Add(Type.ZEROrh);
        parameters.BloodExchangeList.Add(Type.Arh);
        parameters.BloodExchangeList.Add(Type.ABrh);
        parameters.BloodExchangeList.Add(Type.Brh);

        FindObjectOfType<TextMesh>().text = parameters.Text;

        return parameters;
    }
}
