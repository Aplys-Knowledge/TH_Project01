using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Behaviour : MonoBehaviour
{


    public delegate void Enemy_Move(bool flag);
    public struct Move_Array
    {
        public Enemy_Move MoveFunc;
    }

    public Move_Array[] move = new Move_Array[100];

    private PrimitiveEnemy enemy;

    private float t = 0;

    private int t2 = 0;
    //private NavMeshAgent agent;

    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        _characterController = GetComponent<CharacterController>();

        enemy = this.gameObject.GetComponent<PrimitiveEnemy>();

        move[0].MoveFunc = Enemy_Move01;
        move[1].MoveFunc = Enemy_Move02;
        move[2].MoveFunc = Enemy_Move03;
        


    }

    void Update()
    {
        t++;
        

    }






    private void Enemy_Move01(bool flag)
    {


        Vector3 r;

        r = new Vector3(0f, -0.1f, 0f);

        //enemy.PSpeed = 0.2f;
        //enemy.PRotate = r;

        transform.position += transform.forward * 0.02f;
        transform.Rotate(r);


        


    }

    private void Enemy_Move02(bool flag)
    {

        if (flag == false)
        {
            RandomWalk3(271f, 301f, 120f, 130f, 826f, 856f);
            //agent.stoppingDistance = 1.0f;
        }
        else
        {
            //agent.stoppingDistance = Vector3.Distance(transform.position, destinateposi);
        }




    }


    private void Enemy_Move03(bool flag)
    {

    }






    private int cnt = 0;
    private int state = 0;
    private Vector3 destinateposi;

    /*
    private void RandomWalk(float mx, float MX, float my, float MY, float mz, float MZ)
    {
        //NavMeshAgentを用いた実装

        
        switch (state)
        {
            case 0:
                destinateposi = new Vector3(Random.Range(mx, MX), Random.Range(my, MY), Random.Range(mz, MZ));

                state = 1;

                break;
            case 1:

                agent.SetDestination(destinateposi);
                //agent.autoBraking = false;

                if (Vector3.Distance(transform.position, destinateposi) < 1.0f)
                {
                    state = 2;
                }
                

                break;
            case 2:

                if (cnt < 540)
                {


                    cnt++;
                }
                else
                {

                    destinateposi = new Vector3(Random.Range(mx, MX), Random.Range(my, MY), Random.Range(mz, MZ));
                    cnt = 0;
                    state = 1;
                }

                break;
        }


        
        



    }
    */


    private Quaternion desRotation;

    private void RandomWalk2(float mx, float MX, float my, float MY, float mz, float MZ)
    {
        //transformによる実装


        Vector3 posi;
        Vector3 posi2;
        Physics.gravity = Vector3.zero;
        switch (state)
        {
            case 0:
                destinateposi = new Vector3(Random.Range(mx, MX), Random.Range(my, MY), Random.Range(mz, MZ));
                desRotation = Quaternion.LookRotation(destinateposi - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, desRotation, Time.deltaTime * 10);
                

                state = 1;

                break;
            case 1:

                desRotation = Quaternion.LookRotation(destinateposi - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, desRotation, Time.deltaTime * 10);
                transform.position += transform.forward * Time.deltaTime * 3f;



                posi = transform.position;
                posi2 = destinateposi;
                posi.y = 0f;
                posi2.y = 0f;


                if (Vector3.Distance(posi, posi2) < 1.0f)
                {
                    state = 2;
                }

                break;
            case 2:
                if (cnt < 540)
                {


                    cnt++;
                }
                else
                {

                    
                    cnt = 0;
                    state = 0;
                }


                break;
        }

        

    }


    private void RandomWalk3(float mx, float MX, float my, float MY, float mz, float MZ)
    {

        //CharacterControllerを用いた実装

        Vector3 posi;
        Vector3 posi2;
        Vector3 charaV;
        Physics.gravity = Vector3.zero;
        switch (state)
        {
            case 0:
                destinateposi = new Vector3(Random.Range(mx, MX), Random.Range(my, MY), Random.Range(mz, MZ));

                posi2 = destinateposi;
                posi2.y = transform.position.y;
                desRotation = Quaternion.LookRotation(posi2 - transform.position);
                
                transform.rotation = Quaternion.Slerp(transform.rotation, desRotation, Time.deltaTime * 10);


                state = 1;

                break;
            case 1:

                
                transform.rotation = Quaternion.Slerp(transform.rotation, desRotation, Time.deltaTime * 10);

                posi = (destinateposi - transform.position);

                charaV = Vector3.Normalize(posi);

                _characterController.Move(charaV * Time.deltaTime * 2f);




                posi = transform.position;
                posi2 = destinateposi;
                posi.y = 0f;
                posi2.y = 0f;


                if (Vector3.Distance(posi, posi2) < 1.0f)
                {
                    state = 2;
                }

                break;
            case 2:
                if (cnt < 540)
                {


                    cnt++;
                }
                else
                {


                    cnt = 0;
                    state = 0;
                }


                break;
        }



    }


    public Enemy_Move MoveF(int i)
    {
        return move[i].MoveFunc;

    }





}
