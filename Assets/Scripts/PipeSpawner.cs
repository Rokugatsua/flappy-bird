﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Global Variable
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private float holeSize = 1f;
    [SerializeField] private float maxMinOffset = 1;

    private Coroutine CR_Spawn;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();   
    }

    void StartSpawn()
    {
        if (CR_Spawn == null) {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        if (CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0,0,180));
        newPipeUp.gameObject.SetActive(true);

        Pipe newPipeDown = Instantiate(pipeUp, transform.position, Quaternion.identity);
        newPipeDown.gameObject.SetActive(true);

        // add hole
        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);

        // Spawnpipe offset
        float y = maxMinOffset * Mathf.Sin(Time.time);
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;
        
    }

    IEnumerator IeSpawn()
    {
        while(true)
        {
            if(bird.IsDead()) {
                StopSpawn();
            }
            SpawnPipe();

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
