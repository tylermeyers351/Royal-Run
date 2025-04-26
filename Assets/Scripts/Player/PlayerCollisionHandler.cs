using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionTime = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource appleAudio;
    [SerializeField] AudioSource coinAudio;

    [SerializeField] FootstepPlayer footstepPlayer;

    const string hitString = "Hit";
    float cooldownTimer = 0f;

    LevelGenerator levelGenerator;
    PlayerController playerController;

    void Start()
    {
        levelGenerator = FindAnyObjectByType<LevelGenerator>();
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {   
        if (cooldownTimer < collisionTime) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
        playerController.updateMoveSpeed(-1);
        
        int randomIndex = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[randomIndex];
        audioSource.Play();
        footstepPlayer.ChangeStepInterval(0.02f);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            appleAudio.Play();
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            coinAudio.Play();
        }
    }
}
