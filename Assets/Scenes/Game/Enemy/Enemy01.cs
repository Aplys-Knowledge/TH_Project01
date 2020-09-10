using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : PrimitiveEnemy
{

    private PrimitiveEnemy enemy;
    private PrimitiveStage stage;


    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<PrimitiveEnemy>();


        Ini();
        StartCoroutine("Appear");

        behaviour = enemy.PBehaviour;
        shot_knd = enemy.PShot;
        item = enemy.PItem;
        stage = GameObject.Find("Stage_Mgr").GetComponent<PrimitiveStage>();




    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = Vector3.zero;


        if (stage.PState == 0)
        {
            Move();
            DetectPlayer();
            OnEncount();
        }

    }
}
