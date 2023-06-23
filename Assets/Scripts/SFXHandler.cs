using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SFXHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _shootSFX,_powerupSFX,_explosionSFX;
    [SerializeField] private AudioSource _audioSource;

    public void PlayShotSFX()
    {
        _audioSource.PlayOneShot(_shootSFX, 0.25f);
    }

    public void PlayPowerUpSFX()
    {
        _audioSource.PlayOneShot(_powerupSFX, 0.25f);
    }

    public void PlayExplosionSFX()
    {
        _audioSource.PlayOneShot(_explosionSFX, 0.25f);
    }


}
