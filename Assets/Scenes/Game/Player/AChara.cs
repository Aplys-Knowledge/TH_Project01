using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AChara : MonoBehaviour
{


    abstract protected void Ini(GameObject player);

    abstract protected void Avatar_Ctr();

    abstract protected void Move();
    abstract protected void HP_Mgr();

    abstract protected void Attack();

    abstract protected void Bom();

    abstract protected void Guard();

}
