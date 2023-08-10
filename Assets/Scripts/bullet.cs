using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Transform bulletTransform;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // destruír la bala luego de 2 seg
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        bulletTransform.position += new Vector3(0,0.1f,0) * bulletSpeed * Time.deltaTime;
    }

    public void OnCollision2D(Collider2D collision)
    {
        Debug.Log("Contact!!!" + collision.gameObject.name);
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
        }
    }
}
