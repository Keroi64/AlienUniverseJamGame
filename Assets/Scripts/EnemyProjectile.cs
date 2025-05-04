using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damageAmount = 25;

    private void OnCollisionEnter(Collision other)
    {
        if (other .transform.tag == "Player")
        {
            PlayerController Player = other.transform.GetComponent<PlayerController>();
            Player.PlayerTakeDamage(damageAmount);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 1f);
        }
    }


}
