using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmove : MonoBehaviour
{

    private CharacterController _characterController;
    private Vector3 charaV;
    private Vector3 desposi;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        desposi = new Vector3(280f, 125f, 850f);


        charaV = new Vector3(1f, 0f, 0f);


    }

    // Update is called once per frame
    void Update()
    {

        charaV = (desposi - transform.position);

        Physics.gravity = Vector3.zero;
        _characterController.Move(charaV * Time.deltaTime * 0.5f);





    }
}
