using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enviroment
{
    public class SpawnTower : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject prefabTower;
        [SerializeField] private NavMeshSurface _navMeshSurface;

        #endregion

        private void Awake()
        {
            Instantiate(prefabTower, new Vector3(Random.Range(-8.0f, -4.0f), 0, Random.Range(-2.0f, 8.0f)), Quaternion.Euler(0,Random.Range(80.0f,180.0f),0));
            _navMeshSurface.BuildNavMesh();
            
        }
    }
}
