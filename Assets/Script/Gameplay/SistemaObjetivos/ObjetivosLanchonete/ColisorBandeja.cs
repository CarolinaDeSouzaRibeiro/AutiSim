using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ColisorBandeja : MonoBehaviour {
    public bool isBarulhento; //se sim, ao colocar a bandeja, recebe aviso "muito barulhento...", se não, termina a fase
    public TextMeshProUGUI textoAviso;
    private bool isColliding = false;

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("bandeja") && !isColliding) {
            isColliding = true; // Evita múltiplas chamadas da coroutine

            if (isBarulhento)
            {
                StartCoroutine(AvisoBarulho());
            }
            else
            {
                StartCoroutine(TrocaCena());
            }
            
        }
    }

    //corotina troca de fsae
    private IEnumerator TrocaCena() {
        Debug.Log("Colisão com colisor de bandeja detectada. Aguardando 1 segundo...");
        yield return new WaitForSeconds(1f); // Aguarda 1 segundo
        Debug.Log("Trocando para a cena StartScreen...");
        SceneManager.LoadScene("StartScreen"); // Troca para a cena StartScreen
    }

    //corotina barulho
    private IEnumerator AvisoBarulho() {
        Debug.Log("Colisão com colisor de bandeja detectada. Aguardando 1 segundo...");
        yield return new WaitForSeconds(3f); // Aguarda 1 segundo
        textoAviso.text = "Muito barulhento...";
        Debug.Log("Trocando para a cena StartScreen...");
        yield return new WaitForSeconds(2f); // Aguarda 1 segundo
        textoAviso.text = "";
    }
}