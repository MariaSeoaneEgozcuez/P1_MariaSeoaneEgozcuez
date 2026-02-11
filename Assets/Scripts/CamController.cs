using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void LateUpdate()
    {
        transform.position = target.transform.position + new Vector3(0, 1.5f, -4.8f);
    }
}
