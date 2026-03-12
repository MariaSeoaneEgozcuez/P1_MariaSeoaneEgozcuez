using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAdapter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto_monedas;
    [SerializeField] private TextMeshProUGUI texto_vidas;
    void Start()
    {
        GameManager.instance.onMonedasChanged += UpdateMonedas;
        GameManager.instance.onVidasChanged -= updateVidas;
    }

    void UpdateMonedas(int numero_monedas)
    {
        texto_monedas.text = numero_monedas.ToString();
    }
    void updateVidas(int vidas)
    {
        texto_vidas.text = vidas.ToString();
    }

    void Update()
    {
        
    }
}
