using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    [SerializeField] GameObject disparo;
    [SerializeField] GameObject disparo2;
    [SerializeField] float speed;
    [SerializeField] float fireRate;
    [SerializeField] float optrate;
    public float tiempoinicial=0;
    public int contadorX = 5;
    public float nextopt = 0;
    public bool gamepaused = false;
    public int contt = 0;
    bool Tipodisparo;
    float minX, maxX, minY, maxY;
    float nextfire = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaSuperDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaSuperDer.x - 1;
        maxY = esquinaSuperDer.y - 1;
        minX = esquinaInfIzq.x + 1;

        Vector2 puntoX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.6f));
        minY = puntoX.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gamepaused)
        {
            Realentizar();

            Mover();
            if (Tipodisparo)
                Disparar();
            else
                Disparar2();
            if (Input.GetKeyDown(KeyCode.X))
                Tipodisparo = Tipodisparo ? false : true;   
        }
    }

    void Mover()
    {
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");
        //movimiento//
        Vector2 movimiento = new Vector2(dirH * Time.deltaTime * speed, dirV * Time.deltaTime * speed);
        transform.Translate(movimiento);
        //condiciones//
        if (transform.position.x > maxX)
            transform.position = new Vector2(maxX, transform.position.y);
        if (transform.position.x < minX)
            transform.position = new Vector2(minX, transform.position.y);
        if (transform.position.y > maxY)
            transform.position = new Vector2(transform.position.x, maxY);
        if (transform.position.y < minY)
            transform.position = new Vector2(transform.position.x, minY);


    }

    void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextfire)
        {

            Instantiate(disparo, transform.position - new Vector3(0, 0.8f, 0), transform.rotation);
            nextfire = Time.time + fireRate;

        }

    }
    void Disparar2()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextfire)
        {
            //invokeRepeating(instantiate
            Instantiate(disparo2, transform.position - new Vector3(0, 0.5f, 0), transform.rotation);
            nextfire = Time.time + fireRate;
            Instantiate(disparo2, transform.position - new Vector3(0, 1, 0), transform.rotation);
            nextfire = Time.time + fireRate;
            Instantiate(disparo2, transform.position - new Vector3(0, 1.5f, 0), transform.rotation);
            nextfire = Time.time + fireRate;
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





