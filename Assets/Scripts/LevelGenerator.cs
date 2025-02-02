using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;

    GameObject[] chunks =  new GameObject[12];

    void Start()
    {
        SpawnChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    void SpawnChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + (chunkLength * i));
            GameObject newChunk = Instantiate(chunkPrefab, newPosition, Quaternion.identity, chunkParent);

            chunks[i] = newChunk;
        }
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].transform.Translate(0, 0, moveSpeed * Time.deltaTime * -1);
        }
    }
}
