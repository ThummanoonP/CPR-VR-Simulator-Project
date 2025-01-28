using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reposition : MonoBehaviour
{
    private Vector3 rootPosition;
    private Quaternion rootRotation;
    private OnSocket onSocket;

    void Awake()
    {
        RootPosition();
        onSocket = this.GetComponent<OnSocket>();
    }

    public void RootPosition() 
    {
        rootPosition = this.gameObject.transform.position;
        rootRotation = this.gameObject.transform.rotation;
    }

    public void SetRoot() 
    {
        if (onSocket.onSocketStatus.GetStatus() == false)
        {
            this.transform.position = rootPosition;
            this.transform.rotation = rootRotation;
        }
    }
}
