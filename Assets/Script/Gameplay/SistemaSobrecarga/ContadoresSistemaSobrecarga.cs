using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using System.Linq;
using System.Drawing;

public class ContadoresSistemaSobrecarga : MonoBehaviour
{
    // public GameObject vignettePrefab; // Assign the Vignette prefab in the Inspector
    // public Material vignetteMaterial; // Assign the Vignette material in the Inspector

    public static int contadorSobrecarga; //Nivel atual da sobrecarga
    static double efetividadeCope; //Multiplicador geral do efeito de enfrentamentos. Entre 0 e 100. 100 Por padrão
    static double efetividadeGatilho; //Multiplicador da efetividade dos gatilhos. Entre 0 e 200. 100 por padrão
    static double taxaMudancaEff; //taxa de mudança da efetividade
    // static Material[] listaMateriais;
    
    void Start()
    {
        //Inicializando
        contadorSobrecarga = 0;
        efetividadeCope = 1;
        efetividadeGatilho = 1;
        taxaMudancaEff = 0.001;

        // listaMateriais = MaterialModif2.ObterMateriais();
    }

    // atualização do valor de sobrecarga, resultando em atualizacoes das efetividades e dos efeitos
    static void AtualizacoesSobrecarga(float sobrecargaGerada)
    {
        contadorSobrecarga += Mathf.CeilToInt(sobrecargaGerada);

        //Usa clamp para limitar a quantidade de efetividade que pode ser recebida só de uma vez
        efetividadeGatilho += Clampers.ClampDouble(contadorSobrecarga * taxaMudancaEff, 0.0, 100.0);
        efetividadeCope -= Clampers.ClampDouble(contadorSobrecarga * taxaMudancaEff, 0.001, 10.0);


        //clamp no valor da sobrecarga e das efetividades
        contadorSobrecarga = Clampers.ClampInt(contadorSobrecarga, 0, 500);
        efetividadeGatilho = Clampers.ClampDouble(efetividadeGatilho, 0.001, 15.0);
        efetividadeCope = Clampers.ClampDouble(efetividadeCope, 0.001, 5.0);
    }

    public static void EfeitosGatilhos(float forcaGatilho)
    {
        if (contadorSobrecarga % 10 == 0)
        {
            UnityEngine.Debug.Log("Sobrecarga: " + contadorSobrecarga + "\nEfetividade gatilho: " + efetividadeGatilho + "\nEfetividade enfrentamento: " + efetividadeCope);
            //volume
            AudioModif.AumentarVolume(forcaGatilho);
            //luz
            LightModif.AumentarIntensidadeLuz(forcaGatilho);
            //mat
            MaterialModif2.AlterarMaterial(forcaGatilho, .1f, .1f, 1);
            // MaterialModif.AlterarMaterial(UnityEngine.Color.red, forcaGatilho, 10f);
        }
    }

    // Função chamada quando o jogador é exposto a um gatilho
    public static void GatilhoAtivado(float forcaGatilho)
    {
        float sobrecargaGerada = (float)(forcaGatilho * efetividadeGatilho);
        // UnityEngine.Debug.Log("Gatilho ativado! Forca: " + sobrecargaGerada);

        AtualizacoesSobrecarga(sobrecargaGerada); //atualiza

        //chama efeitos
        EfeitosGatilhos(forcaGatilho);
    }
}