using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        //Invoke("TurnOff", 2);
        
    }

    void TurnOff()
    {
        gameObject.SetActive(false);
    }
   
}
