using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private PowerUp powerUp;
    public UnityEvent increaseHealth;

    private void Update()
    {
        transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(powerUp.PowerUpName == "Increase Health")
            {
                IncreaseHealth(collision);
                increaseHealth?.Invoke();
            }
            else if (powerUp.PowerUpName == "Increase Damage")
            {
                IncreaseDamage(collision);
            }
        }
    }

    private void IncreaseHealth(Collider2D collider)
    {
        collider.GetComponent<PlayerHealth>().AddHealth();
        Destroy(this.gameObject);
    }

    private void IncreaseDamage(Collider2D collider)
    {
        collider.GetComponent<AttackSystem>().IncreaseWeaponStage();
        Destroy(this.gameObject);
    }
}
