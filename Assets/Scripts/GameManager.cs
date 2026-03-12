using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Jugador;
    [SerializeField] public TextMeshProUGUI texto_monedas;
    [SerializeField] public TextMeshProUGUI texto_vidas;
    public int numero_monedas = 0;
    public int numero_vidas = 3;
    public System.Action<int> onMonedasChanged;
    public System.Action<int> onVidasChanged;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int getMonedas()
    {
        return numero_monedas;
    }

    public int getVidas()
    {
        return numero_vidas;
    }
    public void addMonedas()
    {
        numero_monedas ++;
        if (onMonedasChanged != null)
        {
            onMonedasChanged.Invoke(numero_monedas);
        }
        texto_monedas.text = numero_monedas.ToString();
    }
    public void removeVidas()
    {
        numero_vidas --;
        if (onVidasChanged != null)
        {
            onVidasChanged.Invoke(numero_vidas);
        }
        texto_vidas.text = numero_vidas.ToString();
        if (numero_vidas > 0)
        {
            Jugador.GetComponent<PlayerController>().Respawn();
        }else
        {
            SceneManager.LoadScene("Nivel1");
            numero_monedas = 0;
            numero_vidas = 3;
        }
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene("Nivel1");
    }
    // He tenido que añadir estas secciones de código debido a unos errores que se me generaban a pesar de tener el singleton implementado. Al cargar la escena el game manager a veces no reconocía los objetos de la escena, por lo que tuve que añadir el método OnSceneLoaded para que cada vez que se cargara la escena se asignaran las variables correspondientes a los objetos de la escena.
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Nivel1")
        {
            texto_monedas = GameObject.Find("TextoMonedas").GetComponent<TextMeshProUGUI>();
            texto_vidas = GameObject.Find("TextoVidas").GetComponent<TextMeshProUGUI>();
            Jugador = GameObject.Find("Player");
            texto_monedas.text = numero_monedas.ToString();
            texto_vidas.text = numero_vidas.ToString();
        }
    }
}
