using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Stage : PrimitiveStage
{
    protected override void Ini(int n)
    {
        base.Ini(n);
        ini_position = new Vector3(10f, 50f, 10f);


    }






    // Start is called before the first frame update
    void Awake()
    {
        Ini(1);
        Player_Appear();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
