using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] footstepSFX;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private float playRate;
    private float lastPlayTime;

    private void Update()
    {
        if (rig.linearVelocity.magnitude > 0 && Time.time - lastPlayTime > playRate)
        {
            Play();
        }
    }
    void Play()
    {
        lastPlayTime = Time.time;

        AudioClip clipToPlay = footstepSFX[Random.Range(0, footstepSFX.Length)];
        audioSource.PlayOneShot(clipToPlay);
    }
}
