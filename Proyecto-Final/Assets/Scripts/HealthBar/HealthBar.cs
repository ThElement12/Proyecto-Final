﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    Image healthBar;
    Text ratioText;
    private float hitpoints;
    private float maxhitpoints = 100;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        ratioText = GameObject.Find("ratioText").GetComponent<Text>();
        hitpoints = gameObject.GetComponent<CharacterMovement>().Vida;
        UpdateHealth();
    }

    private void FixedUpdate()
    {
        hitpoints = gameObject.GetComponent<CharacterMovement>().Vida;
        UpdateHealth();
    }
    private void UpdateHealth()
    {
        
        float ratio = hitpoints / maxhitpoints;
        healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + "%";
    }

}
