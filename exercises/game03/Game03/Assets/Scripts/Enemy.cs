using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Text healthbar;
    private float dist;
    //Varibles
    public float enemyHealth;
    public float health;
    public float movementSpeed;

    Animation anima;

    private GameObject player;

    private bool triggeringPlayer;
    public bool aggro;

    public float attackTimer;
    private float _attackTimer;
    private bool attacked;

    public float maxDamage;
    public float minDamage;
    private float damage;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        _attackTimer = attackTimer;
        health = enemyHealth;
        anima = GetComponent<Animation>();
        SetHealth();
    }
    void Update()
    {
        SetHealth();
        if (aggro)
        {
            FollowPlayer();
        }
        else
            Idle();
        if(health <= 0)
        {
            Destroy(gameObject);
            health = 0.0f;
        }
        
    }

    void SetHealth()
    {
        healthbar.text = "Enemy Health: " + health.ToString();
    }
    public void Idle()
    {
        anima.CrossFade("Zidle");
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggeringPlayer = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggeringPlayer = false;
        }
    }

    public void Attack()
    {
        if (!attacked)
        {
            damage = Random.Range(minDamage, maxDamage);
            dist = Vector3.Distance(player.transform.position, transform.position);
            print(dist);
            if(dist <= 10)
            {
                anima.CrossFade("Zattack");
                player.GetComponent<Player>().health -= damage;
                attacked = true;
            }
            
        }
        
    }

    public void FollowPlayer()
    {
        if (!triggeringPlayer)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed);
            this.transform.LookAt(player.transform);
            anima.CrossFade("Zwalk");
            
        }
        if (_attackTimer <= 0)
        {
            attacked = false;
            _attackTimer = attackTimer;
        }
            
        if (attacked)
            _attackTimer -= 1 * Time.deltaTime;
        if (!attacked)
            _attackTimer = attackTimer;


        Attack();
    }


}
