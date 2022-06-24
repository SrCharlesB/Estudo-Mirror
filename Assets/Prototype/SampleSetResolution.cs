using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SampleSetResolution
{
    [System.Serializable] class Resolution
    {
        public int width = 1280;
        public int height = 720;
        public int Hz = 60;
        public bool FullScreen;
    }
    public class SampleSetResolution : MonoBehaviour
    {
        [SerializeField] private Resolution _Resolution;
        private void Awake()
        {
            Screen.SetResolution(_Resolution.width, _Resolution.height, _Resolution.FullScreen, _Resolution.Hz);
        }
    }
}