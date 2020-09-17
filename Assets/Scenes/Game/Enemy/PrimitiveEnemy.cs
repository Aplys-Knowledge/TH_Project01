using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrimitiveEnemy : AEnemy
{

    protected int flag = 0;
    protected int behaviour;
    protected int enc_behaviour;

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

    private bool fmcrt = true;      //通常動作コルーチンを開始するどうか
    private bool fecrt = false;     //エンカ動作コルーチンを開始するかどうか




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


        if (fap == false)
        {
            if (fmcrt == true && onEnemy == false)
            {
                StartCoroutine(Ebehaviour.move2[0]());
            }
        }


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

    private bool flag2 = true;
    



    protected virtual void OnEncount()
    {
        

        if (onEnemy == true && fap == false)
        {
            Ebehaviour.enc_move[enc_behaviour]();

            /*
            if (flag2 == true)
            {
                StartCoroutine(Ebehaviour.move2[0](false));
                flag2 = false;
            }
            */

            



        }
        else
        {
            flag2 = true;
            

        }


    }






    protected override void HP_Mgr()
    {
        

    }

    
    public int PBehaviour
    {

        get { return behaviour; }
        set { behaviour = value; }
    }

    public int PEnc_behaviour
    {
        get { return enc_behaviour; }
        set { enc_behaviour = value; }
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

    public bool Enc_flag
    {
        get { return onEnemy; }
        set { onEnemy = value; }

    }

    public bool mcrt
    {

        set { fmcrt = value; }
    }

    public bool ecrt
    {
        set { fecrt = value; }
    }



}
