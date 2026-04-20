using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI enunciadoText;
    public Button[] answerButtons;
    public Button btnFim;
    private int currentQuestionIndex = 0;

    private string[] questions = {
        "Qual é a capital do Brasil?",
        "Qual é a fórmula química da água?",
        "Quem escreveu 'Dom Casmurro'?",
        "Quanto é 5 + 3?",
        "Qual destes é um planeta do Sistema Solar?",
        "Qual é o maior órgão do corpo humano?",
        "Em que continente fica o Brasil?",
        "De qual língua vem originalmente a palavra “pizza”?",
        "Qual é o resultado de 10 × 2?",
        "Qual destes animais é um mamífero?",
        "Em que país se fala principalmente o idioma espanhol?",
        "Qual destes é um instrumento musical de cordas?",
        "Qual destas datas representa o Dia da Independência do Brasil?"
    };

    private string[][] answers = {
        new string[] { "Rio de Janeiro", "Brasília", "São Paulo", "Salvador" },
        new string[] { "H2O", "CO2", "O2", "NaCl" },
        new string[] { "Machado de Assis", "Carlos Drummond", "Clarice Lispector", "Monteiro Lobato" },
        new string[] {"6 " ,"7 " ,"8 " ,"9"},
        new string[] {"Orion " ,"Andromeda " ,"Marte " ,"Sirius"},
        new string[] {"Coração " ,"Fígado " ,"Pele " ,"Pulmão"},
        new string[] {"Europa", "Ásia", "América do Sul", "África"},
        new string[] {"Francês " ,"Italiano " ,"Espanhol " ,"Inglês"},
        new string[] {"12 " ,"15 " ,"18 " ,"20"},
        new string[] {"Galinha " ,"Sapo " ,"Tubarão " ,"Cachorro"},
        new string[] {"Brasil " ,"México " ,"França " ,"Alemanha"},
        new string[] {"Flauta " ,"Violino " ,"Bateria " ,"Trompete"},
        new string[] {"21 de abril ","15 de novembro ","7 de setembro ","25 de dezembro"}
    };

    private int[] correctAnswers = { // Índices das respostas corretas
        1,
        0,
        0,
        2,
        2,
        2,
        2,
        1,
        3,
        3,
        1,
        1,
        2
        };

    void Start()
    {
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        enunciadoText.text = questions[currentQuestionIndex];

        for (int i = 0; i < answerButtons.Length; i++)
        {
            SetBtnQuestion(answerButtons[i],answers[currentQuestionIndex][i],i);
        }
    }

    void SetBtnQuestion(Button btn, string answer,int i)
    {
            btn.GetComponentInChildren<TextMeshProUGUI>().text = answer;
            int index = i; // Necessário para capturar o índice corretamente
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => CheckAnswer(index));
    }

    void CheckAnswer(int index)
    {
        if (index == correctAnswers[currentQuestionIndex])
        {
            Debug.Log("Resposta correta!");
        }
        else
        {
            Debug.Log("Resposta errada!");
        }

        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            enunciadoText.text = "Quiz finalizado!";

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].gameObject.SetActive(false);
            }

            btnFim.gameObject.SetActive(true);
        }
    }
}