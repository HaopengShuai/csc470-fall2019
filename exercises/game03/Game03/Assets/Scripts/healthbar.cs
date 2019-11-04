using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 200f;
    public static float health;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        healthBar = GetComponent<Image>();
        health = player.GetComponent<Player>().health;
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<Player>().health;
        healthBar.fillAmount = health / maxHealth;
    }
}
