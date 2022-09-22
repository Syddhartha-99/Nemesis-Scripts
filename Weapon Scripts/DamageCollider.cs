using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class DamageCollider : MonoBehaviour
    {
        Collider damageCollider;
        public int currentWeaponDamage = 20;

        public NemesisAgent nemesisAgent;

        private void Awake()
        {
            nemesisAgent = FindObjectOfType<NemesisAgent>();
            damageCollider = GetComponent<Collider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.enabled = false;
            damageCollider.isTrigger = true;
        }

        public void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }

        public void DisableDamageCollider()
        {
            damageCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Player")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();

                if (playerStats != null)
                {
                    playerStats.TakeDamage(currentWeaponDamage);
                }
            }

            if (collision.tag == "Enemy")
            {
                EnemyStats enemyStats = collision.GetComponent<EnemyStats>();

                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage);
                }
            }

            if (collision.tag == "Nemesis")
            {
                NemesisStats nemesisStats = collision.GetComponent<NemesisStats>();
                if (nemesisStats != null)
                {
                    nemesisStats.TakeDamage(currentWeaponDamage);
                }
            }

            if (collision.tag == "PlayerDummy")
            {
                PlayerDummyStats playerDummyStats = collision.GetComponent<PlayerDummyStats>();

                if (playerDummyStats != null)
                {
                    playerDummyStats.TakeDamage(currentWeaponDamage);
                    nemesisAgent.AttackSuccess();
                }
            }
        }
    }
}

