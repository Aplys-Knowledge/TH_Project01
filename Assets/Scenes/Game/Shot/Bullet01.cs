using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01 : PrimitiveBullet
{
    private PrimitiveBullet pBullet;



    // Start is called before the first frame update
    void Start()
    {
        pBullet = this.gameObject.GetComponent<PrimitiveBullet>();
        Ini();
    }

    // Update is called once per frame
    void Update()
    {

        pBullet.bullet_falg = flag;
        Bullet_Destroy(900);
        rotate();
        forward(20f);


        
    }
}
