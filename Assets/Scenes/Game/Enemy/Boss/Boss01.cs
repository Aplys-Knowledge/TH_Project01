using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01 : PrimitiveBoss
{




    protected override void Ini()
    {
        base.Ini();

        HP = 12000;
        



    }

    protected override void Behaviour()
    {
        switch (pStage.PState)
        {
            case 0:
                state = 0;

                
                if (Vector3.Distance(transform.position, pStage.player_position) < 30f)
                {
                    WaitMotion();
                }
                

                break;
            case 1:
                WaitMotion();


                break;
            case 2:

                Battle();

                break;
            case 3:
                

                break;
            case 4:


                break;

        }


    }

    protected override void Battle()
    {

        if (Vector3.Distance(transform.position, pStage.player_position) > 40f)
        {
            //StartCoroutine(accel(false, 8f, 180));


        }





    }








    protected override IEnumerator CloseAction()
    {
        for (int i = 0; i < 180; i++)
        {




            yield return null;
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        Ini();



    }

    // Update is called once per frame
    void Update()
    {

        Physics.gravity = Vector3.zero;
        Behaviour();


    }
}
