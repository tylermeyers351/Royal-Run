using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource musicAudio;

    void Start()
    {
        musicAudio.time = 2f;
        musicAudio.Play();
    }
}
