using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    bool GoAway = false;

    public void SetGoAwayTrue() 
    {
        GoAway = true;
    }

    public void SetGoAwayFalse()
    {
        GoAway = false;
    }

    public bool GetAlert()
    {
        return GoAway;
    }
}
