using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        #region Variables

        private Animator anim;

        #endregion


        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void SetAnim(String animName)
        {
            //TODO: при расширении проекта ОБЯЗАТЕЛЬНО перейти на Trigger в Animator!!!!!
            if (!anim.enabled)
                ActivateAnimator();
            anim.Play(animName);
        }

        public void DeactivateAnimator()
        {
            if (anim.enabled)
                StartCoroutine(DeactivetedAnimator());
        }

        private IEnumerator DeactivetedAnimator()
        {
            SetAnim("Idle");
            yield return new WaitForSeconds(0.1f);
            anim.enabled = false;
        }

        private void ActivateAnimator()
        {
            anim.enabled = true;
        }
    }
}