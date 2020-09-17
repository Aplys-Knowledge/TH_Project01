using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;

public class Enemy_Mgr : MonoBehaviour
{

    private Data_Input data_in;
    private GameObject[] knd = new GameObject[10];
    private PrimitiveEnemy[] enemy_cs = new PrimitiveEnemy[512];
    private PrimitiveEnemy enemy02;

    private PrimitiveStage stage;
    private Vector3 chara;

    private int[] enemy_flag = new int[512];


    // Start is called before the first frame update
    void Start()
    {
        data_in = this.gameObject.GetComponent<Data_Input>();
        stage = this.gameObject.GetComponent<PrimitiveStage>();

        
        knd[0] = (GameObject)Resources.Load("Model/Fairy01");
        knd[1] = (GameObject)Resources.Load("Model/Fairy00");


        for (int i = 0; i < 512; i++)
        {
            enemy_flag[i] = 0;
        }

        
        
        

    }


    void Update()
    {

        chara = new Vector3(stage.player_position.x, 0, stage.player_position.z);
        Enemy_Appear();

        

    }


    void Enemy_Appear()
    {
        for (int i = 0; (i < 512) && (data_in.Get_Enemy_Data(i).flag == 1); i++)
        {

            if (enemy_flag[i] == 0)
            {

                Vector3 ter = new Vector3(data_in.Get_Enemy_Data(i).x2, 0, data_in.Get_Enemy_Data(i).z2);
                switch (data_in.Get_Enemy_Data(i).Ap_form)
                {
                    case 0:
                        if (Mathf.Abs(chara.x - data_in.Get_Enemy_Data(i).x2) < data_in.Get_Enemy_Data(i).range)
                        {


                            enemy_cs[i] = Instantiate(knd[data_in.Get_Enemy_Data(i).knd], data_in.Get_Enemy_Data(i).position, data_in.Get_Enemy_Data(i).rotation).GetComponent<PrimitiveEnemy>();
                            enemy_flag[i] = 1;





                            enemy_cs[i].PBehaviour = data_in.Get_Enemy_Data(i).behaviour;
                            enemy_cs[i].PEnc_behaviour = data_in.Get_Enemy_Data(i).enc_move;
                            enemy_cs[i].PShot = data_in.Get_Enemy_Data(i).shot_num;
                            enemy_cs[i].PItem = data_in.Get_Enemy_Data(i).item;



                        }

                        break;
                    case 1:
                        if (Mathf.Abs(chara.y - data_in.Get_Enemy_Data(i).y2) < data_in.Get_Enemy_Data(i).range)
                        {


                            enemy_cs[i] = Instantiate(knd[data_in.Get_Enemy_Data(i).knd], data_in.Get_Enemy_Data(i).position, data_in.Get_Enemy_Data(i).rotation).GetComponent<PrimitiveEnemy>();
                            enemy_flag[i] = 1;





                            enemy_cs[i].PBehaviour = data_in.Get_Enemy_Data(i).behaviour;
                            enemy_cs[i].PEnc_behaviour = data_in.Get_Enemy_Data(i).enc_move;
                            enemy_cs[i].PShot = data_in.Get_Enemy_Data(i).shot_num;
                            enemy_cs[i].PItem = data_in.Get_Enemy_Data(i).item;



                        }


                        break;
                    case 2:
                        if (Mathf.Abs(chara.z - data_in.Get_Enemy_Data(i).z2) < data_in.Get_Enemy_Data(i).range)
                        {


                            enemy_cs[i] = Instantiate(knd[data_in.Get_Enemy_Data(i).knd], data_in.Get_Enemy_Data(i).position, data_in.Get_Enemy_Data(i).rotation).GetComponent<PrimitiveEnemy>();
                            enemy_flag[i] = 1;





                            enemy_cs[i].PBehaviour = data_in.Get_Enemy_Data(i).behaviour;
                            enemy_cs[i].PEnc_behaviour = data_in.Get_Enemy_Data(i).enc_move;
                            enemy_cs[i].PShot = data_in.Get_Enemy_Data(i).shot_num;
                            enemy_cs[i].PItem = data_in.Get_Enemy_Data(i).item;



                        }

                        break;
                    case 3:
                        

                        if (Vector3.Distance(chara, ter) < data_in.Get_Enemy_Data(i).range)
                        {


                            enemy_cs[i] = Instantiate(knd[data_in.Get_Enemy_Data(i).knd], data_in.Get_Enemy_Data(i).position, data_in.Get_Enemy_Data(i).rotation).GetComponent<PrimitiveEnemy>();
                            enemy_flag[i] = 1;





                            enemy_cs[i].PBehaviour = data_in.Get_Enemy_Data(i).behaviour;
                            enemy_cs[i].PEnc_behaviour = data_in.Get_Enemy_Data(i).enc_move;
                            enemy_cs[i].PShot = data_in.Get_Enemy_Data(i).shot_num;
                            enemy_cs[i].PItem = data_in.Get_Enemy_Data(i).item;



                        }

                        break;
                    case 4:
                        ter = new Vector3(data_in.Get_Enemy_Data(i).x2, data_in.Get_Enemy_Data(i).y2, data_in.Get_Enemy_Data(i).z2);

                        if (Vector3.Distance(chara, ter) < data_in.Get_Enemy_Data(i).range)
                        {


                            enemy_cs[i] = Instantiate(knd[data_in.Get_Enemy_Data(i).knd], data_in.Get_Enemy_Data(i).position, data_in.Get_Enemy_Data(i).rotation).GetComponent<PrimitiveEnemy>();
                            enemy_flag[i] = 1;





                            enemy_cs[i].PBehaviour = data_in.Get_Enemy_Data(i).behaviour;
                            enemy_cs[i].PEnc_behaviour = data_in.Get_Enemy_Data(i).enc_move;
                            enemy_cs[i].PShot = data_in.Get_Enemy_Data(i).shot_num;
                            enemy_cs[i].PItem = data_in.Get_Enemy_Data(i).item;



                        }


                        break;

                }

            }
        }
    }

    public int enemy_num_search()
    {
        for(int i = 0; i < 512; i++)
        {
            if (enemy_flag[i] == 0)
            {
                return i;
            }
        }
        return -1;
    }
    
}
