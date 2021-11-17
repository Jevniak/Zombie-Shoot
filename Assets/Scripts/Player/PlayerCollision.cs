using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        #region Variables

        public bool inShootingZone { private set; get; }

        #endregion
        

        private void OnTriggerEnter(Collider coll)
        {
            switch (coll.tag)
            {
                case "ShootingZone":
                    inShootingZone = true;
                    break;
                case "Enemy":
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    break;
            }
        }

        private void OnTriggerExit(Collider coll)
        {
            switch (coll.tag)
            {
                case "ShootingZone":
                    inShootingZone = false;
                    break;
            }
        }
    }
}
