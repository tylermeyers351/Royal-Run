using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] footstepSounds;
    [SerializeField] float stepInterval = 0.2f;

    float stepTimer = 0f;

    void Update()
    {
        stepTimer -= Time.deltaTime;

        if (stepTimer <= 0f)
        {
            PlayFootstep();
            stepTimer = stepInterval;
        }
    }

    void PlayFootstep()
    {
        int randomIndex = Random.Range(0, footstepSounds.Length);
        audioSource.clip = footstepSounds[randomIndex];
        audioSource.Play();
    }

    public void ChangeStepInterval(float amount)
    {
        stepInterval = Mathf.Max(0.05f, stepInterval + amount);
    }

}
