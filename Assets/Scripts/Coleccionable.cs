using Unity.VisualScripting;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy() 
    {
        GameManager.instance.addMonedas();
    }
}
