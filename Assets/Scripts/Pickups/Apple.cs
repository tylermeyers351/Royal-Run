using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 2f;
    FootstepPlayer footstepPlayer;
    
    LevelGenerator levelGenerator;
    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        footstepPlayer = FindFirstObjectByType<FootstepPlayer>();
    }

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        // Debug.Log("Power up!");
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        playerController.updateMoveSpeed(1);
        footstepPlayer.ChangeStepInterval(-0.02f);
    }
}
