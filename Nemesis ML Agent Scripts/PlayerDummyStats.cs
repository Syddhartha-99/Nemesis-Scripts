using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerDummyStats : CharacterStats
    {

        //public HealthBar healthBar;
        //public StaminaBar staminaBar;

        public Animator anim;

        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            //healthBar.SetMaxHealth(maxHealth);

            maxStamina = SetMaxStaminaFromStaminaLevel();
            currentStamina = maxStamina;
            //staminaBar.SetMaxStamina(maxStamina);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        private int SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }

        public void TakeDamage(int damage)
        {
           // if (isDead)
                //return;

            //currentHealth = currentHealth - damage;

            //healthBar.SetCurrentHealth(currentHealth);

            anim.Play("Damage_1");

            //if (currentHealth <= 0)
            //{
            //    currentHealth = 0;
            //    anim.Play("Death_1");
            //    isDead = true;
            //}
        }

        public void DrainStamina(int drain)
        {
            currentStamina = currentStamina - drain;

            //staminaBar.SetCurrentStamina(currentStamina);
        }

        public void AddBones(int bones)
        {
            boneCount = boneCount + bones;
        }
    }
}
