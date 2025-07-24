using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScanMenu : MonoBehaviour
{
    public void ScanQR()
    {
        Debug.Log("ScanQR Code");
       SceneManager.LoadScene("Assets/Scenes/MainScene.unity");
    }
}
