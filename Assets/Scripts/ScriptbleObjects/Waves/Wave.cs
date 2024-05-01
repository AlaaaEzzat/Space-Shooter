using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Waves")]
public class Wave : ScriptableObject
{
    [SerializeField] private GameObject[] enemiesInWave;

    [SerializeField] private float timeBeforeThisWave;

    [SerializeField] private float numberToSpawn;


    public GameObject[] EnemiesInWave => enemiesInWave;

    public float TimeBeforeThisWave => timeBeforeThisWave;

    public float NumberToSpawn => numberToSpawn;
}
