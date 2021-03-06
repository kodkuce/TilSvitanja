using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : Singleton<AudioSystem>
{
    public AudioClip npcRevolverShoot;

    void Start()
    {
        GameEvents.Instance.PlaySFX += OnPlaySFX;
    }

    void OnDestroy()
    {
        GameEvents.Instance.PlaySFX -= OnPlaySFX;
    }


    private void OnPlaySFX(string what, float volume)
    {
        if (typeof(AudioSystem).GetField(what) == null)
        {
            Debug.LogWarning("Missing sound named " + what);
        }
        else
        {
            //Debug.Log("should play " + what);
            foreach (AudioSource audioSource in gameObject.GetComponentsInChildren<AudioSource>())
            {
                if (audioSource.isPlaying == false)
                {
                    AudioClip audioClip = null;

                    //If have multiple sounds for same, pick random form list
                    if( typeof(AudioSystem).GetField(what).GetValue(this) is IList )
                    {
                        List<AudioClip> audioClips = typeof(AudioSystem).GetField(what).GetValue(this) as List<AudioClip>;
                        int r = UnityEngine.Random.Range(0,audioClips.Count);
                        audioClip = audioClips[r];
                    }else
                    {
                        audioClip = typeof(AudioSystem).GetField(what).GetValue(this) as AudioClip;
                    }

                    audioSource.PlayOneShot(audioClip, volume);
                    return;
                }
            }
        }
    }
}
