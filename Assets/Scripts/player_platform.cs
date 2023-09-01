using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_platform : MonoBehaviour
{
    [Header("Movement and speed")]
    public Transform myTransform;
    public float x; // var movimiento horizontal
    //public float y; // var movimiento vertical
    public float speed;

    [Header("Jump")]
    public Rigidbody2D myRb;
    public float jumpForce; // qué tan alto saltamos
    public bool iCanJump;
    public int maxJumps = 2; // Número máximo de saltos permitidos
    private int jumpsRemaining; // Saltos restantes

    [Header("Related animations")]
    public Animator myAnimator;

    void Start()
    {
        jumpsRemaining = maxJumps; // Inicializa los saltos restantes al número máximo de saltos permitidos
    }

    // Update is called once per frame
    void Update()
    {
        // Se obtiene el valor de la entrada horizontal del usuario y se asigna a la variable x
        x = Input.GetAxis("Horizontal");
        myTransform.position += new Vector3(x, 0, 0) * speed * Time.deltaTime;
        myAnimator.SetBool("IsRunning", true); // viene del animator

        if (x == 0)
        {
            myAnimator.SetBool("IsRunning", false);
        }
        
        // Se obtiene el componente SpriteRenderer del objeto
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // No se voltea horizontalmente el sprite
            spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Se voltea horizontalmente el sprite
            spriteRenderer.flipX = true;
        }

        // Control de salto (salto sencillo)
        if (Input.GetKeyDown(KeyCode.Space) && iCanJump == true  )
        {
            myRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        // Control de salto (doble salto)
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            myRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpsRemaining--; // Reduce el número de saltos restantes
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Debug.Log("Tocando el suelo");
            iCanJump = true;
            myAnimator.SetBool("ItsOnTheFloor", true); // viene del animator
            jumpsRemaining = maxJumps; // Restablece los saltos restantes al número máximo de saltos permitidos
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Debug.Log("Saltando");
            iCanJump = false;
            myAnimator.SetBool("ItsOnTheFloor", false); // viene del animator
        }
    }
}
