using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunGame.Charactor;

namespace RunGame.item
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class DamageItem : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Player.hp -= 10;
                Destroy(this.gameObject);
            }
        }
    }
}