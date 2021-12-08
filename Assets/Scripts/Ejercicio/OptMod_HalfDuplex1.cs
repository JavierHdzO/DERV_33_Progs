using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using TMPro;
using UnityEngine;

public class OptMod_HalfDuplex1 : MonoBehaviour
{
    SerialPort arduino;

    [SerializeField]
    TextMeshProUGUI estado;
    [SerializeField]
    TextMeshProUGUI txt_boton;

    [SerializeField]
    bool estadoLed = false;


    [SerializeField]
    public int valSensor1;
    [SerializeField]
    public int valSensor2;
    [SerializeField]
    public int valSensor3;

    [SerializeField]
    [TextArea(5, 10)]
    public string valor = "";

    public void conectar(string ncom) {         

        if (arduino == null)  //conectar
        {
            arduino = new SerialPort("COM" + ncom, 9600);  //Ej: COM2
            arduino.ReadTimeout = 100; //100ms
            arduino.Open();
            estado.text = "CONECTADO";
            txt_boton.text = "DESCONECTAR";
        }
        else if (!arduino.IsOpen)  //reconectar
        {
            arduino.Open();
            estado.text = "RECONECTADO";
            txt_boton.text = "DESCONECTAR";
        }
        else {  //desconectar
            arduino.Close();
            estado.text = "DESCONECTADO";
            txt_boton.text = "RECONECTAR";
        }

    }



    public void escribir_datos() {

        if (arduino != null)
        {
            if (arduino.IsOpen)
            {
                if (estadoLed)
                {
                    arduino.WriteLine("1"); //envia 3 caracteres ... 1\n\r 
                }
                else {
                    arduino.WriteLine("0"); //   0\n\r
                }
                estadoLed = !estadoLed;
            }
        }
    }


    public void leer_datos() {
        StopAllCoroutines();
        StartCoroutine("leer_datos_arduino");
    }

    IEnumerator leer_datos_arduino() {
        valor = "H768R266R809TH452R854R021TH87R66R059TH36R74R820T";
        while (true)
        {
            if (arduino !=null)
            {
                if (arduino.IsOpen)
                {
                    //valor += arduino.ReadExisting();
                    //Debug.Log(valor);
                    //H768R266R809TH452R854R021TH87R66R059TH36R74R820T
                    
                    //CUIDADO CUANDO UNA TRAMA SE LEE DESDE EL COMIENZO TRUNCADA! 

                    if (valor[0] == 'H') /// AQUI SE SOLUCIONARÍA LO DE CUIDADO
                    {
                        //Debug.Log("la Trama inicia correctamente");
                        if (valor[valor.Length-1] == 'T')
                        {
                            Debug.Log("La Trama esta completa!");

                            //1.- quitar una trama de la cola

                            //TAREA INDIVIDUAL PARA EL 9 DE NOVIEMBRE  
                            // :  IDEAR Y PROBAR UN ALGORITMO QUE PERMITA QUITAR UNA TRAMA DE
                            //          UNA CONJUNTO(COLA) DE TRAMAS
                            Debug.Log(valor);
                            string trama;
                            trama = valor.Substring(0,valor.IndexOf('T')+1);
                            Debug.Log(trama);
                            
                            /*
                            //2.-procesarla

                            //PROCESAMIENTO:
                           
                            string temp = trama.Substring(1, trama.IndexOf('R')-1);
                            valSensor1 = Convert.ToInt32(temp); 
                            Debug.Log(temp);

                            //Trama sin el valor del primer sensor
                            temp = trama.Substring(trama.IndexOf('R') + 1); 
                            

                            /////////////////////////////////
                            //obtención del valor del segundo sendor
                            string aux = "";   //                         
                            aux = temp.Substring(0, temp.IndexOf('R'));
                            valSensor2 = Convert.ToInt32(aux);
                            Debug.Log(aux);

                            //trama sin el valor del segundo sensor
                            temp = temp.Substring(temp.IndexOf('R') + 1);
                            

                            //obtencion del valor del tercer sensor
                            temp = temp.Substring(0, temp.Length - 1);
                            valSensor3 = Convert.ToInt32(temp);
                            Debug.Log(temp);
                            /////////////////////////////
                            ///
                            */
                            valor = valor.Substring(valor.IndexOf('T') + 1);
                            Debug.Log(valor);
                        }
                    }///
                }
            }
            yield return new WaitForSeconds(.01f);
        }
    }

}
