using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;

namespace BattleGame.FieldGenerator
{
    // TODO �����r���X�e�[�W���̊Ǘ��p�X�N���v�g��JobSystem�ŉ񂷁B

    struct UpdatePosition : IJobParallelFor
    {
        // ����ł���������
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
