using System.Collections.Generic;
using UnityEngine;

public class ScenaryGeneration : MonoBehaviour
{
    [SerializeField]
    List<GameObject> scenarios;
    [SerializeField]
    bool isTheFirstScene;
    [SerializeField]
    bool isTheSecondScene;

    /*[SerializeField]
    private GameObject stationTunnel;
    [SerializeField]
    private GameObject tunnelScenary;
    [SerializeField]
    private GameObject nextSelectiveObstacleGeneration;

    private bool transitionScenary;
    private bool reset;*/

    private static int lastRandomIndex;
    private int randomIndex;

    private EndlessScroll endlessScroll;

    private GameObject currentScenary;

    private void Start()
    {
        endlessScroll = GetComponent<EndlessScroll>();
        if (isTheSecondScene)
            lastRandomIndex = GetIndexByName("SceneryStreet");
        if (!isTheFirstScene)
            EnableRandomScenary();
    }

    private void Update()
    {
        if (endlessScroll.platformRestored)
        {
            /*if (reset)
                return;*/
            EnableRandomScenary();

            /*reset = true;
            Invoke("ResetReset", 1);*/
        }
    }

    /*private void ResetReset()
    {
        reset = false;
    }*/

    private void EnableRandomScenary()
    {
        DisableAllScenary();

        /*if (transitionScenary)
        {
            nextSelectiveObstacleGeneration.GetComponent<ScenaryGeneration>().currentScenary = tunnelScenary;
            Debug.Log("Hola");
            transitionScenary = false;
        }
        else
        {*/
        do
        {
            randomIndex = Random.Range(0, scenarios.Count);
        } while (randomIndex == lastRandomIndex);

        lastRandomIndex = randomIndex;
        currentScenary = scenarios[randomIndex];

        /*if (currentScenary == stationTunnel)
            transitionScenary = true;
        }*/
        currentScenary.SetActive(true);
    }

    private void DisableAllScenary()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public int GetIndexByName(string objectName)
    {
        for (int i = 0; i < scenarios.Count; i++)
        {
            if (scenarios[i].name == objectName)
                return i;
        }
        return -1;
    }
}
