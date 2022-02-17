using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static Paku.Logger.QLogger;
using System.Collections;

namespace Paku.Data
{
    public static class DataController
    {
        /* Advanced Data Controller that can save complicated game states
         * Manages [Inventorys, Player Progress, other abstract cases] */

        public static readonly string m_PathEnding = ".save";
        public static readonly string m_VolumeFile = "volume_settings";

        #region Save Functions

        #region Game Data
        public static void SavePlayerData(PlayerData _save)
        {
            /* SavePlayerData works with a Data-Token which provides as a middel men between
             * the Scriptable Object PlayerData and the written Binary File. */

            if (_save == null)
            {
                LogWarning("You're trying to pass a null Player Stats Object", "Data Controller");
            }

            // Create the File Stream
            BinaryFormatter _formatter = new BinaryFormatter();
            string _path = Application.persistentDataPath + "/" + _save.saveName + m_PathEnding;
            FileStream _stream = new FileStream(_path, FileMode.Create);

            // Create Token
            PlayerDataToken _data = new PlayerDataToken(_save);

            // Save Token
            _formatter.Serialize(_stream, _data);
            _stream.Close();

            Log("Saved Data", "Data Controller");
        }

        public static PlayerDataToken LoadPlayerData(string _saveName)
        {
            string _path = Application.persistentDataPath + "/" + _saveName + m_PathEnding;
            if (File.Exists(_path))
            {
                BinaryFormatter _formatter = new BinaryFormatter();
                FileStream _stream = new FileStream(_path, FileMode.Open);

                PlayerDataToken data = (PlayerDataToken) _formatter.Deserialize(_stream);
                _stream.Close();
                Log("Loaded Data", "Data Controller");

                return data;
            }
            else
            {
                LogError("Save file not found in " + _path, "Data Controller");
                return new PlayerDataToken();
            }
        }
        #endregion

        #region Volume Data

        public static void SaveVolumeData(Hashtable _volumeTable)
        {
            if (_volumeTable == null)
            {
                LogWarning("You're trying to pass a null Volume Table Object", "Data Controller");
            }

            // Create File Stream
            string _path = Application.persistentDataPath + "/" + m_VolumeFile + m_PathEnding;
            BinaryFormatter _formatter = new BinaryFormatter();
            FileStream _stream = new FileStream(_path, FileMode.Create);

            VolumeDataToken _data = new VolumeDataToken(_volumeTable);

            _formatter.Serialize(_stream, _data);
            _stream.Close();

            Log("Saved Volume Data", "Data Controller");
        }

        public static Hashtable LoadVolumeData()
        {
            string _path = Application.persistentDataPath + "/" + m_VolumeFile + m_PathEnding;
            if (File.Exists(_path))
            {
                BinaryFormatter _formatter = new BinaryFormatter();
                FileStream _stream = new FileStream(_path, FileMode.Open);

                VolumeDataToken data = (VolumeDataToken) _formatter.Deserialize(_stream);
                _stream.Close();

                Log("Loaded Volume Data", "Data Controller");

                return data.volumeTable;
            }
            else
            {
                LogError("Save file not found in " + _path, "Data Controller");
                return null;
            }
        }

        #endregion

        #endregion
    }
}