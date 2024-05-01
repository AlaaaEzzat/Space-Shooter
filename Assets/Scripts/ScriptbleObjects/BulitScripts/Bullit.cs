using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Bullit")]
public class Bullit : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private int bullitDamage;

    public float Speed => speed;
    public int BullitDamage => bullitDamage;
}
