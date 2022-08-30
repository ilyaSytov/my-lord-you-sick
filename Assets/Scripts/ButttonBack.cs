using UnityEngine;
using UnityEngine.SceneManagement;

public class ButttonBack : MonoBehaviour {
    public void ButtonClicked(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
