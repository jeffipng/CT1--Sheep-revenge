using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal3 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;
    [SerializeField] float optrate;
    public float tempinicial = 0;
    public int contadorX = 5;
    public float nextopt = 0;
    float minX, maxX;
    public int vida = 3;
   


    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinainferiorDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinainferiorIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinainferiorDer.x;
        minX = esquinainferiorIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0), Space.World);
        }
        else
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0), Space.World);
        }
        if (transform.position.x > (maxX - 0.4f))
        {
            movingRight = false;
        }
        else if (transform.position.x < (minX + 0.4f))
        {
            movingRight = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameObject colisionando = collision.gameObject;
        if (colisionando.tag == "Disparo")
        {
            vida--;
            if (Input.GetKeyDown(KeyCode.M))
            {
                gm.Reducirnumeme();
                Destroy(this.gameObject);
            }                          
            
            if(vida==0)
            {
                gm.Reducirnumeme();
                Destroy(this.gameObject);
            }          

            
        }
        if (colisionando.tag == "Disparo2")
        {
            
            if (Input.GetKeyDown(KeyCode.M))
            {
                
                gm.Reducirnumeme();
                Destroy(this.gameObject);
            }
            vida--;
            if (vida == 0)
            {
                gm.Reducirnumeme();
                Destroy(this.gameObject);
            }

            
        }
        
       
    }
    public void Tiempolento()
    {
        if (Input.GetKeyDown(KeyCode.M) && Time.time > nextopt)
        {

            contadorX--;
            if (contadorX >= 0)
            {
                nextopt = Time.time + optrate;
                tempinicial = Time.unscaledTime;
                Time.timeScale = 0.5f;

            }
        }
        if (tempinicial != 0)
        {
            if (Time.unscaledTime - tempinicial >= 3)
            {
                Time.timeScale = 1;
            }

        }


    }

}