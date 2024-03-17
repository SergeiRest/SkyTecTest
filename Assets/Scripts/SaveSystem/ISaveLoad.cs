using System;

namespace DefaultNamespace.SaveSystem
{
    public interface ISaveLoad
    {
        public string Key { get; }
        public event Action<ISaveLoad, string> Update;
    }
}