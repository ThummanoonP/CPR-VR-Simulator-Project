using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertTutorial : MonoBehaviour
{
    private bool GoAway = false;
    private bool clearArea = false;
    private bool amOut = false;
    private int count = 0;

    public void SetClearArea() 
    {
        clearArea = true;
    }
    public bool GetClear()
    {
        return clearArea;
    }
    public void SetGoAwayFalse() 
    {
        GoAway = false;
    }
    public void SetGoAwayTrue() 
    {
        GoAway = true;
    }
    public bool GetAlert()
    {
        return GoAway;
    }

    public void SetAmOutTrue() 
    {
        amOut = true;
        count++;
    }
    public void SetAmOutFalse() 
    {
        amOut = false;
    }
    public bool GetAmOut()
    {
        return amOut;
    }
    public int GetCount()
    {
        return count;
    }
}
