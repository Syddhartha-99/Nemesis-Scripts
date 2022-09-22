    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerAttacker : MonoBehaviour
    {
        AnimatorHandler animatorHandler;
        InputHandler inputHandler;
        WeaponSlotManager weaponSlotManager;


        public string lastAttack;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
            inputHandler = GetComponent<InputHandler>();
        }

        public void HandleWeaponCombo(WeaponItem weapon)
        {
            if (inputHandler.comboFlag)
            {
                animatorHandler.anim.SetBool("canDoCombo", false);

                if (lastAttack == weapon.OH_Light_Attack_1)
                {
                    animatorHandler.anim.SetBool("canDoCombo", false);
                    animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_2, true);
                    lastAttack = weapon.OH_Light_Attack_2;
                }

                else if (lastAttack == weapon.OH_Light_Attack_2)
                {
                    animatorHandler.anim.SetBool("canDoCombo", false);
                    animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_3, true);
                    lastAttack = weapon.OH_Light_Attack_3;
                }

                else if (lastAttack == weapon.OH_Light_Attack_3)
                {
                    animatorHandler.anim.SetBool("canDoCombo", false);
                    animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_4, true);
                    lastAttack = weapon.OH_Light_Attack_4;
                }
                else if (lastAttack == weapon.TH_Attack_1)
                {
                    animatorHandler.anim.SetBool("canDoCombo", false);
                    animatorHandler.PlayTargetAnimation(weapon.TH_Attack_2, true);
                    lastAttack = weapon.TH_Attack_2;
                }
                else if (lastAttack == weapon.TH_Attack_2)
                {
                    animatorHandler.anim.SetBool("canDoCombo", false);
                    animatorHandler.PlayTargetAnimation(weapon.TH_Attack_3, true);
                    lastAttack = weapon.TH_Attack_3;
                }
            }

        }

        public void HandleLightAttack(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;

            if (inputHandler.twoHandFlag)
            {
                animatorHandler.PlayTargetAnimation(weapon.TH_Attack_1, true);
                lastAttack = weapon.TH_Attack_1;
            }

            else
            {
                animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
                lastAttack = weapon.OH_Light_Attack_1;
            }
        }

        public void HandleHeavyAttack(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;
            animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
            lastAttack = weapon.OH_Heavy_Attack_1;
        }
    }
}
