using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Bullet : MonoBehaviour
{

    private int[] bullet_flag = new int[1024];
    private GameObject[] Bullet_pre = new GameObject[20];

    private PrimitiveBullet[] bullet_cs = new PrimitiveBullet[1024];


    private int[] shot_cnt = new int[100];
    private int[] shot_flag = new int[100];

    public delegate void ShotBullet(Vector3 position, Quaternion rotation);
    public struct Bullet_Array
    {
        public ShotBullet ShotFunc;
    }

    public Bullet_Array[] ShotH = new Bullet_Array[100];



    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 1024; i++)
        {
            bullet_flag[i] = 0;
        }

        for (int i = 0; i < 100; i++)
        {
            shot_cnt[i] = 0;
            shot_flag[i] = 0;
        }


        ShotH[0].ShotFunc = shot_bullet01;



        Bullet_pre[0] = (GameObject)Resources.Load("Bullet/Bullet01");




    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void shot_bullet01(Vector3 position, Quaternion rotation)
    {
        int k;
        shot_cnt[0]++;



        if ((shot_cnt[0] % 60) == 0)
        {



            if ((k = bullet_search()) != -1)
            {

                bullet_cs[k] = Instantiate(Bullet_pre[0], position, rotation).GetComponent<PrimitiveBullet>();
                bullet_flag[k] = 1;



            }


        }




    }

    private void shot_bullet02(Vector3 position, Quaternion quaternion)
    {
        int k;
        shot_cnt[1]++;

        if ((shot_cnt[1] % 60) == 0)
        {
            if ((k = bullet_search()) != -1)
            {





            }
        }
    }







    private int bullet_search()
    {
        for (int i = 0; i < 1024; i++)
        {
            if (bullet_flag[i] == 0)
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

}
