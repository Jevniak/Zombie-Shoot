using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerCheckEnemyVision : MonoBehaviour
    {
        #region Variables

        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private float maxRadius = 2f;
        [SerializeField] private float maxDistance = 5f;
        [SerializeField] private float coneAngle = 5f;

        private PlayerMove _playerMove;

        public bool enemyInVision { private set; get; }

        #endregion

        private void Awake()
        {
            _playerMove = GetComponent<PlayerMove>();
        }

        private void Update()
        {
            CheckConeCastEnemy();
        }

        private void CheckConeCastEnemy()
        {
            Vector3 origin = transform.position;

            Vector3 direction = transform.TransformDirection(Vector3.forward);

            RaycastHit[] sphereCastHits = Physics.SphereCastAll(origin - new Vector3(0, 0, maxRadius), maxRadius,
                direction, maxDistance, enemyLayer);

            if (sphereCastHits.Length > 0)
            {
                for (int i = 0; i < sphereCastHits.Length; i++)
                {
                    Vector3 hitPoint = sphereCastHits[i].point;
                    Vector3 directionToHit = hitPoint - origin;
                    float angleToHit = Vector3.Angle(direction, directionToHit);
                    if (angleToHit < coneAngle)
                    {
                        enemyInVision = true;
                    }
                    else
                    {
                        enemyInVision = false;
                    }
                }
            }
            else
            {
                enemyInVision = false;
            }
        }
    }
}