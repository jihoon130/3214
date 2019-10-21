using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    Text meet;
    public GameObject NANA;
    public GameObject[] camera;
    public GameObject button;
    public static UI ui;
    int b = 0;
    int c = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        ui = this;
        meet = GameObject.Find("meet").GetComponent<Text>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       meet.text = "인구수 : " + Create.CreateM.Count + " / " + Create.CreateM.MaxCount;
    }

    public void Center()
    {
        camera[0].SetActive(false);
        camera[1].SetActive(true);
        button.SetActive(true);
        gameObject.SetActive(false);
        // Display.displays[1].Activate();
    }
    public void Left()
    {
        camera[1].SetActive(false);
        camera[0].SetActive(true);
        button.SetActive(true);
        gameObject.SetActive(false);
    }
    public void meetup()
    {
        Create.manager.MaxCount++;
    }
    public void meetexit()
    {
        camera[0].SetActive(true);
        camera[1].SetActive(false);
    }

    public void talk()
    {
        switch (b)
        {
            case 0:
                meet.text = "웅녀니?";
                b++;
                break;
            case 1:
                meet.text = "덕선인데요";
                b++;
                break;
            case 2:
                meet.text = "그래? 일단 밥해먹어야하니까 마늘좀 캐다오";
                b++;
                break;
            case 3:
                NANA.SetActive(true);
                b++;
                camera[0].SetActive(false);
                break;

        }
    }
    public void talk2()
    {
        switch (c)
        {
            case 0:
                meet.text = "오 고맙다 웅녀야";
                c++;
                break;
            case 1:
                meet.text = "덕선이라니깐요";
                c++;
                break;
            case 2:
                meet.text = "그래 수고했어";
                c++;
                break;
            case 3:
                camera[0].SetActive(true);
                break;

        }
    }
}
