using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    Planet[] otherPlanetas;
    Planet orbitingPlanet;
    [SerializeField]
    private Transform nave;
    
    float bordex=10f;
   
    float bordey=10f;
    float perdida = 0.9f;





    Vector3 velocidad;
    Vector3 aceleracion;

    private void Start()
    {
       
    }



    private void Update()

    {
        CheckCollisions();

        // Only re-launch if already moving (i.e.: Previously launched by the player)
        if (velocidad.sqrMagnitude > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                aceleracion *= 0;
                orbitingPlanet = null;
                Launch(velocidad.normalized * 3);
               
            }
        }

        // Check in which influence region is this planet?
        if (orbitingPlanet == null)
        {
            for (int i = 0; i < otherPlanetas.Length; i++)
            {
                Planet planet = otherPlanetas[i];
                Vector3 diff = planet.transform.position - transform.position;
                float distance = diff.magnitude;
                if (distance < planet.InfluenceRadius)
                {
                    orbitingPlanet = planet;
                    break;
                }
            }
        }
        

            // Is already orbiting a planet???
            if (orbitingPlanet != null)
        {
            Vector3 diff = orbitingPlanet.transform.position - transform.position;
            aceleracion = diff;
        }








        

        Desplazamiento();
    }
    private void CheckCollisions()
    {
        if (transform.position.x >= bordex || transform.position.x <= -bordex)
        {
            velocidad.x = -velocidad.x * perdida;
        }
        else if (transform.position.y >= bordey || transform.position.y <= -bordey)
        {
            velocidad.y = -velocidad.y * perdida;
        }
        else if (transform.position.y == bordey && transform.position.x == bordex)
        {
            velocidad.y = -velocidad.y * perdida;
            velocidad.x = -velocidad.x * perdida;
        }
        if (transform.position.y < -bordey)
        {
            transform.position = new MyVector(transform.position.x, -bordey);

        }
        else if (transform.position.y > bordey)
        {
            transform.position = new MyVector(transform.position.x, bordey);
        }
        else if (transform.position.x < -bordex)
        {
            transform.position = new MyVector(-bordex, transform.position.y);
        }
        else if (transform.position.x > bordex)
        {
            transform.position = new MyVector(bordex, transform.position.y);
        }
    }


        public void Desplazamiento()
    {
        velocidad += aceleracion * Time.deltaTime;
        //desplazamiento = velocidad * Time.deltaTime;
        transform.position += velocidad * Time.deltaTime;
        if (velocidad.magnitude > 0)
        {
            float radian = Mathf.Atan2(velocidad.y, velocidad.x);
            transform.localRotation = Quaternion.Euler(0, 0, radian * Mathf.Rad2Deg);
        }
    }
   

    public void Launch(Vector3 velInicial)
    {
        velocidad = velInicial;
    }
}