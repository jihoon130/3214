using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    int a;
    public GameObject Enemy;
    public GameObject Warrior;
    public static Create CreateM;
    float firstT =0f;
    float CreatT = 4.0f;
    public int Count=0;
    public int MaxCount=0;
    public Transform SpawnPoint;
    public Transform PSpawnPoint;
    public static Create manager;
    // Start is called before the first frame update

    public void Awake()
    {
        PSpawnPoint = GameObject.Find("PSPawnPoint1").GetComponent<Transform>();
        SpawnPoint = GameObject.Find("SpawnPoint2").GetComponent<Transform>();
        CreateM = this;
        MaxCount = 1;
        manager = this;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        firstT += Time.deltaTime;
        if(firstT>=CreatT)
        {
            if (Enemy)
            {
                firstT = 0.0f;
                Instantiate(Enemy, SpawnPoint);
            }
            //a = Random.Range(0, 4);
            //switch (a)
            //{
            //    case 0:
            //        Instantiate(Enemy, SpawnPoint[0]);
            //        break;
            //    case 1:
            //        Instantiate(Enemy, SpawnPoint[1]);
            //        break;
            //    case 2:
            //        Instantiate(Enemy, SpawnPoint[2]);
            //        break;
            //    case 3:
            //        Instantiate(Enemy, SpawnPoint[3]);
            //        break;
            //    default:
            //        break;
            //}
        }
        
    }

    public void WarriorC()
    {
        if (Count < MaxCount)
        {
            Count++;
            Instantiate(Warrior, PSpawnPoint);
        }
    }
}
