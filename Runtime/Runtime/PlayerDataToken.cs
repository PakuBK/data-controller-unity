namespace Paku.Data
{
    [System.Serializable]
    public struct PlayerDataToken
    {
        public string saveName;

        public int health;

        public PlayerDataToken(PlayerData _save)
        {
            saveName = _save.saveName;
            health = _save.health;
        }
    }
}