using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// Audio clip that will be played when snake collects an apple.
    /// </summary>
    public AudioClip AppleClip;

    /// <summary>
    /// Audio clip that will be played when snake collects a bonus.
    /// </summary>
    public AudioClip BonusClip;

    /// <summary>
    /// Audio clip that will be played when game is over.
    /// </summary>
    public AudioClip GameOverClip;

    /// <summary>
    /// Audio source for an apple sound clip.
    /// </summary>
    private AudioSource appleAudioSource;

    /// <summary>
    /// Audio source for a bonus sound clip.
    /// </summary>
    private AudioSource bonusAudioSource;

    /// <summary>
    /// Audio source for a game over sound clip.
    /// </summary>
    private AudioSource gameOverAudioSource;

    // Use this for initialization
    void Awake()
    {
        if (AppleClip != null)
        {
            appleAudioSource = gameObject.AddAudio(AppleClip, false, false, 1f);
        }
        if (BonusClip != null)
        {
            bonusAudioSource = gameObject.AddAudio(BonusClip, false, false, 1f);
        }
        if (GameOverClip != null)
        {
            gameOverAudioSource = gameObject.AddAudio(GameOverClip, false, false, 1f);
        }
    }

    public void PlayAppleSoundEffect()
    {
        if (appleAudioSource != null)
        {
            appleAudioSource.Play();
        }
    }

    public void PlayBonusSoundEffect()
    {
        if (bonusAudioSource != null)
        {
            bonusAudioSource.Play();
        }
    }

    public void PlayGameOverSoundEffect()
    {
        if (gameOverAudioSource != null)
        {
            gameOverAudioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
