using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Brick : MonoBehaviour
{
     public int hit;
     public TMP_Text hitText;
     public bool isBallMultiplier = false;

     public void Init(int value, bool isPowerUp = false)
     {
         hit = value;
         isBallMultiplier = isPowerUp;
         UpdateText();
         Hit();
         gameObject.SetActive(true);
     }

     private void Hit()
     {
         hit--;
         UpdateText();

         if (hit <= 0)
         {
             gameObject.SetActive(false); 
         }
     }

     private void UpdateText()
     {
           if (hitText != null)
             hitText.text = hit.ToString();
     }
}
