using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Event_Mgr : MonoBehaviour
{

    private Data_Input data;
    protected PrimitiveStage pstage;

    protected int frame;
    protected bool flag;

    protected int cnt;

    protected Text myText;


    int cnt2;

    protected virtual void Ini()
    {
        data = this.gameObject.GetComponent<Data_Input>();
        pstage = this.gameObject.GetComponent<PrimitiveStage>();

        frame = 0;
        cnt = 1200;
        flag = true;

        
    }


    protected virtual void event_Mgr()
    {
        if (flag)
        {
            flag = false;
            
            if (data.PEvent_Data[frame].lines != null)
            {
                StartCoroutine("Event");
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {

            frame++;
            flag = true;

        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            cnt = 120;
            
        }
        else
        {
            cnt = 840;
        }

        //Debug.Log(frame);
        

    }

    protected virtual IEnumerator Event()
    {




        for(int i = 0; i < cnt; i++)
        {
            if (data.PEvent_Data[frame].lines != null)
            {
                Debug.Log(data.PEvent_Data[frame].lines);
            }

            yield return null;
        }
        
        frame++;
        flag = true;

    }


}
