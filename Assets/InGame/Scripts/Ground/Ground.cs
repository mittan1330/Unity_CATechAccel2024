using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;

namespace BattleGame.FieldGenerator
{
    struct UpdatePosition : IJobParallelFor
    {
        // ï¿óÒÇ≈ÇµÇΩÇ¢èàóù
        void IJobParallelFor.Execute(int index)
        {

        }
    }

    public class Ground : MonoBehaviour
    {

        [SerializeField] GameObject[] _baseFields;
        [SerializeField] Vector2 _size;

        [SerializeField] int _groundPool = 100;

        private void Start()
        {
            
        }
    }
}
