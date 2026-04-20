using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BotaoPedido : MonoBehaviour
{
    public ObjetivoSystem objetivoManager;

    public void OnButtonClick()
    {
        objetivoManager.Complete2ndQuest();

        Destroy(gameObject);
    }
}