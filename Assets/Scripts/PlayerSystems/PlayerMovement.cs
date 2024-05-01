using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 minPos;
    [SerializeField] private Vector2 maxPos;


    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 newPos = transform.position + (Vector3)(Player_Input.instance.move * Time.deltaTime * speed);

        if (newPos.x <= maxPos.x && newPos.x >= minPos.x)
        {
            transform.position = new Vector3(newPos.x, transform.position.y, 0);
        }
        if (newPos.y <= maxPos.y && newPos.y >= minPos.y)
        {
            transform.position = new Vector3(transform.position.x, newPos.y, 0);
        }
    }
}
