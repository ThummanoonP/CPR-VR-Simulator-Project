using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSocketStatus : MonoBehaviour//����ʶҹ� Socket
{
    private bool Status = false;

    public void SetStatusTrue() //��ʶҹ� ����� Socket �� true
    {
        Status = true;
    }

    public void SetStatusFalse() //��ʶҹ� ����� Socket �� False
    {
        Status = false;
    }

    public bool GetStatus() //��ʶҹ� Socket
    {
        return Status;
    }
}
