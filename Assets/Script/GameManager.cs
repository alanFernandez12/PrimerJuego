using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Hud hud;
	private int vidas = 4;
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
}
