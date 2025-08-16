using UnityEngine;

public class ApprovedBPLA : MonoBehaviour
{

    [SerializeField] GameObject panelUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ReturnToScan()
    {
        panelUI.SetActive(false);
    }
}
