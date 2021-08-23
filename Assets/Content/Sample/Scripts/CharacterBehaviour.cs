using UnityEngine;
using Core;
namespace Sample
{
    [RequireComponent(typeof(Animator))]
    public class CharacterBehaviour : MonoBehaviour, IInitialize<ICharacter>
    {
        private Animator animator = default;
        private ICharacter character = default;

        public void Initialize(ICharacter character)
        {
            this.character = character;
        }

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                animator.Play("Damaged");
        }

    }
}
