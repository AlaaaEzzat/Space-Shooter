using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/PowerUp")]
public class PowerUp : ScriptableObject
{
    [SerializeField] private string powerUpName;

    public string PowerUpName => powerUpName;
}
