using System;
using System.Collections;
using System.Linq;
using UnityEngine;

//namespace AutiSim.Assets.Script.Gameplay.SistemaObjetivos.ObjetivosLanchonete

public class PontoCaixa : MonoBehaviour {
	public ObjetivoSystem objetivoManager;

	void OnTriggerStay(Collider other) {
		Debug.Log("Colisão com ponto do caixa");
        if (other.CompareTag("Player")) {
			Debug.Log("JOGADOR NO PONTO DO CAIXA");
			objetivoManager.CompleteFirstQuest();

			//destroi ponto do caixa
			Destroy(gameObject);
        }
    }
}