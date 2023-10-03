using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float speed;
    public float rangepickup;
    public bool die;
    public List<int> experiences_limit = new List<int>();
    public int experience;
    public int level;
    public TMPro.TMP_Text exp_text;
    public Slider exp_slider;
    public bool isLevelup;
    //public Action UpdateStaus;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        experiences_limit = new List<int>();
        for (int i = 1; i < 100; i++)
        {
            int exp = i*10;
            experiences_limit.Add(exp);
        }
        getExperience(0);
    }
    public void setSpeed()
    {
        speed = speed + 1;
        //UpdateStaus?.Invoke();
    }
    public void setRangepickup()
    {
        rangepickup = rangepickup + 1;
    }
    public void getExperience(int exp)
    {
        if(experience + exp >= experiences_limit[level])
        {
            experience = experience + exp - experiences_limit[level];
            level += 1;
            GameManager.Instance.OpenUpgradeUI();
        }else
        {
            experience = experience + exp ;
        }
        exp_slider.maxValue = experiences_limit[level];
        exp_slider.value = experience;
        
        exp_text.text = "Level : " + (level + 1).ToString();
    }
    public void setMaxHealth()
    {
        maxHealth = maxHealth + 10;
    }
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        if(currentHealth <= 0)
        {
            GameManager.Instance.PauseGame();
            gameObject.SetActive(false);
        }
    }
}
