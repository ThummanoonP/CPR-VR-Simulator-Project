using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEDButtonTutorial : MonoBehaviour
{
    [SerializeField] private GameObject AEDCheckBox;
    // Start is called before the first frame update
    private CPRControllerTutorial cPRController = null;

    private void Awake()
    {
        cPRController = this.GetComponent<CPRControllerTutorial>();
    }
    void Start()
    {
        ActiveCheckBox();
    }

    void Update()
    {
        ActiveCheckBox();
    }


    private void ActiveCheckBox()
    {
        if(cPRController.GetAEDButtonStatus() == true)
        {
            AEDCheckBox.SetActive(true);
        }
        else 
        {
            AEDCheckBox.SetActive(false);
        }
    }
}
