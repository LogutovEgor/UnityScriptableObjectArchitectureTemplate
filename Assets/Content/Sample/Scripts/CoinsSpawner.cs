using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sample.Events;

namespace Sample
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField]
        private Coin coinPrefab = default;

        public void CharacterDeathEventResponse(CharacterDeathEvent characterDeathEvent)
        {
            GameObject newCoin = Instantiate(coinPrefab.gameObject, transform);
            newCoin.transform.position = characterDeathEvent.Target.transform.position;
        }
    }
}
