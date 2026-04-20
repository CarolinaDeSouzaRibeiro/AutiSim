// 29/11/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneOnClick : MonoBehaviour
{
    public string sceneName; // Nome da cena para onde você quer ir

    public void ChangeScene()
    {
        // Carrega a cena especificada
        SceneManager.LoadScene(sceneName);
    }
}
