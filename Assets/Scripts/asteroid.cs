using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public Transform asteriodTransform;
    public float speedAsteriod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        asteriodTransform.position -= new Vector3(0,0.5f,0) * speedAsteriod * Time.deltaTime;
        //asteriodTransform.position -= Vector3.down * speedAsteriod * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D impacto)
    {
        if(impacto.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
