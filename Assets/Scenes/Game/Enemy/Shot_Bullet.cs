using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Bullet : MonoBehaviour
{

    private int[] bullet_flag = new int[1024];
    private GameObject[] Bullet_pre = new GameObject[20];

    private PrimitiveBullet[] bullet_cs = new PrimitiveBullet[1024];

    private PrimitiveStage pStage;


    private int[] shot_cnt = new int[100];
    private int[] shot_flag = new int[100];

    public delegate void ShotBullet(Vector3 position);
    public struct Bullet_Array
    {
        public ShotBullet ShotFunc;
    }

    public Bullet_Array[] ShotH = new Bullet_Array[100];



    // Start is called before the first frame update
    void Start()
    {
        pStage = GameObject.Find("Stage_Mgr").GetComponent<PrimitiveStage>();

        for (int i = 0; i < 1024; i++)
        {
            bullet_flag[i] = -1;
        }

        for (int i = 0; i < 100; i++)
        {
            shot_cnt[i] = 0;
            shot_flag[i] = 0;
        }


        ShotH[0].ShotFunc = shot_bullet01;
        ShotH[1].ShotFunc = shot_bullet02;
        ShotH[2].ShotFunc = shot_bullet03;











        Bullet_pre[0] = (GameObject)Resources.Load("Bullet/EnemyBullet/Bullet01");




    }



    // Update is called once per frame
    void Update()
    {

        Bullet_Mgr();


    }

    private void shot_bullet01(Vector3 position)
    {
        //何もしない



    }

    private void shot_bullet02(Vector3 position)
    {
        //直進1発


        int k;
        shot_cnt[0]++;
        Vector3 targetPosition = pStage.player_position;
        targetPosition.y += 0.5f;


        if ((shot_cnt[0] % 60) == 0)
        {



            if ((k = bullet_search()) != -1)
            {

                bullet_cs[k] = Instantiate(Bullet_pre[0], position, Quaternion.identity).GetComponent<PrimitiveBullet>();
                bullet_cs[k].bullet_rotation = Quaternion.LookRotation(targetPosition - transform.position);
                
                bullet_flag[k] = 2;



            }


        }
    }

    private void shot_bullet03(Vector3 position)
    {
        //自機狙い

        int k;
        shot_cnt[1]++;
        Vector3 targetPosition = pStage.player_position;
        targetPosition.y += 0.5f;


        if ((shot_cnt[1] % 60) == 0)
        {


            if ((k = bullet_search()) != -1)
            {
                bullet_flag[k] = 3;
                bullet_cs[k] = Instantiate(Bullet_pre[0], position, Quaternion.identity).GetComponent<PrimitiveBullet>();
                bullet_cs[k].bullet_rotation = Quaternion.LookRotation(targetPosition - transform.position);
                




            }

        }

        for (int i = 0; i < 1024; i++)
        {
            if (bullet_flag[i] == 3)
            {
                if ((bullet_cs[i].bullet_cnt < 60) && (Vector3.Distance(pStage.player_position, bullet_cs[i].bullet_posi) > 1f))
                {

                    bullet_cs[i].bullet_rotation = Quaternion.LookRotation(targetPosition - bullet_cs[i].bullet_posi);

                }

                if (Vector3.Distance(pStage.player_position, bullet_cs[i].bullet_posi) <= 1f)
                {
                    bullet_flag[i] = 0;
                }

                

            }
        }
    }


















    private void Bullet_Mgr()
    {
        for (int i = 0; i < 1024; i++)
        {
            if (bullet_flag[i] > -1)
            {
                if (bullet_cs[i].bullet_falg == -1)
                {
                    bullet_flag[i] = -1;
                    

                }
                
                

            }
            
        }

        
    }


    private int bullet_search()
    {
        for (int i = 0; i < 1024; i++)
        {
            if (bullet_flag[i] == -1)
            {
                return i;
            }
        }
        return -1;
    }



    public ShotBullet shot_bullet(int i)
    {
        return ShotH[i].ShotFunc;
    }

    public int[] bflag
    {
        get { return bullet_flag; }
        set { bullet_flag = value; }

    }



}
