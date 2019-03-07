using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    public AudioMixer masterMixer;
    
    /*functions to set individual levels of music/sfx or the master volume
    and pass the changes to variables in gamemanager so they stay on scenechanges*/
    public void SetSfxLvl(float sfxLvl)
    {
        masterMixer.SetFloat("sfxVol", sfxLvl);
        GameManager.instance._sfxLvl = sfxLvl;
    }
    public void SetMusicLvl(float musicLvl)
    {
        masterMixer.SetFloat("musicVol", musicLvl);
        GameManager.instance._musicLvl = musicLvl;
    }

    public void SetMasterLvl(float masterLvl)
    {
        masterMixer.SetFloat("masterVol", masterLvl);
        GameManager.instance._masterLvl = masterLvl;
    }
}
