using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 m_posinicial;
    private Vector3 m_posfinal;
    private float m_speed = 0.5f;
    private bool toggle = false;
    private float lerpValue = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_posinicial = transform.position;
        m_posfinal = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
        {
            if (toggle)
            {
                //si toggle = true
                //agrega tiempo al valor lerp
                lerpValue += Time.deltaTime * m_speed;
                //si el lerp es mayor o igual a 1
                if (lerpValue >= 1f)
                {
                    //ajusta el valor lerp a 1 en caso de que fuera mayor a 1
                    lerpValue = 1f;
                    //toggle ahora es falso
                    toggle = false;
                }
            }
            else
            {
                //si toggle = false
                //resta tiempo del valor lerp
                lerpValue -= Time.deltaTime * m_speed;
                //si el lerp es menor o igual a 0f
                if (lerpValue <= 0f)
                {
                    //ajusta lerp a 0 en caso de que fuera menor a 0
                    lerpValue = 0f;
                    //toggle ahora es verdadero
                    toggle = true;
                }
            }

            //lerp la posición de transformación entre pointA y pointB basado en el valor lerp
            transform.position = Vector3.Lerp(m_posinicial, m_posfinal, lerpValue);
        }
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = this.transform;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
