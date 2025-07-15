using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
	public GameObject menuPausa;
    public Hud hud;
	private int vidas = 4;
	public bool pausa = false;
	private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }
    private void Update()
    {
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (pausa)
			{
				reaundar();
			}
			else
			{
				pausar();
			}
		}
    }
    public void PerderVida()
	{
		vidas -= 1;

		if (vidas == 0)
		{
			
		}

		hud.DesactivarVida(vidas);
	}

	public bool RecuperarVida()
	{
		if (vidas == 4)
		{
			return false;
		}

		hud.ActivarVida(vidas);
		vidas += 1;
		return true;
	}
	public void reaundar()
	{
		menuPausa.SetActive(false);
		Time.timeScale = 1;
		pausa = false;
	}

	public void pausar()
	{
		menuPausa.SetActive(true);
		Time.timeScale = 0;
		pausa = true;
	}

    public void salir()
    {
        Application.Quit();
    }
}
