using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // This function can be linked to your button's OnClick() event
    public void QuitGame()
    {
        // Logs a message so you can see it work in the Editor
        Debug.Log("Quit button pressed. Exiting game...");

        // Quits the application (works in builds, not in the Editor)
        Application.Quit();

    }
}