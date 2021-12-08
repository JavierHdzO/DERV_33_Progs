using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generar_comida : MonoBehaviour
{
    GameObject plane;
    [SerializeField]
    public GameObject comida;
    public float scaleX, scaleZ;
    float posX, posZ;
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Floor");
        scaleX = plane.transform.localScale.x *4;
        scaleZ = plane.transform.localScale.z * 4;

        for (int i = 0; i < 15; i++)
        {
            posX = Random.Range(transform.position.x - scaleX, transform.position.x + scaleX) ;
            posZ = Random.Range(transform.position.z - scaleZ, transform.position.z + scaleZ);
            Debug.Log(posX +"  "+ posZ);
            obj = Instantiate(comida, new Vector3(posX, transform.position.y + 0.5f, posZ), comida.transform.rotation);
            obj.name = "Comida" + i;
        }
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
