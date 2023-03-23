using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundList
{
    public List<Sound> sounds;

    [System.Serializable]
    public class Sound
    {
        public Direction direction;
        public string type;
    }

    [System.Serializable]
    public class Direction
    {
        public float x;
        public float y;
        public float z;
    }
}
