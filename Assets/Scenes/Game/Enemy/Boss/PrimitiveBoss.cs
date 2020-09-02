using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PrimitiveBoss : MonoBehaviour
{


    private CharacterController _characterController;

    protected PrimitiveStage pStage;

    protected int HP;
    protected int shot_num;
    protected bool onAnim;
    protected int state;

    private Boss_Shot bshot;
    private Animator anim;

    private float v;
    private float v2 = 0f;
    private float h;
    private float h2;


    private Vector3 bossV;

    private Quaternion targetRotation;

    private bool fa = false;    //accel中かどうか
    private bool fr = true;     //自機に向けて回転するかどうか



    protected virtual void Ini()
    {
        _characterController = GetComponent<CharacterController>();
        pStage = GameObject.Find("Stage_Mgr").GetComponent<PrimitiveStage>();

        bshot = this.gameObject.GetComponent<Boss_Shot>();
        anim = GetComponent<Animator>();

        

    }

    protected virtual void Behaviour()
    {

        

    }

    protected virtual void WaitMotion()
    {
        targetRotation = Quaternion.LookRotation(pStage.player_position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

        anim.SetBool("isAnim", true);
        


    }

    protected virtual void Battle()
    {
        

        targetRotation = Quaternion.LookRotation(pStage.player_position - transform.position);

        if (fr)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 15);
        }


        if (Vector3.Distance(transform.position, pStage.player_position) > 40f)
        {
            StartCoroutine("accel");


        }




    }

    private int t = 0;
    private bool flag = false;

    private bool isBack = false;




    protected virtual void Accelerate(bool back, float range, int time)
    {
        if (flag == true)
        {
            t++;

            if (back)
            {
                if (t < time || Vector3.Distance(transform.position, pStage.player_position) < range)
                {
                    fr = false;
                    fa = true;

                    
                    
                    v = -3f;


                }

                if (t == time || Vector3.Distance(transform.position, pStage.player_position) >= range)
                {
                    fr = true;
                    fa = false;
                    t = 0;
                    flag = false;
                }

            }
            else
            {
                if (t < time || Vector3.Distance(transform.position, pStage.player_position) >= range)
                {
                    fr = false;
                    fa = true;


                    v = 3.6f;




                }

                if (t == time || Vector3.Distance(transform.position, pStage.player_position) < range)
                {
                    fr = true;
                    fa = false;
                    t = 0;
                    flag = false;
                }

            }


        }
    }




    protected virtual IEnumerator accel(bool back, float range, int time)
    {

        for(int i = 0; i < time; i++)
        {
            if (back)
            {
                if (Vector3.Distance(transform.position, pStage.player_position) < range)
                {
                    fr = false;
                    fa = true;



                    v = -3f;


                }

                if (Vector3.Distance(transform.position, pStage.player_position) >= range)
                {
                    fr = true;
                    fa = false;
                    
                    flag = false;
                    yield break;
                }

            }
            else
            {
                if (Vector3.Distance(transform.position, pStage.player_position) >= range)
                {
                    fr = false;
                    fa = true;


                    v = 3.6f;




                }

                if (Vector3.Distance(transform.position, pStage.player_position) < range)
                {
                    fr = true;
                    fa = false;
                    
                    flag = false;
                    yield break;

                }

            }

            yield return null;
        }

    }


    protected bool fca = false;     //近接攻撃中かどうか

    protected virtual IEnumerator CloseAction()
    {



        yield return null;



    }







    protected virtual void HP_Mgr()
    {



    }
}
