using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieSpawnerBehaviour : MonoBehaviour
{
    public GameObject spawnPrefab;
    public  GameObject[] spawnPoints;
    public int [] numberInWave;
    public float [] timeBetweenWaves;
    public float timeBetweenSpawnInWave;
    private int spawnCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Transform rndSpawnPoint(){
        return spawnPoints[Random. Range(0, spawnPoints. Length)].transform;
    }

       Transform nextSpawnPoint(){
        return spawnPoints[spawnCounter++ % spawnPoints. Length ].transform;
    }

    Color rnd_color(){
        return new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
    }

    IEnumerator spawn(){

        for (int i =0; i < numberInWave.Length; i++){
            yield return new WaitForSeconds(timeBetweenWaves[i]);
            for (int j = 0; j < numberInWave[i]; j++)
            {
                Transform spawnTransform = nextSpawnPoint();

                GameObject newGO = Instantiate(spawnPrefab, spawnTransform.position, spawnTransform.localRotation);
                yield return new WaitForSeconds(timeBetweenSpawnInWave);
            }
            
        }        
        //StartCoroutine(spawn());
    }
}
