using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicPlayer;

    public bool MuteUnmuteSound()
    {
        return musicPlayer.mute = !musicPlayer.mute;
    }
}
