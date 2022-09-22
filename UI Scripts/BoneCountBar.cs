using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class BoneCountBar : MonoBehaviour
    {
        public Text boneCountText;

        public void SetBoneCountText(int boneCount)
        {
            boneCountText.text = boneCount.ToString();
        }
    }
}
