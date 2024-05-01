using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] bullits;
    [SerializeField] private float recoleTime;
    [SerializeField] private bool canShoot = true;
    private int weaponStage = 0;
    [SerializeField] private AudioManager manager;

    void Update()
    {
        shootBullit();
    }

    private void shootBullit()
    {
        if (Player_Input.instance.isFiring == true && canShoot == true)
        {
            manager.Play("Shoot");
            Instantiate(bullits[weaponStage], this.transform.position, Quaternion.identity);
            canShoot = false;
            StartCoroutine(Recole());
        }
    }

    IEnumerator Recole()
    {
        yield return new WaitForSeconds(recoleTime);
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void IncreaseWeaponStage()
    {
        if (weaponStage < bullits.Length - 1)
        {
            weaponStage += 1;
        }
    }

    public void resetWeaponStage()
    {
        weaponStage = 0;
    }
}
