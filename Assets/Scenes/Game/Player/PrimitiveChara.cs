using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveChara : AChara
{

    private GameObject playerObject;
    private new GameObject camera;
    

    private  float CamerarotateSpeed = 2.0f;
    
    private int t = 0;
    private bool flag = false;

    private float v;
    private float v2 = 0f;
    private float h;
    private float h2;
    private Animator anim;
    private CharacterController _characterController;
    private Vector3 charaV;

    private PrimitiveStage stage;


    protected static int HP;
    protected static int MaxHP;
    protected static int MoveSpeed;


    protected static bool isAir;

    protected bool isableAir;

    protected bool isGuard;

    protected bool onAnim;


    


    protected override void Ini(GameObject player)
    {
        camera = GameObject.Find("Camera");
        playerObject = player;
        isAir = false;
        isableAir = false;
        isGuard = false;
        onAnim = true;
        stage = GameObject.Find("Stage_Mgr").GetComponent<PrimitiveStage>();


        anim = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();


    }

    protected override void Avatar_Ctr()
    {
        //操作制御


    }

    bool back = false;
    protected override void Move()
    {


        //移動処理

        //anim.SetBool("jump", false);

        if (fa == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isGuard = true;
                v = Input.GetAxis("Vertical") / 4f;
                h = Input.GetAxis("Horizontal") / 4f;
                h2 = 0f;
            }
            else
            {
                isGuard = false;
                v = Input.GetAxis("Vertical");
                h = 0f;
                h2 = Input.GetAxis("Horizontal") * 2.8f;

            }

            if (Input.GetAxis("Vertical") < 0)
            {
                v = Input.GetAxis("Vertical") / 4f;


            }
        }
        


        if (Input_Mgr.Get_Battered(KeyCode.W))
        {
            
            if (fa == false)
            {
                StartCoroutine(Accel3(0));
            }
        }

        if (Input_Mgr.Get_Battered(KeyCode.S))
        {
            
            if (fa == false)
            {
                StartCoroutine(Accel3(1));
            }
        }

        if (Input_Mgr.Get_Battered(KeyCode.D))
        {
            if (fa == false)
            {
                StartCoroutine(Accel3(2));
            }
        }

        if (Input_Mgr.Get_Battered(KeyCode.A))
        {
            if (fa == false)
            {
                StartCoroutine(Accel3(3));
            }
        }




        //Accelerate(back);

        charaV = new Vector3(h, 0, v);
        charaV = transform.TransformDirection(charaV) * 5f;

        TransitToAir();

        if (isAir == true)
        {
            //空中処理

            if (v > 0 && Input.GetKey(KeyCode.Q) == false)
            {
                if (camera.transform.localEulerAngles.x > 180 && camera.transform.localEulerAngles.x < 360)
                {
                    v2 = v * (camera.transform.localEulerAngles.x - 360) / 3f;


                }
                else if (camera.transform.localEulerAngles.x > 0 && camera.transform.localEulerAngles.x < 61)
                {
                    v2 = v * camera.transform.localEulerAngles.x / 3f;

                }

                charaV.y = v2 * (-1);
            }

            Physics.gravity = Vector3.zero;


            if (isableAir)
            {



            }


        }
        else
        {
            //地上処理



            charaV.y += -1960f * Time.deltaTime;



            if (Input.GetKeyDown(KeyCode.Space))
            {
                //anim.SetBool("Jump", true);

            }

            if (isableAir)
            {
                if (Input_Mgr.Get_Battered(KeyCode.Space))
                {
                    isAir = true;

                }
            }
        }

        //anim.SetBool("air", isAir);


        if (stage.PState == 0 || stage.PState == 2)
        {
            anim.SetFloat("speed", v);



            _characterController.Move(charaV * Time.deltaTime);
            transform.Rotate(0, h2, 0);
        }

        if (stage.PState == 1)
        {
            anim.SetFloat("speed", 0);

        }



        if (stage.PState == 3)
        {
            anim.speed = 0;
        }
        else
        {
            anim.speed = 1;
        }

        

    }

    void Accelerate(bool back)
    {
        if (flag == true)
        {
            t++;
            if (t < 45)
            {
                if (back)
                {
                    v = -2.7f;
                }
                else
                {
                    v = 3f;
                }

                

            }

            if (t == 45)
            {
                t = 0;
                flag = false;
            }

        }
    }

    bool fa = false;

    /*
    IEnumerator Accel2(bool back)
    {
        //Debug.Log("s");
        for(int i = 0; i < 45; i++)
        {

            fa = true;
            //Debug.Log("a");
            if (back)
            {
                v = -2.7f;
                
            }
            else
            {
                v = 3f;
                //Debug.Log("va:" + v);
            }

            yield return null;
        }

        fa = false;

    }
    */

    IEnumerator Accel3(int rot)
    {
        
        for (int i = 0; i < 30; i++)
        {

            
            fa = true;
            if (rot == 0)
            {
                v = 3f;
            }
            if (rot == 1)
            {
                v = -2.7f;
            }
            if (rot == 2)
            {
                v = 0f;
                h = 2f;
            }
            if (rot == 3)
            {
                v = 0f;
                h = -2f;
            }

            yield return null;
        }

        fa = false;

    }







    private void SetV(float speed)
    {
        v = speed;
    }




    protected void TransitToAir()
    {

        for (int i = 0; i < 32; i++)
        {
            if (Vector3.Distance(stage.TPosition[i], transform.position) < 10f)
            {
                isableAir = true;
                break;

            }
            else
            {
                isableAir = false;
            }
            



        }

        //Debug.Log(isableAir);


    }


    protected override void Attack()
    {
        //攻撃処理


    }

    protected  override void HP_Mgr()
    {
        //体力管理・ダメージ処理


    }

    protected override void Bom()
    {
        //ボム


    }

    protected override void Guard()
    {
        //防御


    }




    protected void rotateCamera()
    {
        //カメラ操作
        Vector3 angle;

        if (stage.PState == 0 || stage.PState == 2)
        {
            angle.x = Input.GetAxis("Mouse X") * CamerarotateSpeed;
            angle.y = Input.GetAxis("Mouse Y") * CamerarotateSpeed * (-1);



            camera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);


            if (camera.transform.localEulerAngles.x <= 60 || camera.transform.localEulerAngles.x >= 300)
            {
                camera.transform.RotateAround(playerObject.transform.position, camera.transform.right, angle.y);
            }
            else if (camera.transform.localEulerAngles.x > 60 && camera.transform.localEulerAngles.x < 90 && angle.y < 0)
            {
                camera.transform.RotateAround(playerObject.transform.position, camera.transform.right, angle.y);
            }
            else if (camera.transform.localEulerAngles.x < 300 && camera.transform.localEulerAngles.x > 270 && angle.y > 0)
            {
                camera.transform.RotateAround(playerObject.transform.position, camera.transform.right, angle.y);
            }



            if (Input.GetKeyDown(KeyCode.E))
            {
                camera.transform.RotateAround(playerObject.transform.position, camera.transform.right, camera.transform.localEulerAngles.x * (-1));
                camera.transform.RotateAround(playerObject.transform.position, Vector3.up, camera.transform.localEulerAngles.y * (-1));

            }
        }
    }

    
    

    


}
