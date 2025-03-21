using UnityEngine;

public class Apple : Pickup
{
    LevelGenerator levelGenerator;
    [SerializeField] float adjustChangeMoveSpeedAmount = 2f;

    void Start()
    {
        levelGenerator = FindAnyObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        Debug.Log("Power up!");
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}
