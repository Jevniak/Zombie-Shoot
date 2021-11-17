using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerInfo playerInfo;

        private Transform thisTransform;
        private Camera _camera;
        private PlayerAnimationController _playerAnimationController;
        private NavMeshAgent _agent;
        private PlayerCheckEnemyVision _playerCheckEnemyVision;
        private PlayerCollision _playerCollision;

        #endregion
    
        private void Awake()
        {
            _playerAnimationController = GetComponent<PlayerAnimationController>();
            _playerCheckEnemyVision = GetComponent<PlayerCheckEnemyVision>();
            _playerCollision = GetComponent<PlayerCollision>();
            _agent = GetComponent<NavMeshAgent>();
            
            _camera = Camera.main;
            
            _agent.speed = playerInfo.speed;
            
        }

        private void Update()
        {
            if (!_playerCheckEnemyVision.enemyInVision || !_playerCollision.inShootingZone)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _agent.enabled = true;
                    RaycastHit hit;

                    if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                    {
                        _agent.SetDestination(hit.point);
                    }
                }

                _playerAnimationController.SetAnim(_agent.velocity == Vector3.zero ? "Idle" : "Running");
            }
            else
            {
                _agent.enabled = false;
                _playerAnimationController.DeactivateAnimator();
            }
        }
    }
}