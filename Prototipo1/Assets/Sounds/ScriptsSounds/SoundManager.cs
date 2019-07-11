using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager {


    public enum Sound
    {
        tankVoice,
        tankAttack,
        tankAbility,
        tankDie,
        utilityVoice,
        utilityAttack,
        utilityAbility,
        utilityDie,
        dealerVoice,
        dealerAttack,
        dealerAbility,
        esplosione,
        dealerDie,
        healerVoice,
        healerAttack,
        healerAbility,
        healerDie,
        confirm,
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
            
        }
        return null;
    }
}
