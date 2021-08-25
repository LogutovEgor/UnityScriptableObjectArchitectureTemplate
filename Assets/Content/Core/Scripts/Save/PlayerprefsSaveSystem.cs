using UnityEngine;
using System;

namespace Core.Save
{
    [CreateAssetMenu(menuName = nameof(Core) + "/" + nameof(Save) + "/" + nameof(PlayerprefsSaveSystem))]
    public class PlayerprefsSaveSystem : SaveSystem
    {
        private const string COINS_ID = "coins";
        public override int Coins
        {
            get => GetValue<int>(COINS_ID);
            set
            {
                if (value >= 0)
                    SetValue(COINS_ID, value);
            }
        }

        private const string CRYSTALS_ID = "crystals";
        public override int Crystals
        {
            get => GetValue<int>(CRYSTALS_ID);
            set
            {
                if (value >= 0)
                    SetValue(CRYSTALS_ID, value);
            }
        }


        //public override T GetValue<T>(string id) => PlayerPrefs.HasKey(id) ? JsonUtility.FromJson<T>(PlayerPrefs.GetString(id)) : default;
        //public override void SetValue<T>(string id, T value) => PlayerPrefs.SetString(id, JsonUtility.ToJson(value));

        [Serializable]
        private class JsonWrapper<T>
        {
            [SerializeField]
            private T value = default;
            public T Value => value;

            public JsonWrapper(T value) => this.value = value;
        }

        public override T GetValue<T>(string id)
        {
            if (PlayerPrefs.HasKey(id))
            {
                string json = PlayerPrefs.GetString(id);
                JsonWrapper<T> jsonWrapper = JsonUtility.FromJson<JsonWrapper<T>>(json);
                return jsonWrapper.Value;
            }
            else
            {
                return default;
            }
        }

        public override void SetValue<T>(string id, T value)
        {
            JsonWrapper<T> jsonWrapper = new JsonWrapper<T>(value);
            string json = JsonUtility.ToJson(jsonWrapper);
            PlayerPrefs.SetString(id, json);
        }
    }
}
