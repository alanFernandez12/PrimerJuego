using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void salir()
    {
        Application.Quit();
    }
}
