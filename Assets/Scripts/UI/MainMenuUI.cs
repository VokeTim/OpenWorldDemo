using UnityEngine;

namespace OpenWorld.UI
{
    public class MainMenuUI : MonoBehaviour
    {

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.C)) 
            //{
            //    showMenu = !showMenu;
            //}
        }

        private void OnGUI()
        {
            if (GameManager.Instance.IsShowMenu)
            {
                GUI.Box(new Rect(10, 10, 500, 490), "Main Menu");
            }
        }
    }
}