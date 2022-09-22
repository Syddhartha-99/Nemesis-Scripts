using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class MakeInvisible : MonoBehaviour
    {
        public Camera cam;
        int invisibleMask;


        void Update()
        {
            invisibleMask = cam.cullingMask;

            cam.cullingMask = 1 << 0;
        }
    }
}