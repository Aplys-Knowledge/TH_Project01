using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemy : MonoBehaviour
{

    abstract protected void Ini();

    abstract protected void Move();

    abstract protected void HP_Mgr();

    protected void shot()
    {

    }


}
