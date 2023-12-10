using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;

namespace BattleGame.FieldGenerator
{
    // TODO 書き途中ステージ等の管理用スクリプトをJobSystemで回す。

    struct UpdatePosition : IJobParallelFor
    {
        // 並列でしたい処理
        void IJobParallelFor.Execute(int index)
        {

        }
    }

    public class Ground : MonoBehaviour
    {

        [SerializeField] GameObject[] _baseFields;
        [SerializeField] Vector2 _size;

        private void Start()
        {
            
        }
    }
}
