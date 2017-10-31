using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEngine.SceneManagement;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/SwitchScene")]
    public class SwitchScene : _Action {

        public override void Execute(GMStateController controller)
        {
            Switch(controller);
        }

        private void Switch(GMStateController controller)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SceneManager.LoadScene(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                SceneManager.LoadScene(1);
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                SceneManager.LoadScene(2);
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                SceneManager.LoadScene(3);
            else if (Input.GetKeyDown(KeyCode.Alpha5))
                SceneManager.LoadScene(4);
            else if (Input.GetKeyDown(KeyCode.Alpha6))
                SceneManager.LoadScene(5);
            else if (Input.GetKeyDown(KeyCode.Alpha7))
                SceneManager.LoadScene(6);
            else if (Input.GetKeyDown(KeyCode.Alpha8))
                SceneManager.LoadScene(7);
            else if (Input.GetKeyDown(KeyCode.Alpha9))
                SceneManager.LoadScene(8);
            else if (Input.GetKeyDown(KeyCode.Alpha0))
                SceneManager.LoadScene(9);

        }
    }
}
