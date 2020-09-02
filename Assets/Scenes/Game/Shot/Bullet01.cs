using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01 : PrimitiveBullet
{
    // Start is called before the first frame update
    void Start()
    {
        Ini();
    }

    // Update is called once per frame
    void Update()
    {
        forward(20f);


    }
}
