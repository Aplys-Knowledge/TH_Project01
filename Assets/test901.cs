using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test901 : MonoBehaviour
{

    bool fap = false;

    protected IEnumerator Appear()
    {

        for (int i = 0; i < 60; i++)
        {
            fap = true;
            Quaternion rot = Quaternion.LookRotation(transform.right);
            if (i < 20)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 18f);
            }
            if (i >= 20 && i < 40)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 15f);
            }
            if (i >= 40 && i < 60)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);
            }


            yield return null;
        }
        fap = false;

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) == true && fap == false)
        {
            StartCoroutine("Appear");
        }

        
    }
}
