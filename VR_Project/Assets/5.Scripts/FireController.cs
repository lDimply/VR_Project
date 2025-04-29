using UnityEngine;
using UnityEngine.UI; // Para usar la barra de progreso

public class FireController : MonoBehaviour
{
    [Header("Fuego")]
    public float maxFireStrength = 100f;  // Máxima intensidad del fuego
    private float currentFireStrength;

    [Header("Apagado")]
    public float extinguishRate = 10f; // Cuánto se apaga por segundo cuando se extingue
    private bool isExtinguishing = false;

    [Header("UI")]
    public Slider fireHealthBar; // La barra de world space que muestra cuánto queda de fuego

    private void Start()
    {
        currentFireStrength = maxFireStrength;

        if (fireHealthBar != null)
        {
            fireHealthBar.maxValue = maxFireStrength;
            fireHealthBar.value = currentFireStrength;
        }
    }

    private void Update()
    {
        if (isExtinguishing && currentFireStrength > 0)
        {
            currentFireStrength -= extinguishRate * Time.deltaTime;
            currentFireStrength = Mathf.Clamp(currentFireStrength, 0, maxFireStrength);

            if (fireHealthBar != null)
                fireHealthBar.value = currentFireStrength;

            if (currentFireStrength == 0)
                FireOut();
        }

        if(Input.GetKeyDown(KeyCode.V)) 
        {
            StartExtinguishing();
        }
    }

    public void StartExtinguishing()
    {
        isExtinguishing = true;
    }

    public void StopExtinguishing()
    {
        isExtinguishing = false;
    }

    private void FireOut()
    {
        // Aquí puedes poner efectos de fuego apagado, sonido, etc.
        Debug.Log("🔥 ¡Fuego extinguido!");
        // Por ejemplo: destruir el objeto del fuego
        Destroy(gameObject);
    }


}
