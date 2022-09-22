using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SG
{
    public class NemesisStats : CharacterStats
    {
        Animator anim;

        public int bonesOnDeath = 10;

        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (isDead)
                return;

            currentHealth = currentHealth - damage;

            anim.Play("Damage_1");

            if (currentHealth <= 0)
            {
                HandleDeath();
            }
        }

        public void HandleDeath()
        {
            currentHealth = 0;
            anim.Play("Death_1");
            isDead = true;

            PlayerStats playerStats = FindObjectOfType<PlayerStats>();
            BoneCountBar boneCountBar = FindObjectOfType<BoneCountBar>();

            {

                if (playerStats != null)
                {
                    playerStats.AddBones(bonesOnDeath);

                    if (boneCountBar != null)
                    {
                        boneCountBar.SetBoneCountText(playerStats.boneCount);
                    }
                }
            }
        }
    }
}
