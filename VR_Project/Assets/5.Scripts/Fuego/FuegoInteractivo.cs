using UnityEngine;

public class FuegoInteractivo : MonoBehaviour
{
    public ParticleSystem fuegoParticulas;
    public float tiempoParaApagar = 3f;
    public GameObject Flecha;

    private float progresoApagado = 0f;
    private bool apagandose = false;

    void Start()
    {
        if (fuegoParticulas == null)
            fuegoParticulas = GetComponent<ParticleSystem>();
    }

    public void AplicarAgua(float cantidad)
    {
        if (!apagandose)
            StartCoroutine(ApagarFuego());
    }

    private System.Collections.IEnumerator ApagarFuego()
    {
        apagandose = true;
        float tiempo = 0f;

        var emission = fuegoParticulas.emission;

        while (tiempo < tiempoParaApagar)
        {
            tiempo += Time.deltaTime;
            float ratio = 1f - (tiempo / tiempoParaApagar);
            emission.rateOverTime = Mathf.Lerp(0f, 50f, ratio); // Ajusta 50 según tu fuego
            yield return null;
        }

        fuegoParticulas.Stop();
        Flecha.SetActive(true);
        apagandose = false;
    }
}
