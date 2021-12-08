using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using TMPro;
using UnityEngine;

public class ManejadorArduinoEjer : MonoBehaviour 
{
    SerialPort arduino;

    [SerializeField]
    TextMeshProUGUI estado;
    [SerializeField]
    TextMeshProUGUI txt_boton;

    //programa 1- Agregar control de excepciones cuando se realiza la conexión del SE con el EV

    public void conectar(string ncom) {
        if (arduino == null)  //conectar
        {
            try {
                arduino = new SerialPort("COM" + ncom, 9600);  //Ej: COM2
                arduino.ReadTimeout = 100; //100ms
                arduino.Open();
                estado.text = "CONECTADO";
                txt_boton.text = "DESCONECTAR";
            }
            catch (IOException E) 
            {
                Debug.LogError(E.Message);
                arduino = null;
            }
            
            
            
        }
        else if (!arduino.IsOpen)  //reconectar
        {
            Debug.Log("Entre ene el 2");
            arduino.Open();
            estado.text = "RECONECTADO";
            txt_boton.text = "DESCONECTAR";
        }
        else {  //desconectar
            Debug.Log("Entre ene el 3");
            arduino.Close();
            estado.text = "DESCONECTADO";
            txt_boton.text = "RECONECTAR";
        }

    }



}
