using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float vel = 2f;
    private Vector3 posInicial;
    private Vector3 posFinal;
    private bool colision = false;

    void Start()
    {
        posInicial = transform.position;
        posFinal = posInicial + Vector3.down * 2f;
    }

    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Player") && !colision)
    {
        collision.transform.SetParent(transform); 
        colision = true;
        StartCoroutine(Timer(1));
    }
}

void OnCollisionExit(Collision collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.transform.SetParent(null); 
    }
}

    IEnumerator Timer(float duracion)
    {
        yield return new WaitForSeconds(duracion);

        while (transform.position.y > posFinal.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, posFinal, vel * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(duracion);

        while (transform.position.y < posInicial.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, posInicial, vel * Time.deltaTime);
            yield return null;
        }

        colision = false;
    }
}