using UnityEngine;
using UnityEngine.UI;
public class SettingAudio : MonoBehaviour
{
    
    [SerializeField] Slider volumeSlider;
    public void  ChangeVolume()
    {
       AudioListener.volume = volumeSlider.value;
    }
}