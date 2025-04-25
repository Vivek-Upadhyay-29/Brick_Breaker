
using UnityEngine;
using UnityEngine.UI;
public class SfxManager : MonoBehaviour
{
    
    public Slider volumeSlider;
    public float sfxVolume;
    void Update()
    {
        sfxVolume = volumeSlider.value;
        AudioMangerScript.Instance.audioSource.volume = sfxVolume;
    }
}

