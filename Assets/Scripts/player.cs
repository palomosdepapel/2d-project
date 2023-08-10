using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class script : MonoBehaviour
{
    //Variables
    public int life;
    //public float energy;
    //public string myname;
    //public bool OnTerrain;

    //Variables que hacen referencia a componentes de Unity
    public Transform navigation;
    public float speed;
    public GameObject bulletObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Actualiza continuamente la posición de un objeto en el juego.

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(bulletObj,navigation.position,navigation.rotation);
            Instantiate(bulletObj, navigation.position, quaternion.identity);
        }


        if (Input.GetKey(KeyCode.D))
        {
            navigation.position += new Vector3(0.05f,0,0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            navigation.position -= new Vector3(0.05f, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            navigation.position += new Vector3(0, 0.05f, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            navigation.position -= new Vector3(0, 0.05f, 0) * speed * Time.deltaTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D impacto) // se ejecuta una sola vez
    {
        
        if (impacto.gameObject.tag == "Asteroid")
        {
            life -= 15;
            //Destroy(impacto.gameObject);
            Debug.Log("Impact!!!" + impacto.gameObject.name);
        }
    }

    public void OnCollisionStay2D(Collision2D collision) // constantemente
    {
        
    }

    public void OnCollisionExit2D(Collision2D collision) // al finalizar el toque
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        
    }

}
