﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBloodTypeA : IBloodType {

    public CBloodTypeA(){}

    protected void Initialize(Vector3 position)
    {
        BloodType = Type.A;
        Text = "a-";
        Object = Resources.Load("Prefabs/blood_dark");
        Object = Instantiate(Object, position, Quaternion.identity);
        FindObjectOfType<TextMesh>().text = Text;
    }

    public static CBloodTypeA CreateInstance(Vector3 position)
    {
        CBloodTypeA returnInstance = (CBloodTypeA)ScriptableObject.CreateInstance(typeof(CBloodTypeA));
        returnInstance.Initialize(position);

        return returnInstance;
    }
}

public class CBloodTypeArh : IBloodType {

    public CBloodTypeArh() { }

    protected void Initialize(Vector3 position)
    {
        BloodType = Type.Arh;
        Text = "a+";
        Object = Resources.Load("Prefabs/blood_light");
        Object = Instantiate(Object, position, Quaternion.identity);
        FindObjectOfType<TextMesh>().text = Text;
    }

    public static CBloodTypeArh CreateInstance(Vector3 position)
    {
        CBloodTypeArh returnInstance = (CBloodTypeArh)ScriptableObject.CreateInstance(typeof(CBloodTypeArh));
        returnInstance.Initialize(position);

        return returnInstance;
    }
}