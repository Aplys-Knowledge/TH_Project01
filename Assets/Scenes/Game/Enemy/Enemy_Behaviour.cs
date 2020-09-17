using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Behaviour : MonoBehaviour
{


    public delegate void Enemy_Move(bool flag);


    public delegate void Encount_Behaviour();

    public delegate IEnumerator Enemy_Move2();


    private PrimitiveStage stage;


    public struct Move_Array
    {
        public Enemy_Move MoveFunc;
    }


    public Move_Array[] move = new Move_Array[100];

    public Encount_Behaviour[] enc_move = new Encount_Behaviour[100];

    public Enemy_Move2[] move2 = new Enemy_Move2[100];



    private PrimitiveEnemy enemy;

    private float t = 0;

    private int t2 = 0;

    private Quaternion targetRotation;


    //private NavMeshAgent agent;

    private CharacterController _characterController;

    private Shot_Bullet sbullet;





    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        _characterController = GetComponent<CharacterController>();

        enemy = this.gameObject.GetComponent<PrimitiveEnemy>();

        stage = GameObject.Find("Stage_Mgr").GetComponent<PrimitiveStage>();

        sbullet = this.gameObject.GetComponent<Shot_Bullet>();



        move[0].MoveFunc = Enemy_Move01;
        move[1].MoveFunc = Enemy_Move02;
        move[2].MoveFunc = Enemy_Move03;

        enc_move[0] = Encount_Move01;
        enc_move[1] = Encount_Move02;



        move2[0] = move01;





    }

    void Update()
    {
        t++;
        

    }


    protected void Shot()
    {
        Vector3 shotposi;

        shotposi = transform.position;
        shotposi.y += 0.5f;


        sbullet.ShotH[enemy.PShot].ShotFunc(shotposi);




    }






    private void Enemy_Move01(bool flag)
    {
        //何もしない

    }

    private void Enemy_Move02(bool flag)
    {
        //ランダムに歩き回る

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


    private IEnumerator move01()
    {

        
        while (!enemy.Enc_flag)
        {

            enemy.mcrt = false;

            
            //targetRotation = Quaternion.LookRotation(stage.player_position - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

            //RandomWalk3(271f, 301f, 120f, 130f, 826f, 856f);

            yield return null;
        }

        enemy.mcrt = true;

        if (enemy.Enc_flag)
        {
            enemy.mcrt = true;
            yield break;
        }


    }





    private void Encount_Move01()
    {
        //自機を向いて回る

        targetRotation = Quaternion.LookRotation(stage.player_position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);


    }

    private Vector3 destinateposi2;
    private Quaternion desRotation2;
    private int state2 = 0;
    private int cnt2 = 0;


    private void Encount_Move02()
    {
        //一定範囲内をランダムに動く

        targetRotation = Quaternion.LookRotation(stage.player_position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

        Vector3 posi;
        
        Vector3 charaV;

        switch (state2)
        {
            case 0:

                while (true)
                {
                    destinateposi2 = new Vector3(Random.Range((transform.position.x - 10f), (transform.position.x + 10f)), transform.position.y, Random.Range((transform.position.z - 10f), (transform.position.z + 10f)));

                    if (Vector3.Distance(stage.player_position, destinateposi2) > 10f && Vector3.Distance(stage.player_position, destinateposi2) < 18f)
                    {

                        state2 = 1;
                        break;

                    }


                }



                state2 = 1;

                break;
            case 1:

                posi = (destinateposi2 - transform.position);

                charaV = Vector3.Normalize(posi);

                _characterController.Move(charaV * Time.deltaTime * 2f);




                if (Vector3.Distance(transform.position, destinateposi2) < 1.0f)
                {
                    state2 = 2;
                }


                break;
            case 2:
                if (cnt2 < 240)
                {

                    Shot();
                    cnt2++;
                }
                else
                {


                    cnt2 = 0;
                    state2 = 0;
                }


                break;
        }


    }


    private int cnt = 0;
    private int state = 0;
    private Vector3 destinateposi;


    private Quaternion desRotation;

    


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
                
                transform.rotation = Quaternion.Slerp(transform.rotation, desRotation, Time.deltaTime * 6f);


                state = 1;

                break;
            case 1:

                
                transform.rotation = Quaternion.Slerp(transform.rotation, desRotation, Time.deltaTime * 6f);

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
                if (cnt < 240)
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


    








}
