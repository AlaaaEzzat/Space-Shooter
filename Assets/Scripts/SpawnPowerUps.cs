using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private Transform[] powerUpsTransform;

    private void Start()
    {
        StartCoroutine(spawnPowerUps());
    }

    IEnumerator spawnPowerUps()
    {
        yield return new WaitForSeconds(10);
        int random = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[random], powerUpsTransform[random].transform.position, Quaternion.identity);
        StartCoroutine(spawnPowerUps());
    }
}
