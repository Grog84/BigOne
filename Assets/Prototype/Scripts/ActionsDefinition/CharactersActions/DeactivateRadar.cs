using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/DeactivateRadar")]
    public class DeactivateRadar : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            DisableRadar(controller);
        }

        private void DisableRadar(CharacterStateController controller)
        {
            GameObject enemyClose;
            enemyClose = controller.m_CharacterController.CharacterTransform.Find("EnemyClose").gameObject;
            
            for ( int i = 0; i < enemyClose.GetComponent<EnemyClose>().pointers.Count; i++ )
            {
                Destroy(enemyClose.GetComponent<EnemyClose>().pointers[i]);
            }

            enemyClose.GetComponent<EnemyClose>().pointers.Clear();
            enemyClose.SetActive(false);


        }
    }
}
