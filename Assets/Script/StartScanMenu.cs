using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScanMenu : MonoBehaviour
{
    [Tooltip("На какую сцену будем переключаться: 0 - main menu, 1 - main scene, 2 - QRReader, 3 - QRGenerator, 4 - SpecInfo")]
    [SerializeField] int nextScene;
    public void ScanQR()
    {
        Debug.Log("ScanQR Code");
        SceneManager.LoadScene("Assets/Scenes/MainScene.unity");
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
