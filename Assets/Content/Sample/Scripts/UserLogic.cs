using UnityEngine;
using Sample.Events;

namespace Sample
{
    [RequireComponent(typeof(CharacterBehaviour))]
    public class UserLogic : MonoBehaviour
    {
        [SerializeField]
        private CharacterAttackEvent characterAttackEvent = default;
        private CharacterBehaviour playerCharacter = default;

        private void Awake()
        {
            playerCharacter = GetComponent<CharacterBehaviour>();
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] raycastHit2Ds = Physics2D.CircleCastAll(mouseWorldPosition, 0.1f, Vector2.zero);

            foreach (RaycastHit2D raycastHit2D in raycastHit2Ds)
                if (raycastHit2D.transform.CompareTag("Character") && raycastHit2D.transform.gameObject != gameObject)
                {
                    CharacterBehaviour targetEnemy = raycastHit2D.transform.gameObject.GetComponent<CharacterBehaviour>();
                    characterAttackEvent.Raise(playerCharacter, targetEnemy);
                }
        }
    }
}
