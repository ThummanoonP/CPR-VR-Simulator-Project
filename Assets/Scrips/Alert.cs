using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    private bool GoAway = false;
    private bool CPRActive = false;
    private bool clearArea = false;

    public void SetClearArea() 
    {
        clearArea = true;
    }
    public bool GetClear()
    {
        return clearArea;
    }
    public void SetCPRActive() 
    {
        CPRActive = true;
    }
    public bool GetCPRActive()
    {
        return CPRActive;
    }

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
