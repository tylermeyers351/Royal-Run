using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 20f;

    List<GameObject> chunks = new List<GameObject>();

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
        moveSpeed += speedAmount;

        if (moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        } 
        else if (moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);

        cameraController.ChangeCameraFOV(speedAmount);
        
    }

    void SpawnChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + (chunkLength * i));
            GameObject newChunk = Instantiate(chunkPrefab, newPosition, Quaternion.identity, chunkParent);

            chunks.Add(newChunk);
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
                GameObject newChunk = Instantiate(chunkPrefab, newPosition, Quaternion.identity, chunkParent);

                chunks.Add(newChunk);

                chunks.Remove(chunk);
                Destroy(chunk);

                
            }

        }
    }
}
