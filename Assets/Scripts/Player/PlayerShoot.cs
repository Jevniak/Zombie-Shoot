using System;
using System.Collections;
using Enemy;
using ScriptableObjects.Gun;
using UnityEngine;

namespace Player
{
    public class PlayerShoot : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Gun gunStats;
        [SerializeField] private Transform handTransform;

        private Camera _camera;
        private float nextTimeToFire;
        private PlayerCheckEnemyVision _playerCheckEnemyVision;
        private PlayerCollision _playerCollision;

        #endregion


        private void Awake()
        {
            _playerCheckEnemyVision = GetComponent<PlayerCheckEnemyVision>();
            _playerCollision = GetComponent<PlayerCollision>();

            _camera = Camera.main;
        }

        private void Update()
        {
            if (_playerCheckEnemyVision.enemyInVision && _playerCollision.inShootingZone && Input.GetMouseButton(0))
            {
                RaycastHit hits;
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hits, Mathf.Infinity, 1))
                {
                    Rotate(hits.point);
                    if (Time.time >= nextTimeToFire)
                    {
                        nextTimeToFire = Time.time + gunStats.shootSpeed;
                        Shoot(hits.transform, hits.point);
                    }
                }
            }
        }

        private void Shoot(Transform targetTransform, Vector3 targetPosition)
        {
            Instantiate(gunStats.explosionPrefab, targetPosition, Quaternion.identity);
            if (targetTransform.TryGetComponent(out Rigidbody rigidbodyTarget))
            {
                targetTransform.parent.root.GetComponent<EnemyHealth>().TakeDamage();
                rigidbodyTarget.AddForce(transform.TransformDirection(Vector3.forward) * (int) gunStats.bulletPower,
                    ForceMode.Impulse);
            }
        }

        private void Rotate(Vector3 targetPosition)
        {
            handTransform.LookAt(new Vector3(targetPosition.x, targetPosition.y, targetPosition.z));
        }
    }
}