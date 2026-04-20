using TMPro; // Para usar os textos de TextMeshPro
using UnityEngine;
using UnityEngine.UI; // Para usar o Button

public class DialogueManager : MonoBehaviour {
    // Estrutura que representa cada linha de diálogo
    [System.Serializable]
    public struct Line {
        public string speaker; // Nome de quem está falando
        [TextArea] public string text; // Texto da fala
    }

    // ----------  Referencias da UI (Setáveis no componente) ----------

    [Header("UI refs")]
    public TextMeshProUGUI speakerText; // Nome do NPC a falar
    public TextMeshProUGUI bodyText; //Texto da fala
    public CanvasGroup canvasGroup; // Para controlar a opacidade do painel
    public Button nextButton; // Botão para avançar o diálogo

    // Conteúdo do diálogo	
    [Header("Content")]
    public Line[] conversation; // Array de linhas de diálogo

    // Índice da fala atual
    int idx = -1; // (começa em -1 pra chamar logo a 1a fala, já que  esse primeiro incremento do Advance() resultara em 0)

    // Clique do botão
    void Awake() => nextButton.onClick.AddListener(Advance);

    //Início
    void Start() => Advance();

    // Metodo para avançar as falas do diálogo
    void Advance() {
        idx++; // Segue para a próxima fala (ou primeira, se o idx for -1, o qual é o caso ao iniciar)

        // Caso as linhas tenham acabado
        if (idx >= conversation.Length) {
            canvasGroup.alpha = 0; // Esconde painel
            nextButton.interactable = false; // Desabilita botão
            return;
        }

        // Atualiza objetos TextMeshPro com seus respectivos textos atuais
        speakerText.text = conversation[idx].speaker;
        bodyText.text    = conversation[idx].text;
    }
}
