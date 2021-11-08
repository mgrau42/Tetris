using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	// Puntuación y multiplicador de putos
    int score = 0;

    [Space]
    // Texto de la interfaz
    [SerializeField] Text scoreUI = null;
    [SerializeField] Text dethScreenScore = null;


    // -----------------------------------------------------------------------
    /* START */
    private void Start()
    {
        UpdateUI();
    }

    // -----------------------------------------------------------------------

    /* Añadir putuacion */
    public void AddScore(int amount)
    {
        score += (int)(amount);
        UpdateUI();
    }


    // -----------------------------------------------------------------------

    /* Actualizar la interfaz */
    void UpdateUI()
    {
        scoreUI.text = score.ToString();
        // Actualizar la puntuacion en la pantalla de muerte
        dethScreenScore.text = score.ToString();
    }
}