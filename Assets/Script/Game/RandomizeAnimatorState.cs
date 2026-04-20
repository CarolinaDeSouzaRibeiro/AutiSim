using UnityEngine;

public class RandomizeAnimatorState : MonoBehaviour {
    private Animator animator; // Referência ao Animator será automaticamente atribuída
    public string[] animationStates; // Lista de estados de animação para aleatorizar

    private void Awake() {
        // Tenta obter o componente Animator desse GameObject
        animator = GetComponent<Animator>();

        if (animator == null) {
            // Debug.LogError($"Nenhum Animator encontrado no GameObject '{gameObject.name}'. Certifique-se de que o Animator está presente.");
        }
    }

    private void Start(){
        if (animator == null || animationStates.Length == 0) {
            // Debug.LogWarning($"O script RandomizeAnimatorState no GameObject '{gameObject.name}' não está configurado corretamente.");
            return;
        }

        // Aleatorizar a animação inicial
        RandomizeAnimation();
    }

    public void RandomizeAnimation() {
        if (animator == null || animationStates.Length == 0) {
            // Debug.LogWarning($"Não foi possível aleatorizar a animação no GameObject '{gameObject.name}'. Verifique as configurações.");
            return;
        }

        // Seleciona um estado aleatório da lista
        int randomIndex = UnityEngine.Random.Range(0, animationStates.Length);
        string randomState = animationStates[randomIndex];

        // Define o estado no Animator
        animator.Play(randomState);
    }
}