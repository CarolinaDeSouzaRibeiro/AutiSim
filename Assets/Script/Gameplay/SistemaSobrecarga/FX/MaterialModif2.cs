using System;
using UnityEditor;
using UnityEngine;
using System.Linq;

public static class MaterialModif2
{
    // List<String> propriedades = new List<String>() {"_EmissionColor","_NormalScale "};

    public static Material[] ObterMateriais(){
        MeshRenderer[] listaMeshes = UnityEngine.Object.FindObjectsByType<MeshRenderer>(FindObjectsSortMode.None).Where(mesh => mesh.gameObject.CompareTag("MatQueRecebeCarga")).ToArray();
        // Obtem materiais
        Material[] listaMateriais = listaMeshes.SelectMany(mesh => mesh.materials).Where(m => m != null).ToArray();

        return listaMateriais;
    }

    public static void AlterarMaterial(float incrEmissao = .0f, float incrMetallic = .0f, float incrSmoothness = .0f, int incrNormal = 0,float emissaoMaxima = .5f)
    {
        Material[] listaMateriais = ObterMateriais();

        foreach (var material in listaMateriais)
        {
            SetarEmissao(material, incrEmissao, emissaoMaxima);
            SetarFloat(material, "_Metallic", incrMetallic, .2f);
            SetarFloat(material, "_Smoothness", incrSmoothness);
            // SetarMetallic(material, incrMetallic);
            // SetarSmoothness(material, incrSmoothness);
            SetarNormalStr(material, incrNormal);
        }
    }

    private static void SetarEmissao(Material material, float incrEmissao, float emissaoMaxima){
        if (incrEmissao != .0f)
        {
            Color emissaoAtual = material.GetColor("_EmissionColor");
            Color novaEmissao = emissaoAtual;
            novaEmissao.r = Mathf.Clamp(emissaoAtual.r + incrEmissao, 0, emissaoMaxima);
            novaEmissao.g = Mathf.Clamp(emissaoAtual.g + incrEmissao, 0, emissaoMaxima);
            novaEmissao.b = Mathf.Clamp(emissaoAtual.b + incrEmissao, 0, emissaoMaxima);

            material.SetColor("_EmissionColor", novaEmissao);
            Debug.Log($"Intensidade de emissão do material alterada para: {novaEmissao}");
        }
    }

    private static void SetarFloat(Material material, string propriedade, float incr, float limite = .5f){
        if (incr != .0f)
        {
            float atual = material.GetFloat(propriedade);
            float novo = Mathf.Clamp(atual + incr, 0f, limite);
            material.SetFloat(propriedade, novo);
            Debug.Log($"{propriedade} alterado pra: {novo}");
        }
    }

    // private static void SetarMetallic(Material material, float incrMetallic){
    //     if (incrMetallic != .0f)
    //     {
    //         float metallicAtual = material.GetFloat("_Metallic");
    //         material.SetFloat("_Metallic", metallicAtual + incrMetallic);
    //         Debug.Log($"Valor de Metallic do material alterado para: {metallicAtual + incrMetallic}");
    //     }
    // }

    // private static void SetarSmoothness(Material material, float incrSmoothness){
    //     if (incrSmoothness != .0f)
    //     {
    //         float smoothnessAtual = material.GetFloat("_Smoothness");
    //         // Alterar valor de Smoothness
    //         material.SetFloat("_Smoothness", Mathf.Clamp(smoothnessAtual - incrSmoothness/100, 0, 1));
    //         Debug.Log($"Valor de Smoothness do material alterado para: {smoothnessAtual + incrSmoothness}");
    //     }
    // }

    private static void SetarNormalStr(Material material, int incrNormal){
        if (incrNormal != 0)
        {
            int normalAtual = material.GetInt("_NormalScale");

            material.SetInt("_NormalScale", Mathf.Clamp(normalAtual + incrNormal, 0, 10));
            Debug.Log($"Força da Normal alterada para: {material.GetInt("_NormalScale")}");
        }
    }
}