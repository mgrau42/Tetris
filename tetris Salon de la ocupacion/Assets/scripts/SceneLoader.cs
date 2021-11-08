using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void ResetScene()
    {
        // Cargamos la escena, solo hay una
        //      Para poder cargar escenas primero hay que añadirlas a las building settings
        SceneManager.LoadScene(0);
    }
}
