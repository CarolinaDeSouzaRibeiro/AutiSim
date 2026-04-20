using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;


public static class AudioModif : object {
	public static void AumentarVolume(float incrMultiplier, float increment = .8f, float maxVolume = 20f)
    {
        AudioMixer audioMixer = Resources.Load<AudioMixer>("MixerTst");

        // Obtém volume atual
        float volumeAtual;
        audioMixer.GetFloat("VolumeNewGroup", out volumeAtual);

        // Aumenta o volume
        float novoVolume = Mathf.Clamp(volumeAtual + increment * incrMultiplier, volumeAtual, maxVolume);

        audioMixer.SetFloat("VolumeNewGroup", novoVolume);
        UnityEngine.Debug.Log($"Volume mudado de {volumeAtual} dB para {novoVolume} dB");
    }
}