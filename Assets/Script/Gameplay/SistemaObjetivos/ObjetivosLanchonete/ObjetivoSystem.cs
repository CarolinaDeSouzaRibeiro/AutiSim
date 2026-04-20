using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ObjetivoSystem : MonoBehaviour{
    public GameObject PontoCaixa;
    public GameObject BotaoPedido;
    public Transform[] chairPoints;
    public GameObject bandeja;
    public GameObject player;

    private enum ObjetivoState {
        WalkToCashier,
        MakeOrder,
        WalkToChair,
        EatFood,
        Completed
    }

    private ObjetivoState objetivoAtual;
    private Transform cadeiraSelecionada;

    // private List<InputDevice> devicesWithPrimaryButton;

    void Start()
    {
        objetivoAtual = ObjetivoState.WalkToCashier;
        Debug.Log("Quest started: Walk to the cashier.");

        // devicesWithPrimaryButton = new List<InputDevice>();
        // InputDevices.GetDevices(devicesWithPrimaryButton);
    }

    public void CompleteFirstQuest()
    {
        objetivoAtual = ObjetivoState.MakeOrder;
        BotaoPedido.SetActive(true);
    }

    public void Complete2ndQuest()
    {
        StartCoroutine(Complete2ndQuestCoroutine());
    }

    private System.Collections.IEnumerator Complete2ndQuestCoroutine()
    {
        objetivoAtual = ObjetivoState.WalkToChair;
        
        yield return new WaitForSeconds(5f);
        
        bandeja.SetActive(true);
    }


    // void Update()
    // {
    //     switch (objetivoAtual)
    //     {
    //         case ObjetivoState.WalkToChair:
    //             CheckPlayerPositionMultipleChairs(chairPoints, "Eat your food.");
    //             break;

    //         case ObjetivoState.EatFood:
    //             if (IsPrimaryButtonPressed())
    //             {
    //                 Debug.Log("Food eaten. Quest completed!");
    //                 objetivoAtual = ObjetivoState.Completed;
    //             }
    //             break;

    //         case ObjetivoState.Completed:
    //             Debug.Log("You have completed the quest!");
    //             break;
    //     }


    // private void CheckPlayerPosition(Vector3 targetPosition, string nextTaskMessage)
    // {
    //     float distance = Vector3.Distance(player.transform.position, targetPosition);
    //     if (distance < 1.5f) // Adjust the distance threshold as needed
    //     {
    //         Debug.Log(nextTaskMessage);
    //         objetivoAtual++;
    //     }
    // }

    // private void CheckPlayerPositionMultipleChairs(Transform[] chairPositions, string nextTaskMessage)
    // {
    //     foreach (Transform chair in chairPositions)
    //     {
    //         float distance = Vector3.Distance(player.transform.position, chair.position);
    //         if (distance < 1.5f) // Adjust the distance threshold as needed
    //         {
    //             Debug.Log(nextTaskMessage);
    //             cadeiraSelecionada = chair; // Store the selected chair
    //             objetivoAtual = ObjetivoState.EatFood;
    //             break;
    //         }
    //     }
    // }
}