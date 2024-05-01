using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StarHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private Animator anim;
    public UnityEvent onAstroideKill;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void getDamaged(int damage)
    {
        if(health > 0)
        {
            health -= damage;
            if (health <= 0)
            {
                onAstroideKill?.Invoke();
                StartCoroutine(wait());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player Got hit");
            collision.GetComponent<PlayerHealth>().onPlayerDamaged(1);
        }
        else if (collision.gameObject.CompareTag("Bounds"))
        {
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
