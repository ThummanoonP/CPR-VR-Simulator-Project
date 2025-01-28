using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Destroy : MonoBehaviour //���ʡ�� ź Item ����Ͷ١����¹͡ Socket
{
    private OnSocket onSocket;

    void Awake()
    {
        onSocket = this.GetComponent<OnSocket>();
    }

    public void DestroyObject()
    {
        if (onSocket.onSocketStatus.GetStatus() == false)
        {
            Destroy(this.gameObject, 0.25f);
        }
    }
}
