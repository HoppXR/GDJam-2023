using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints; // An array to hold references to your spawn points
    public GameObject[] playerObjects; // Array of player objects
    public int numberOfPlayers = 3; // Number of players you want to spawn

    private List<int> usedSpawnIndexes = new List<int>();

    void Start()
    {
        // Check if there are enough spawn points and player objects
        if (spawnPoints.Length < numberOfPlayers || playerObjects.Length < numberOfPlayers)
        {
            Debug.LogError("Not enough spawn points or player objects for the number of players.");
            return;
        }

        // Spawn players
        for (int i = 0; i < numberOfPlayers; i++)
        {
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {
        int randomIndex;
        do
        {
            // Randomly select a spawn point that hasn't been used
            randomIndex = Random.Range(0, spawnPoints.Length);
        } while (usedSpawnIndexes.Contains(randomIndex));

        usedSpawnIndexes.Add(randomIndex);

        Transform selectedSpawnPoint = spawnPoints[randomIndex];

        // Randomly select a player object
        int randomObjectIndex = Random.Range(0, playerObjects.Length);
        GameObject playerObject = playerObjects[randomObjectIndex];

        // Move the player object to the selected spawn point
        playerObject.transform.position = selectedSpawnPoint.position;
        playerObject.transform.rotation = selectedSpawnPoint.rotation;
    }
}
