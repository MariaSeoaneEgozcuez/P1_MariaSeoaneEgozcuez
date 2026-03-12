using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reintentar()
    {
        SceneManager.LoadScene("Nivel1");
        GameManager.instance.numero_monedas = 0;
        GameManager.instance.numero_vidas = 3;
    }
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
        GameManager.instance.numero_monedas = 0;
        GameManager.instance.numero_vidas = 3;
    }
}
