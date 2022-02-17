using UnityEngine;

namespace Paku.Data
{
    [CreateAssetMenu]
    public class PlayerData : ScriptableObject
    {
        public string saveName;

        public int health = 0;

        // Add Save Attributs here

        public void SavePlayer()
        {
            DataController.SavePlayerData(this);
        }

        public void LoadPlayer()
        {
            var token = DataController.LoadPlayerData(saveName);
            health = token.health;
        }
    }
}
