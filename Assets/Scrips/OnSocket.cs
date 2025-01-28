using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSocket : MonoBehaviour //��������Ѻ�� Item �������� Socket �������
{
    [SerializeField] public GameObject KeySocket;

    public OnSocketStatus onSocketStatus;//ʶҹ� Socket

    private void Start()
    {
        onSocketStatus = KeySocket.GetComponent<OnSocketStatus>();
    }

    private void OnTriggerEnter(Collider other)//Item ����� Socket
    {
        onSocketStatus = KeySocket.GetComponent<OnSocketStatus>();

        if (other.gameObject.name == KeySocket.name)
        {
            onSocketStatus.SetStatusTrue(); //��ʶҹ� ����� Socket �� true
        }   
    }

    private void OnTriggerExit(Collider other)//Item �������� Socket
    {
        onSocketStatus = KeySocket.GetComponent<OnSocketStatus>();

        if (other.gameObject.name == KeySocket.name)
        {
            onSocketStatus.SetStatusFalse();//��ʶҹ� ����� Socket �� False
        }
    }
}
