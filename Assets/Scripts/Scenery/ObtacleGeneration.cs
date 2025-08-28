using System.Collections.Generic;
using UnityEngine;

public class ObtacleGeneration : MonoBehaviour
{
    [SerializeField]
    List<GameObject> obstacles;

    public EndlessScroll endlessScroll;

    private static int lastRandomIndex = -1;
    private int randomIndex;

    private void Start()
    {
        InitilizeObstaclesList();
        EnableRamdonObstacles();
    }

    private void Update()
    {
        if (endlessScroll.platformRestored)
            EnableRamdonObstacles();
    }

    private void InitilizeObstaclesList()
    {
        obstacles = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag(TagConstants.obstacle))
                obstacles.Add(child.gameObject);
        }
    }

    private void EnableRamdonObstacles()
    {
        DisableAllObstacles();
        do
        {
            randomIndex = Random.Range(0, obstacles.Count);
        } while (randomIndex == lastRandomIndex);
        lastRandomIndex = randomIndex;
        obstacles[randomIndex].SetActive(true);
    }

    private void DisableAllObstacles()
    {
        foreach (GameObject obstacles in obstacles)
            obstacles.SetActive(false);
    }
}
