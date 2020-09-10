using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrimitiveEnemy : AEnemy
{

    protected int flag = 0;
    protected int behaviour;
    protected int shot_knd;
    protected int HP;
    protected int item;
    protected int point;

    protected bool onEnemy;

    protected bool onAnim;

    private Enemy_Behaviour Ebehaviour;
    private Shot_Bullet sbullet;

    private PrimitiveStage stage;

    protected float v;
    protected Vector3 rota;

    protected Quaternion targetRotation;

    

    private CharacterController _characterController;

    protected bool fap = true;      //出現動作中かどうか




    protected override void Ini()
    {
        flag = 1;

        _characterController = this.gameObject.GetComponent<CharacterController>();
        
        Ebehaviour = this.gameObject.GetComponent<Enemy_Behaviour>();
        sbullet = this.gameObject.GetComponent<Shot_Bullet>();

        onEnemy = false;

        stage = GameObject.Find("Stage_Mgr").GetComponent<PrimitiveStage>();

        



    }

    protected IEnumerator Appear()
    {

        for (int i = 0; i < 60; i++)
        {
            fap = true;
            Quaternion rot = Quaternion.LookRotation(transform.right);
            if (i < 20)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 18f);
            }
            if (i >= 20 && i < 40)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 15f);
            }
            if (i >= 40 && i < 60)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);
            }


            yield return null;
        }
        fap = false;

    }


    protected override void Move()
    {


        if (fap == false)
        {
            Ebehaviour.move[behaviour].MoveFunc(onEnemy);
        }

    }

    protected void Shot()
    {
        Vector3 shotposi;

        shotposi = transform.position;
        shotposi.y += 0.5f;


        sbullet.ShotH[shot_knd].ShotFunc(shotposi);




    }



    protected void DetectPlayer()
    {
        if (Vector3.Distance(stage.player_position, transform.position) < 10f)
        {
            onEnemy = true;
        }

        if (onEnemy && Vector3.Distance(stage.player_position, transform.position) > 30f)
        {
            onEnemy = false;
        }

    }

    private Vector3 destinateposi;
    private Quaternion desRotation;
    private int state = 0;
    private int cnt = 0;

    protected virtual void OnEncount()
    {
        Vector3 posi;
        Vector3 posi2;
        Vector3 charaV;

        if (onEnemy == true && fap == false)
        {

            targetRotation = Quaternion.LookRotation(stage.player_position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
            //Shot();

            switch (state)
            {
                case 0:

                    while (onEnemy)
                    {
                        destinateposi = new Vector3(Random.Range((transform.position.x - 10f), (transform.position.x + 10f)), transform.position.y, Random.Range((transform.position.z - 10f), (transform.position.z + 10f)));

                        if (Vector3.Distance(stage.player_position, destinateposi) > 10f && Vector3.Distance(stage.player_position, destinateposi) < 18f)
                        {
                            
                            state = 1;
                            break;
                            
                        }
                        

                    }

                    
                    
                    state = 1;

                    break;
                case 1:

                    posi = (destinateposi - transform.position);

                    charaV = Vector3.Normalize(posi);

                    _characterController.Move(charaV * Time.deltaTime * 2f);
                    



                    if(Vector3.Distance(transform.position, destinateposi) < 1.0f)
                    {
                        state = 2;
                    }
                    

                    break;
                case 2:
                    if (cnt < 240)
                    {

                        Shot();
                        cnt++;
                    }
                    else
                    {

                        
                        cnt = 0;
                        state = 0;
                    }


                    break;
            }


            //Debug.Log(Vector3.Distance(transform.position, destinateposi));

            //Debug.Log(state);

            
            

            //弾幕の処理


        }
        else
        {



        }


    }

    protected void EncountBehaviour()
    {








    }







    protected override void HP_Mgr()
    {
        

    }

    
    public int PBehaviour
    {

        get { return behaviour; }
        set { behaviour = value; }
    }


    public int PShot
    {
        get { return shot_knd; }
        set { shot_knd = value; }
    }

    public int PItem
    {
        get { return item; }
        set { item = value; }
    }

    public int POINT
    {
        get { return point; }
        set { point = value; }
    }

    public int Php
    {
        get { return HP; }
        set { HP = value; }
    }

    

    public float PSpeed
    {
        set { v = value; }
        get { return v; }
    }

    public Vector3 PRotate
    {
        set { rota = value; }
    }



}
