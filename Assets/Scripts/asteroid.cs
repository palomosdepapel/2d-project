using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public Transform asteriodTransform;
    public float speedAsteriod; //velocidad de movimiento del asteroide. 
    public GameObject explosionImage; // Imagen de explosión a instanciar
    
    void Start()
    {
        // se establece que el asteroide se destruirá después de 10 segundos utilizando el método Destroy().
        Destroy(gameObject, 30f);
        
    }

    // Update is called once per frame
    void Update()
    {
        asteriodTransform.position -= new Vector3(0,0.5f,0) * speedAsteriod * Time.deltaTime; 
        // actualiza continuamente la posición del asteroide, moviéndolo hacia abajo a una velocidad determinada por  speedAsteroid .
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    //se activa cuando el asteroide colisiona con otro objeto.
    {
        //Debug.Log("Contact!!!" + collision.gameObject.name);
        if (collision.gameObject.tag == "Asteroid") //Si el objeto con el que colisiona tiene la etiqueta "Asteroid", se destruye.
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player") //Si el objeto tiene la etiqueta "Player", el propio asteroide se destruye.  
        {
            GameObject explosion = Instantiate(explosionImage, collision.transform.position, Quaternion.identity); // Instancia el objeto de la explosión en la posición del asteroide destruido
            Destroy(explosion, 0.1f); // Destruye el objeto de la explosión después de fraciones de segundo
            Destroy(gameObject);
            
        }
    }

}
