using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleGame.Charactor;

namespace BattleGame.item
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class CureItem : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Player.hp += 10;
                Destroy(this.gameObject);
            }
        }
    }
}