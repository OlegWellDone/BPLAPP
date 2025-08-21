using UnityEngine;
using ZXing.QrCode;
using ZXing;
using TMPro;
using UnityEngine.UI;

public class QRCodeGenerator : MonoBehaviour
{

    [SerializeField] private RawImage QRImage;
    [SerializeField] private TMP_InputField inputText;

    private Texture2D QRcode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QRcode = new Texture2D(256, 256);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Color32[] Encode(string textInput, int width, int height)
    {
        BarcodeWriter writerBar = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };

        return writerBar.Write(textInput);
    }

    public void OnClickDoQR()
    {
        EncodeTextToQR();
    }

    private void EncodeTextToQR()
    {
        
        
        string textWrite = string.IsNullOrEmpty(inputText.text) ? "WriteSMTH" : inputText.text;
        //byte[] utf8string = System.Text.Encoding.UTF8.GetBytes(textWrite);
        Color32[] convertedPixelToImage = Encode(textWrite, QRcode.width, QRcode.height);
        QRcode.SetPixels32(convertedPixelToImage);
        QRcode.Apply();

        QRImage.texture = QRcode;
    }
}
