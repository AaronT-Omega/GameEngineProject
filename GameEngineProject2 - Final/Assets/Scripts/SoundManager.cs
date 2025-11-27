using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
    PlayerAttack,
    PlayerHit,
    EnemyHit,
    EnemyDefeat
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioClip[] soundList;
    private AudioSource _audioSource;
    [SerializeField] private PlayerController player;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        SoundManager.Instance._audioSource.PlayOneShot(SoundManager.Instance.soundList[(int)sound], volume);
    }


    public override void Notify(Subject subject, IPlayerStates state) // Overides the Notify function
    {

        if (player)
        {
            if (state == player._hitState)
            {
                PlaySound(SoundType.PlayerHit);
            }

        }

    }
}