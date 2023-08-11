using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Transform bulletTransform;
    public float bulletSpeed;// velocidad proyectil
    public GameObject explosionImage; // Imagen de explosión a instanciar

    // Start is called before the first frame update
    void Start()
    {
        // se establece que la bala se destruirá después de 3 segundos utilizando el método Destroy().
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //se actualiza la posición de la bala moviéndola hacia arriba utilizando la variable bulletSpeed y el tiempo transcurrido desde el último frame. 
        bulletTransform.position += new Vector3(0,0.1f,0) * bulletSpeed * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        // se activa cuando la bala colisiona con otro objeto.
        Debug.Log("BAAAAANNNG!!!" + other.gameObject.name);
        // si el objeto tiene la etiqueta "Asteroid", se destruye utilizando el método Destroy(). 
        if (other.gameObject.tag == "Asteroid")
        {
            GameObject explosion = Instantiate(explosionImage, other.transform.position, Quaternion.identity); // Instancia el objeto de la explosión en la posición del asteroide destruido
            Destroy(explosion, 0.1f); // Destruye el objeto de la explosión después de fraciones de segundo

            Destroy(other.gameObject);
            Destroy(gameObject); // Destruye la bala después de destruir el objeto "Asteroid"
        }
    }
}
