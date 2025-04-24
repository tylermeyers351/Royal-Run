using UnityEngine;
using System.Collections.Generic;
using System;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] GameObject checkpointPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] ScoreManager scoreManager;


    [Header("Level Settings")]
    [Tooltip("Starting chunks")]
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] int checkpointChunkInterval = 8;
    [Tooltip("Do not change chunk length unless chunk prefab size reflects change")]
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 20f;
    [SerializeField] float minGravityZ = -22f;
    [SerializeField] float maxGravityZ = -2f;

    List<GameObject> chunks = new List<GameObject>();
    int ChunksSpawned = 0;

    void Start()
    {
        SpawnChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        float newMoveSpeed = speedAmount + moveSpeed;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);

        if (newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;
            
            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, minGravityZ, maxGravityZ);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);
            
            cameraController.ChangeCameraFOV(speedAmount);
        }


        
    }

    void SpawnChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            GameObject chunkToSpawn;
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + (chunkLength * i));

            if (i % checkpointChunkInterval == 0 && i > 0)
            {
                chunkToSpawn = checkpointPrefab;
            }
            else 
            {
                chunkToSpawn = chunkPrefabs[UnityEngine.Random.Range(0,chunkPrefabs.Length)];
            }
            
            GameObject newChunkGO = Instantiate(chunkToSpawn, newPosition, Quaternion.identity, chunkParent);

            chunks.Add(newChunkGO);
            Chunk newChunk = newChunkGO.GetComponent<Chunk>();
            newChunk.Init(this, scoreManager);
        }
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(0, 0, -moveSpeed * Time.deltaTime);

            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                Vector3 newPosition = chunks[chunks.Count - 1].transform.position;
                newPosition.z += chunkLength; 
                GameObject chunkToSpawn = chunkPrefabs[UnityEngine.Random.Range(0,chunkPrefabs.Length)];
                GameObject newChunk = Instantiate(chunkToSpawn, newPosition, Quaternion.identity, chunkParent);

                chunks.Add(newChunk);

                chunks.Remove(chunk);
                Destroy(chunk);

                
            }

        }
    }
}
