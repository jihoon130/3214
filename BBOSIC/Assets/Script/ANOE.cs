using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANOE : MonoBehaviour
{
    float startT;
    float deltaT = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startT += Time.deltaTime;
        if(startT >= deltaT)
        {
            startT = 0.0f;
            this.gameObject.SetActive(false);
        }
    }
}
