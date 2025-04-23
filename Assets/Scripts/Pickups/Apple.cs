using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 2f;
    
    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        Debug.Log("Power up!");
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}
