using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickME : MonoBehaviour
{
    public GameObject[] meetup;
    public int layerMask;
    public Camera maincamera;
    public GameObject han2;
    int b=0;
    // Start is called before the first frame update
    private void Awake()
    {

        layerMask = (1 << 9) | (1 << 10)|(1<<11);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
               Ray r = maincamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(r, out hit, 1000, layerMask))
                {
                Debug.Log(hit.transform.gameObject.layer);
                    if (hit.transform.gameObject.layer == 9)
                    {
                        meetup[0].SetActive(true);
                        meetup[1].SetActive(false);
                    }
                    else if(hit.transform.gameObject.layer == 10 && b==0)
                         {
                    han2.SetActive(true);
                }
                    else if(hit.transform.gameObject.layer == 10 && b==1)
                {
                    meetup[1].SetActive(true);
                }
                    else if(hit.transform.gameObject.layer ==11)
                {
                    meetup[0].SetActive(true);
                    b++;
                }
                }
        }

    }
}
