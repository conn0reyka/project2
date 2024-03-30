using System;
using UnityEngine.AI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float delay;
    public float value = 100;
    public Animator animator;

    public PlayerProgress playerProgress;

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();    
    }
    
    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);

        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, delay); 
    }
}
