using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveStage : AStage
{
    protected int stage_num;
    protected int state = 0;
    private int state2 = 0;

    protected static int defficult;


    protected GameObject player;

    protected Vector3 ini_position;
    protected Vector3 res_position;
    protected Vector3 boss_position;

    protected Vector3[] TransitAirPosition = new Vector3[32];
    protected Vector3[] CheckPoint = new Vector3[32];

    protected PrimitiveStage pStage;


    Quaternion rot = Quaternion.identity;

    private new string[] name = new string[4] { "reimu", "marisa", "sumire", "yukari" };
    private string[] boss_name = new string[3] { "kasen", "ran", "sara" };


    private PrimitiveChara chara;


    private PrimitiveBoss boss;


    protected override void Ini(int n)
    {
        stage_num = n;
        //ini_positionは派生先でオーバライドして初期化


        state = 0;

        


    }





    protected override void Player_Appear()
    {
        //player = Instantiate((GameObject)Resources.Load(name[Select_Mgr.get_chara]), ini_position, rot);
        player = Instantiate((GameObject)Resources.Load("Model/" + name[0]), ini_position, rot);



        chara = player.GetComponent<PrimitiveChara>();

    }

    protected void Stage_Mgr()
    {
        switch (state)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = 3;
                    state2 = 0;
                }

                if (Vector3.Distance(boss_position, player.transform.position) < 10f)
                {
                    state = 1;


                }

                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = 3;
                    state2 = 1;
                }

                

                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = 3;
                    state2 = 2;
                }

                

                break;
            case 3:
                //Debug.Log("pause");

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = state2;
                }



                break;
            case 4:

                break;
        }

        //Debug.Log(state);
        
    }

    protected void Boss_Appear()
    {
        boss = Instantiate((GameObject)Resources.Load("Model/Boss/" + boss_name[0]), boss_position, Quaternion.identity).GetComponent<PrimitiveBoss>();
        




    }


    protected void Boss_Mgr()
    {
        switch (state)
        {
            case 0:


                break;
            case 1:

                break;
            case 2:

                break;


        }



    }


    public Vector3 player_position
    {
        get { return player.transform.position; }
    }

    public static int Pdefficult
    {
        get { return defficult; }
    }

    public int PStage
    {
        get { return stage_num; }
    }

    public int PState
    {
        get { return state; }

    }

    public Vector3[] TPosition
    {
        get { return TransitAirPosition; }
        protected set { TransitAirPosition = value; }

    }

    public Vector3 PBossPosition
    {
        get { return boss_position; }
        set { boss_position = value; }

    }

}
