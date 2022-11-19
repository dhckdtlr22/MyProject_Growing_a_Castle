using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScript : MonoBehaviour
{
    private static TotalScript inst_ = null;
    public int Score;
    public int hp;
    public static TotalScript Ins
    {
        get
        {
            return inst_;
        }
    }

    private void Awake()
    {
        if (inst_ == null)
        {
            inst_ = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (inst_ != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
