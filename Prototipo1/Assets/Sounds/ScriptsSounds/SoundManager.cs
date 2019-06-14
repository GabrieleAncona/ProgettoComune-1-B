using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager {


    public enum Sound
    {
        curaHealer,
        esplosione,
        fireball,
        ghiaccio,
        tankAbility,
        swingMelee,
        tankDie,
        maleDie,
        healerDie,
        utilityDie,
        meleeAndVoice,
        confirm,
        tankVoice,
        healerVoice,
        utilityVoice,
        dealerVoice,



    }
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
            Debug.LogError("Sound" + sound + "not found!");
            
        }
        return null;
    }
}
