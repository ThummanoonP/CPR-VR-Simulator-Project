using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    [SerializeField] public GameObject finishSet;
    private Vector3 rootPosition;
    private Quaternion rootRotation;

    void Awake()
    {
        RootPosition();
    }

    public void RootPosition() 
    {
        rootPosition = finishSet.gameObject.transform.position;
        rootRotation = finishSet.gameObject.transform.rotation;
    }

    public void SetRoot() 
    {
        this.transform.position = rootPosition;
        this.transform.rotation = rootRotation;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
