using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMove : EnemyBase
    {
        #region Variables

        private Transform targetTransform;
        private NavMeshAgent _agent;

        #endregion


        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void SetTargetTransform(Transform target)
        {
            targetTransform = target;
            StartMoveToTarget();
        }

        private void StartMoveToTarget()
        {
            MoveToTarget(_agent, targetTransform);
        }
    }
}