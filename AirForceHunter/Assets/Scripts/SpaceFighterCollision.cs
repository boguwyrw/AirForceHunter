using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFighterCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Debug.Log("Trafi�e� na �cian�! BOOOM");
        }
    }
}
