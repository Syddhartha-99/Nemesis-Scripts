using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SG
{
    public class NemesisAnimatorHandler : MonoBehaviour
    {
        public Animator anim;
        public Rigidbody rb;


        public void Initialize()
        {
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            anim.SetFloat("Speed", rb.velocity.magnitude);
        }
    }
}
