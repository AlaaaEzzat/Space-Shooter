using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("MoveUp", Player_Input.instance.move.y);
        anim.SetBool("PlayerDead", PlayerHealth.playerDead);
    }
}
