using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerState
{
    IDLE = 0,
    RUN,
    CHASE,
    ATTACK,
    DEAD
}
public class Walk : MonoBehaviour
{
    public Transform Castle;
    public Transform EnemyT;
    public Transform PlayerT;
    public Transform IPoint;
    public GameObject Enemy;
    float speed = 100f;
    public int HP;
    NavMeshAgent agent;
    Animator ani;
    private void Awake()
    {
        HP = 100;
        ani = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Castle = GameObject.Find("EndPoint").GetComponent<Transform>();
        IPoint = GameObject.Find("IPoint").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <=0)
        {
            Destroy(this.gameObject);
        }
        if(GameObject.FindWithTag("Enemy"))
        {
            Enemy = GameObject.FindWithTag("Enemy");
            EnemyT = Enemy.transform;

            if (this.CompareTag("Player"))
            {
                if(transform.position.x-EnemyT.transform.position.x <= 10.0f)
                {
                    agent.SetDestination(EnemyT.transform.position);
                    if (agent.remainingDistance <= 1.0f)
                    {
                        Walk walk = Enemy.GetComponent<Walk>();
                        if(walk)
                        {
                            walk.HP -= 20;
                        }
                        ani.SetInteger("State", 1);
                    //    walk.HP -= 20;
                    }
                    else
                    {
                        ani.SetInteger("State", 0);
                    }
                }
                else
                {
                    agent.SetDestination(IPoint.position);
                }
            }
           
        }
        else
        {

            agent.SetDestination(IPoint.position);
        }
        if (GameObject.FindWithTag("Player"))
        {
            PlayerT = GameObject.FindWithTag("Player").GetComponent<Transform>();
            if(this.CompareTag("Enemy"))
            {
                if(transform.position.x-PlayerT.transform.position.x <= 10.0f)
                {
                    agent.SetDestination(PlayerT.transform.position);

                }
                else
                {
                    agent.SetDestination(Castle.position);
                }
               
            }
        }
        else
        {
            agent.SetDestination(Castle.position);
        }

        //float fMove = Time.deltaTime * speed;
        //transform.position = Vector3.MoveTowards(transform.position, Castle.position, Time.deltaTime);

        //Vector3 dir = Castle.position - transform.position;
        //dir.y = 0;
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), 300 * Time.deltaTime);
    }
    public void hit()
    {
        HP -= 20;
        Debug.Log("HIT");
    }
}
