using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ManagerAsteroid : MonoBehaviour
{
    public GameObject asteroid;
    public int counter; // variable contador
    public Transform mytransform;
    public float randomX;

    void Start()
    {
        // Se creará un asteroide cada segundo después de esperar 5 segundos al iniciar el juego
        InvokeRepeating("CreateAsteroid", 5, 1);
        //Invoke("CreateAsteroid",5);
    }

    //void Update(){if (Input.GetKeyDown(KeyCode.K)){CreateAsteroid();}}

    // Método propio
    public void CreateAsteroid()
    {
        // se crea un nuevo asteroide utilizando la función Instantiate().
        // El asteroide se crea en la posición y rotación del objeto que tiene el script ManagerAsteroid. 
        Instantiate(asteroid,transform.position, transform.rotation);
        //Debug.Log("Se ha creado un nuevo asteroide");
        //Invoke("CreateAsteroid", 1);
        counter += 1; //  El contador se incrementa en 1

        // cuenta 30 veces
        if (counter >= 30) // Se verifica si el contador es mayor o igual a 30
        {
            // CancelInvoke(); //Se cancela todos los Invoke o InvokeRepeating del script
            
            CancelInvoke("CreateAsteroid");// Se cancela los Invoke o InvokeRepeating específicos del método CreateAsteroid
        }
        randomX = Random.Range(-6,6); //se genera un número aleatorio entre -6 y 6 y se asigna a la variable randomX
        mytransform.position = new Vector3 (randomX, 5.35f, 0); // Se asigna una nueva posición al objeto mytransform
    }
}
