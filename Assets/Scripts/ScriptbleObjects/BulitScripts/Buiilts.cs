using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buiilts : MonoBehaviour
{
    [SerializeField] private Bullit bullit;

    void Update()
    {
        transform.position += new Vector3(bullit.Speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Star"))
        {
            Debug.Log("astroied go hit");
            collider.GetComponent<StarHealth>().getDamaged(bullit.BullitDamage);
            Destroy(this.gameObject);
        }
        else if (collider.gameObject.CompareTag("Bounds"))
        {
            Destroy(this.gameObject);
        }
    }
}
