using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_RigidBody;
    private Animator m_Animator;

    private bool isGrounded;
    
    [SerializeField] private  float speed = 2.0f;
    [SerializeField] private  float jumpForce = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_RigidBody = this.GetComponent<Rigidbody>();
        m_Animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento del jugador
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");

        // Aumentar velocidad al correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4.0f;
        }
        else
        {
            speed = 2.0f;
        }

        // Calcular direccion y aplicar movimiento
        Vector3 direccion = new Vector3(horizontal,0,vertical).normalized;
        if(direccion.magnitude >= 0.1f)
        transform.rotation = Quaternion.LookRotation(direccion);

        // Aplicar movimiento al Rigidbody
        m_RigidBody.linearVelocity = new Vector3(direccion.x * speed, m_RigidBody.linearVelocity.y, direccion.z * speed);
        
        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            m_RigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if(horizontal != 0 || vertical != 0)
        {
            m_Animator.SetBool("walk", true);
        }
        else
        {
            m_Animator.SetBool("walk", false);
        }

        if(m_RigidBody.linearVelocity.y > 0.1f || m_RigidBody.linearVelocity.y < -0.1f)
        {
            m_Animator.SetBool("jump", true);
        }
        else
        {
            m_Animator.SetBool("jump", false);
        }
    }
    // Comprobar si el jugador esta en el suelo
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
        private void OnCollisionExit(Collision collision)
    {

        if(collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
