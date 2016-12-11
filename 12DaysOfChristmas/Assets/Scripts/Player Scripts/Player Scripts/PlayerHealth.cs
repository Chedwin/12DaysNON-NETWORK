using UnityEngine;
using UnityEngine.UI;

using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class PlayerHealth : MonoBehaviour {

    //Player Health Class, holds and manages Player Health

    //Max Health
    public const int maxHealth = 100;


    //Current Health
    public int health = 0;

    //Slider 
    public Slider healthBar;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        OnChangeHealth(health);
	}

    // Snowmen enemies entering the sphere trigger collider
    void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "Enemy") {
            TakeDamage(5);
        }
    }

    // Take damage from trigger entrances or stays
    public void TakeDamage(int _d) {

        health -= _d;
        Debug.Log(health);
        if (health <= 0) {
            health = 0;
            Debug.Log("Dead");
        }
        OnChangeHealth(health);
    }

    // Call this to heal the player from an external script
    // i.e. Health Power Ups
    public void Heal(int _h) {
        health += _h;

        if (health >= maxHealth) {
            health = maxHealth;
        }
        OnChangeHealth(health);
    }

    //Called when Current Health changes value
    public void OnChangeHealth(int health)
    {
        healthBar.value = health;
    }
}
