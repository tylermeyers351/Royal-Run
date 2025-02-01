using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;

    void Start()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + (chunkLength * i));
            Instantiate(chunkPrefab, newPosition, Quaternion.identity, chunkParent);
        }
    }
}
