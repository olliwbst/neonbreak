using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    public AudioClip menusong;
    public AudioClip gamesong;
    public AudioClip gunfx;
    public bool menu = false;
    public bool game = false;
    public bool shot = false;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();

        if (menu)
        {
            PlayMenuSong();
        }

        if (game)
        {
            PlayGameSong();
        }

        if (shot)
        {
            PlayGunFx();
        }
    }

    /*depending on active bool, the corresponding function is called.
     another form to choose the mode would be nice so multiple selections are impossible*/
    public void PlayMenuSong()
    {
        _audioSource.Stop();
        _audioSource.loop = true;
        _audioSource.PlayOneShot(menusong);
    }

    public void PlayGameSong()
    {
        _audioSource.Stop();
        _audioSource.loop = true;
        _audioSource.PlayOneShot(gamesong);
    }

    public void PlayGunFx()
    {
        _audioSource.loop = false;
        _audioSource.PlayOneShot(gunfx);
    }
}
