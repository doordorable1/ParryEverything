using UnityEngine;
using System.Collections.Generic;


public class SoundManager : Singleton<SoundManager>
{
    public AudioSource playerAudioSource;
    public AudioSource bossAudioSource;
    public AudioSource bgmAudioSource;


    public AudioClip bgm;
    public float bgmVolume;
    public AudioClip walkSound;
    public float walkSoundVolume;
    public AudioClip jumpSound;
    public float jumpSoundVolume;
    public AudioClip attackSound;
    public float attackSoundVolume;
    public AudioClip hitSound;
    public float hitSoundVolume;
    public AudioClip dieSound;
    public float dieSoundVolume;
    public AudioClip skillSound;
    public float skillSoundVolume;

    private void Start()
    {
        PlayBGMSound(bgm, bgmVolume);
    }

    public void PlayBGMSound(AudioClip clip, float volume = 1f)
    {
        if (clip != null && bgmAudioSource != null)
        {
            bgmAudioSource.clip = clip;
            bgmAudioSource.volume = volume;
            bgmAudioSource.Play();
        }
    }
    public void PlayWalkSound()
    {
        playerAudioSource.PlayOneShot(walkSound, walkSoundVolume);
    }

}
