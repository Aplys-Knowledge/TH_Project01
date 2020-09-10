using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Mgr : MonoBehaviour
{

    enum Mykey
    {
        move,
        camera,
        shot,
        bom,


    }

    private static int t = 0;
    private static bool flag = false;


    public static bool Get_Battered(KeyCode code)
    {
        

        if (Input.GetKeyDown(code))
        {
            flag = true;
        }

        if (flag == true)
        {
            t++;
            if (t <= 45 && t > 3)
            {
                if (Input.GetKeyDown(code))
                {
                    flag = false;
                    t = 0;
                    return true;

                }
            }

            if (t > 45)
            {
                flag = false;
                t = 0;
                return false;
            }
        }
        else
        {
            return false;
        }
        return false;
    }







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
