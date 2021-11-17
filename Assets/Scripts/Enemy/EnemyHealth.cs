using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : EnemyBase
    {
        public void TakeDamage()
        {
            Die();
        }
    }
}