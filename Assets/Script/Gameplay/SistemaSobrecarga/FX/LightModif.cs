using System.Linq;
using UnityEngine;


public static class LightModif : object {
	public static void AumentarIntensidadeLuz(float incrMultiplier, float increment = .08f, float maxIntensity = 5f)
	{
		// Encontra todos os componentes de luz
		Light[] luzes = Object.FindObjectsByType<Light>(FindObjectsSortMode.None).Where(luz => luz.CompareTag("LuzQueRecebeCarga")).Where(luz => luz.intensity < maxIntensity).ToArray();

		//percorre luzes
		foreach (Light luz in luzes)
		{
			//para alguma luz nao encontrada
			if (luz == null)
			{
				// UnityEngine.Debug.LogError($"Luz não encontrada no objeto {luz.gameObject.name}");
				continue;
			}

			luz.intensity = Mathf.Clamp(luz.intensity + increment*incrMultiplier, luz.intensity, maxIntensity);

			// UnityEngine.Debug.Log($"Intensidade de luz em {luz.gameObject.name}: {luz.intensity}");
		}
	}
}