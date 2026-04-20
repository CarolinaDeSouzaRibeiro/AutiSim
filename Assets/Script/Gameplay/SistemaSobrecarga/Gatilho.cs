using UnityEngine;

public class Gatilho : MonoBehaviour {
    [System.Serializable]
    public struct ConfigGatilho {
        public float forcaGatilho;
        // public bool isSonoro;
    }
    public float forcaGatilho;
    // public bool isSonoro; //se falso, é um gatilho visual
    private float lastTriggerTime = 0f; // Armazena o tempo da última execução

    //evento para quando entrar no raio do colisor de trigger do objeto
    void OnTriggerStay(Collider other) {
        // Verifica se o objeto que colidiu possui a tag "Player"
        if (other.CompareTag("Player")) {
            // Verifica se passou 1 segundo desde a última execução
            if (Time.time - lastTriggerTime >= 1f) {
                lastTriggerTime = Time.time; // Atualiza o tempo da última execução

                ContadoresSistemaSobrecarga.GatilhoAtivado(forcaGatilho); //atualiza gatilho
            }
        }
    }
}