using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_R01 : PrimitiveStage
{




    protected override void Ini(int n)
    {
        base.Ini(n);
        ini_position = new Vector3(244f, 120f, 852f);
        pStage = this.gameObject.GetComponent<PrimitiveStage>();
        pStage.TPosition[0] = new Vector3(257, 120, 690);
        pStage.PBossPosition = new Vector3(205, 192, 50);




    }

    void Awake()
    {
        Ini(1);
        Player_Appear();


    }

    void Start()
    {
        Boss_Appear();


    }

    // Update is called once per frame
    void Update()
    {
        Stage_Mgr();


    }
}
