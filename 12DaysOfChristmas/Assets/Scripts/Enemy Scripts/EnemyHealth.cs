using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class EnemyHealth : MonoBehaviour {

    public const int maxHealth = 100;

    public int currentHealth = 0;

    GameProgression gp;

    void Start()
    {
        gp = GameObject.FindGameObjectWithTag("GameProgression").GetComponent<GameProgression>();
        currentHealth = maxHealth;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Snowball")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            PresentFactory pf = FindObjectOfType<PresentFactory>();
            pf.CmdMakePresent(this.gameObject);

            Destroy(gameObject);
            gp.numEnemiesLeft--;
        }
    }
}
