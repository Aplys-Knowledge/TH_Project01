using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveBullet : MonoBehaviour
{

    protected int t;
    protected float speed;
    protected Vector3 position;
    protected Quaternion rotation;
    protected int flag;
    private int graze_flag;

    protected void Ini()
    {
        t = 0;
        flag = 1;

        //Destroy(gameObject, 15f);
    }

    protected void forward(float v)
    {
        t++;
        transform.position += transform.forward * Time.deltaTime * v;

    }

    protected void rotate()
    {
        //transform.rotation = rotation;

    }


    protected virtual void Bullet_Destroy(int time)
    {
        //弾丸の終了処理

        if (flag == -1)
        {
            Destroy(gameObject);
        }


        if (t > time)
        {
            flag = -1;
        }
        

    }

    private void Update()
    {
        t++;


    }




    public int bullet_cnt
    {
        get { return t; }

    }

    public Quaternion bullet_rotation
    {
        get { return transform.rotation; }
        set { transform.rotation = value; }

    }

    public int bullet_falg
    {
        get { return flag; }
        set { flag = value; }

    }

    public Vector3 bullet_posi
    {
        get { return transform.position; }

    }



    protected void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }
    }





}
