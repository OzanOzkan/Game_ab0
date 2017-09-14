using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : Game {

    private static AnimationManager instance = null;
    public static AnimationManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        AnimatorStateInfo asi = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (asi.normalizedTime >= 1)
            Destroy(gameObject);
    }
}
