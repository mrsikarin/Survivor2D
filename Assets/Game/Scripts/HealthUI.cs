using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public PlayerStatus healthPlayer;
    public Slider healthUI;
    
    // Start is called before the first frame update
    void Start()
    {
        healthUI.maxValue = healthPlayer.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.value = healthPlayer.currentHealth;
    }
}
