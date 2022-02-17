using System.Collections;

namespace Paku.Data
{
    [System.Serializable]
    public struct VolumeDataToken
    {
        public Hashtable volumeTable;

        public VolumeDataToken(Hashtable _volumeTable)
        {
            volumeTable = new Hashtable();
            volumeTable = _volumeTable;
        }
    }
}