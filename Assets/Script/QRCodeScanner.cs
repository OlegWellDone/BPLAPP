using UnityEngine;
using UnityEngine.UI;
using ZXing;
using TMPro;

public class QRCodeScanner : MonoBehaviour
{
    [SerializeField] private RawImage backgroundImage;
    [SerializeField] private AspectRatioFitter aspectRF;
    [SerializeField] private TextMeshProUGUI outputText;
    [SerializeField] private RectTransform scanZone;

    private bool isCamAvaliable;
    private WebCamTexture cameraImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetupCamera()
    {
        //доступ ко всем камерам на телефоне
        WebCamDevice[] camDevices = WebCamTexture.devices;
        //проверяем есть ли вообще камеры
        if (camDevices.Length == 0)
        {
            isCamAvaliable = false;
            return;
        }

        for (int i = 0; i < camDevices.Length; i++)
        {
            if (camDevices[i].isFrontFacing == false)
            {
                //устанавливаем наше изображение с камеры по определенным размерам если оно смотрит прямо
                cameraImage = new WebCamTexture(camDevices[i].name, (int)scanZone.rect.width, (int)scanZone.rect.height);
            }
        }

        //запускаем изображение и назначаем фону это изображение (все-таки оно видео трансляция)
        cameraImage.Play();
        backgroundImage.texture = cameraImage;

        isCamAvaliable = true;
    }

    private void UpdateCameraRender()
    {
        if (isCamAvaliable == false)
        {
            return;
        }
        float ratio = (float)cameraImage.width / (float)cameraImage.height;
        aspectRF.aspectRatio = ratio;

        //повернули 
        int orientation = -cameraImage.videoRotationAngle;
        backgroundImage.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }
    public void OnClickScan()
    {
        Scan();
    }

    private void Scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result res = barcodeReader.Decode(cameraImage.GetPixels32(), cameraImage.width, cameraImage.height);
            if (res != null)
            {
                outputText.text = res.Text;
            }
            else
            {
                outputText.text = "Nothing see";
            }
        }
        catch
        {
            outputText.text = "Failed try";

        }
    }
}
