using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject powerupContainer; //Container to place all of the powerups into
    public int spawnCooldown = 1000;    //Time (in frames) until the next powerup spawns
    private int timeUntilSpawn = 0;     //Time until the next powerup spawns
    private Transform[] locations;      //The transforms of each powerup spawner; index 0 is the powerup spawner controller
    private int numLocations;           //The number of powerup spawners

    // Start is called before the first frame update
    void Start()
    {
        locations = GetComponentsInChildren<Transform>();
        numLocations = locations.Length;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        timeUntilSpawn++;
        //When it is time for a powerup to spawn
        if (timeUntilSpawn >= spawnCooldown) {
            //Tries to spawn a powerup at a random powerup spawner
            //in productions: If all locations already have powerups, doesn't spawn a powerup
            int locIndex = Random.Range(1, numLocations), checks = 0;
            bool spawned = false;
            while (!spawned && checks < numLocations) {
                //If the location is free
                if (/*locations[locIndex]*/ true) {
                    //Spawn a random powerup at this location
                    GameObject powerup = Instantiate(powerupPrefab, locations[locIndex].position, Quaternion.identity, powerupContainer.transform);
                    powerup.GetComponent<Powerup>().type = (Powerup.PowerupType)Random.Range(0, (int)Powerup.PowerupType.NA);
                    spawned = true;
                } else {
                    //Check the next location
                    locIndex = (locIndex + 1) % numLocations;
                    checks++;
                }
            }
            timeUntilSpawn = 0;
        }
    }
}
