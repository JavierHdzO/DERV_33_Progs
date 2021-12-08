using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public TextMeshProUGUI puntos;
    int objetos_recolectados = 0;
    string name;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
    
        if (collision.transform.tag.Equals("Comida"))
        {
            Destroy(collision.gameObject);
            objetos_recolectados++;
            puntos.text = "Puntos: " + objetos_recolectados;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
