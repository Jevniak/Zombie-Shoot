using UnityEngine;

namespace ScriptableObjects.Gun
{
    [CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/SpawnGunScriptableObject", order = 1)]
    public class Gun : ScriptableObject
    {
        public float shootSpeed;

        public enum BulletPower
        {
            Easy=50,
            Medium=100,
            Strong=200
        };
        public BulletPower bulletPower;
        public GameObject explosionPrefab;
    }
}
