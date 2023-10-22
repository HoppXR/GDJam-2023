using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints; // An array to hold references to your spawn points
    public GameObject[] HoleObjects; // Array of Hole objects
    public int numberOfHoles = 1; // Number of Holes you want to spawn

    private List<int> usedSpawnIndexes = new List<int>();

    void Start()
    {
        // Check if there are enough spawn points and Hole objects
        if (spawnPoints.Length < numberOfHoles || HoleObjects.Length < numberOfHoles)
        {
            Debug.LogError("Not enough spawn points or Hole objects for the number of Holes.");
            return;
        }

        // Spawn Holes
        for (int i = 0; i < numberOfHoles; i++)
        {
            SpawnHole();
        }
    }

    void SpawnHole()
    {
        int randomIndex;
        do
        {
            // Randomly select a spawn point that hasn't been used
            randomIndex = Random.Range(0, spawnPoints.Length);
        } while (usedSpawnIndexes.Contains(randomIndex));

        usedSpawnIndexes.Add(randomIndex);

        Transform selectedSpawnPoint = spawnPoints[randomIndex];

        // Randomly select a Hole object
        int randomObjectIndex = Random.Range(0, HoleObjects.Length);
        GameObject HoleObject = HoleObjects[randomObjectIndex];

        // Move the Hole object to the selected spawn point
        HoleObject.transform.position = selectedSpawnPoint.position;
        HoleObject.transform.rotation = selectedSpawnPoint.rotation;
    }
}
