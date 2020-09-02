using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu : PrimitiveChara
{

    private PrimitiveStage stage;
    

    

    void Start()
    {
        stage = GameObject.Find("Stage_Mgr").GetComponent<PrimitiveStage>();

        isAir = false;
        
        Ini(this.gameObject);
    }

    
    void Update()
    {
        /*
        if (stage.PState == 0 || stage.PState == 2)
        {
            rotateCamera();

            
            Move();
        }
        */
        rotateCamera();


        Move();

    }

    
       





}
