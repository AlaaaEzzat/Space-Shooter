using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] private float waitBeforeHit;
    private bool canBeHit = false;
    public static bool playerDead = false;
    private Vector3 startPosition;

    public UnityEvent deathEvent , endGame;

    public int Health => health;

    private void Start()
    {
        playerDead = false;
        startPosition = transform.position;
        StartCoroutine(Can_Be_Damaged());
    }

    private void PlayerHitLogic()
    {
        this.gameObject.GetComponent<PlayerInput>().enabled = false;
        Player_Input.instance.move = Vector2.zero;
        playerDead = true;
        canBeHit = false;
        StartCoroutine(waitBeforeRespawn());
    }

    public void onPlayerDamaged(int damage)
    {
        if(canBeHit == true && health > 0)
        {
            health -= damage;
            if (health <= 0)
            {
                playerDead = true;
                endGame?.Invoke();
            }
            else
            {
                deathEvent?.Invoke();
                PlayerHitLogic();
            }
        }

    }

    IEnumerator Can_Be_Damaged()
    {
        yield return new WaitForSeconds(waitBeforeHit);
        canBeHit = true;
    }

    IEnumerator waitBeforeRespawn()
    {
        yield return new WaitForSeconds(3);
        transform.position = startPosition;
        StartCoroutine(Can_Be_Damaged());
        this.gameObject.GetComponent<PlayerInput>().enabled = true;
        playerDead = false;
    }

    public void AddHealth()
    {
        health += 1;
    }
}
