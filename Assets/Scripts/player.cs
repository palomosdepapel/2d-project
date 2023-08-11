using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class script : MonoBehaviour
{
    //Variables
    public int life; //un entero que representa la vida del objeto
    //public float energy;
    //public string myname;
    //public bool OnTerrain;

    //Variables que hacen referencia a componentes de Unity
    public Transform navigation;
    public float speed; // determina la velocidad de movimiento del objeto. 
    public GameObject bulletObj; //referencia a un objeto GameObject que se instancia cuando se presiona la tecla de espacio.
    public TextMeshProUGUI textoVida;  //referencia a un componente TextMeshProUGUI de Unity que muestra la vida del objeto en la interfaz de usuario. 
    public GameObject explosionImage; // Imagen de explosión a instanciar

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Space))//Si se presiona la tecla de espacio, se instancia un objeto bulletObj en la posición del objeto de navegación.
        {
            Instantiate(bulletObj, navigation.position, quaternion.identity);
        }

        //Si se presionan las teclas de dirección (D, A, W, S), se mueve el objeto en la dirección correspondiente. 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            navigation.position += new Vector3(0.05f,0,0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            navigation.position -= new Vector3(0.05f, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            navigation.position += new Vector3(0, 0.05f, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            navigation.position -= new Vector3(0, 0.05f, 0) * speed * Time.deltaTime;
        }

        textoVida.text = life.ToString();
        
    }


    public void OnCollisionEnter2D(Collision2D impacto)
    {
        //se verifica si el objeto colisiona con un objeto de etiqueta "Asteroid". 
        if (impacto.gameObject.tag == "Asteroid")
        {
            //Si es así, se reduce la vida del objeto en 15.
            life -= 15;
            Debug.Log("Impact!!!" + impacto.gameObject.name);

            // si la vida llega a cero, esto objeto se destruye
            if (life <= 0)
            {
                GameObject explosion = Instantiate(explosionImage, impacto.transform.position, Quaternion.identity); // Instancia el objeto de la explosión en la posición del asteroide destruido
                Destroy(explosion, 1f); // Destruye el objeto de la explosión después de fraciones de segundo
                // Si la vida llega a cero, el objeto se destruye y se muestra "0" en el componente textoVida del HUD. 
                Destroy(gameObject);
                textoVida.text = "0";
            }
        }

    }

}
