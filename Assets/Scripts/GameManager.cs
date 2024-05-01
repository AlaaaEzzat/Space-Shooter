using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject objectPrefab , player , restart;
    public Transform[] targets;
    public Wave[] waves;
    public int currentWave = 0;
    [SerializeField] private TextMeshProUGUI waveNumber;
    [SerializeField] private AudioManager audioManager;

    public int numberOfObjects = 10;
    public float minMoveSpeed = 2f;
    public float maxMoveSpeed = 5f;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;

    void Start()
    {
        audioManager.Play("Wave1");
        waveNumber.text = "Wave " + (currentWave + 1) + " is Comming!";
        restart.gameObject.SetActive(false);
        StartCoroutine(InstantiateObjectsOverTime());
    }

    IEnumerator InstantiateObjectsOverTime()
    {
        waveNumber.text = "";
        for (int i = 0; i < waves[currentWave].NumberToSpawn; i++)
        {
            int randomEnemys = Random.Range(0, waves[currentWave].EnemiesInWave.Length);

            GameObject newObj = Instantiate(waves[currentWave].EnemiesInWave[randomEnemys], GetRandomSpawnPosition(), Quaternion.identity);
            MoveTowardsRandomTarget(newObj.transform);

            float randomSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomSpawnInterval);
        }

        if(currentWave < waves.Length - 1)
        {
            currentWave += 1;
            waveNumber.text = "Wave " + (currentWave + 1) + " is Comming!";
            yield return new WaitForSeconds(9);
            Debug.Log("Wave"+currentWave);
            Debug.Log("Wave" + (currentWave + 1));
            audioManager.Stop("Wave"+currentWave);
            audioManager.Play("Wave"+(currentWave + 1));
            StartCoroutine(InstantiateObjectsOverTime());
        }
        else
        {
            waveNumber.text = "Congratulation You Win!";
            yield return new WaitForSeconds(5);
            restart.gameObject.SetActive(true);
        }
    }


    Vector2 GetRandomSpawnPosition()
    {
        Vector2 minPosition = new Vector2(player.transform.position.x + 10, -7f);
        Vector2 maxPosition = new Vector2(player.transform.position.x + 15, 7f);

        return new Vector2(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y));
    }


    void MoveTowardsRandomTarget(Transform objectTransform)
    {
        Transform randomTarget = targets[Random.Range(0, targets.Length)];

        Vector2 direction = (randomTarget.position - objectTransform.position).normalized;

        float randomSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        objectTransform.GetComponent<Rigidbody2D>().velocity = direction * randomSpeed;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
