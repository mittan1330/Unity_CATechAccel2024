using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleGame.Charactor
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] GameObject _target;
        [SerializeField] float _speed;

        private void FixedUpdate()
        {
            if (30 <= Vector3.Angle(Vector3.up, transform.up))
            {
                return;
            }

            if (Vector3.Distance(_target.transform.position, this.transform.position) > 1)
            {
                Vector3 moveDir = (_target.transform.position - this.transform.position).normalized;

                moveDir = Vector3.Scale(moveDir, new Vector3(1, 0, 1));

                moveDir *= _speed;

                transform.position += moveDir * Time.deltaTime;
            }

        }

         
    }
}