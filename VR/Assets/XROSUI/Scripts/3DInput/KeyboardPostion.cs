using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KeyboardPosition{
    [System.Serializable]
    public class KeyboardWrapper
    {
        public string keyboardName;
        public List<KeyWrapper> keys = new List<KeyWrapper>();
    }
    [System.Serializable]
    public class KeyWrapper
    {
        public string text;
        public float x;
        public float y;
        public float z;

        public KeyWrapper(string text, float x, float y, float z)
        {
            this.text = text;
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}

