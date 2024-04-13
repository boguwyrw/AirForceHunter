using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFighterCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Debug.Log("Trafi³eœ na œcianê! BOOOM");
        }
    }
}
