using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal2 : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] float optrate;
    public float tiempoinicial = 0;
    public int contadorX = 5;
    public float nextopt = 0;
    public int vida = 2;
    float minX, maxX;
    
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
    public void  OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.timeScale < 1)
        {
            GameObject colisionando = collision.gameObject;
            if (colisionando.tag == "Disparo")
            {
                gm.Reducirnumeme();
                Destroy(this.gameObject);
            }
            if (colisionando.tag == "Disparo2")
            {
                gm.Reducirnumeme();
                Destroy(this.gameObject);
            }
        }
        else
        {
            GameObject colisionando = collision.gameObject;
            if (colisionando.tag == "Disparo")
            {
                vida--;

                if (vida == 0)
                {
                    gm.Reducirnumeme();
                    Destroy(this.gameObject);
                }
            }
            if (colisionando.tag == "Disparo2")
            {
                vida--;
                if (vida == 0)
                {
                    gm.Reducirnumeme();
                    Destroy(this.gameObject);
                }
            }
        }
    }

    public void Realentizar()
    {
        if (Input.GetKeyDown(KeyCode.T) && Time.time > nextopt)
        {
            contadorX--;
            if (contadorX >= 0)
            {
                nextopt = Time.time + optrate;
                tiempoinicial = Time.unscaledTime;
                Time.timeScale = 0.5f;
            }
        }
        if (tiempoinicial != 0)
        {
            if (Time.unscaledTime - tiempoinicial >= 3)
            {
                Time.timeScale = 1;
            }
        }
    }
}

