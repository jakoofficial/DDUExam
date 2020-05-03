using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inv;
    public GameObject itemButton;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PickUpItem();
        }
    }

    public void PickUpItem()
    {
        for (int i = 0; i < inv.slots.Length; i++)
        {
            if (inv.isFull[i] == false)
            {
                Instantiate(itemButton, inv.slots[i].transform, false);
                Destroy(gameObject);
                inv.isFull[i] = true;
                break;
            }
        }
    }
}
