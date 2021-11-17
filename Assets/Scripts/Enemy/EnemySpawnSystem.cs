using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawnSystem : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform targetTransform;
        [SerializeField] private float timeSpawnDelay = 3f;
        [SerializeField] private GameObject prefabEnemy;

        #endregion


        private void Awake()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeSpawnDelay);
                GameObject enemy = Instantiate(prefabEnemy,
                    new Vector3(Random.Range(3.0f, 9.0f), 0, Random.Range(-4.0f, 8.0f)), Quaternion.identity);
                enemy.GetComponent<EnemyMove>().SetTargetTransform(targetTransform);
            }
        }
    }
}