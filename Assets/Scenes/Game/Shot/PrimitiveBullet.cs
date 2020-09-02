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
    protected int graze_flag;

    protected void Ini()
    {
        t = 0;

        Destroy(gameObject, 15f);
    }

    protected void forward(float v)
    {
        t++;
        transform.position += transform.forward * Time.deltaTime * v;

    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int bullet_cnt()
    {
        return t;
    }

    protected void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }
    }





}
