using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPC : MonoBehaviour     
{

    public Camera cam;
    public float speedH;
    public float speedV;
    float ejeV, ejeH;

    public float rotmax;
    public float rotmin;


    Vector3 mov = Vector3.zero;

    void Start()
    {
        speedH = 6f;
        speedV = 6f;
        rotmax = 65;
        rotmin = -65;
        //cc = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        //Camara
        ejeH = speedH * Input.GetAxis("Mouse X");
        ejeV += speedV * Input.GetAxis("Mouse Y");

        cam.transform.localEulerAngles = new Vector3(-ejeV, 0, 0);
        transform.Rotate(0, ejeH, 0);
        ejeV = Mathf.Clamp(ejeV, rotmin, rotmax);


    }
}
