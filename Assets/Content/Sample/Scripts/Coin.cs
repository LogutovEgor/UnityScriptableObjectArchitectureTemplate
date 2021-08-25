using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Save;

namespace Sample
{
    [RequireComponent(typeof(Animator))]
    public class Coin : MonoBehaviour
    {
        [SerializeField]
        private SaveSystem saveSystem = default;
        [SerializeField]
        private string pickUpAnimName = default;
        private Animator animator = default;

        private bool picked = default;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnMouseDown()
        {
            if (picked)
                return;
            picked = true;
            saveSystem.Coins++;
            animator.Play(pickUpAnimName);
        }

        public void OnPickUpAnimEnd() => Destroy(gameObject);
    }
}
