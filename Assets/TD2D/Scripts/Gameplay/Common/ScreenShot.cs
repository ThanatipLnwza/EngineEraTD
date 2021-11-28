using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScreenShot : MonoBehaviour
{
    //Set screenshot resolutions
    public int captureWidth = 1920;
    public int captureHeight = 1080;
    
    // configure with raw, jpg, png, or ppm (Picture format)
    public enum Format { RAW, JPG, PNG, PPM };
    public Format format = Format.JPG;
    
    // folder to write outputFolder;
    private string outputFolder;
    //var need for screenshot
    private Rect rect;
    private RenderTexture renderTexture;
    private Texture2D screenShot;

    public bool isProcessing;
    
    //var to show image
    private byte[] currentTexture;
    public Image showImage;
    public UnityEvent OnShowImage;
    
    void Start()
    {
        outputFolder = Application.dataPath + "/../Screenshots/";
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
            Debug.Log("Save Path will be: " + outputFolder);
        }
    }

    private string CreateFileName(int width, int height)
    {
        // timestamp to append to screenshot
        string timestamp = DateTime.Now.ToString("ddMMyyTHHmmss");
        
        // use width, height, and timestamp for unique file
        var filename = string.Format("{0}/screen_{1}x{2}_{3}.{4}",outputFolder,width,height,timestamp,format.ToString().ToLower());
        
        return filename;
        
    }

    private void CaptureScreenShot()
    {
        isProcessing = true;
        
        // create screenshot obj
        if (renderTexture == null)
        {
            // create off-screen render texture to be rendered into
            rect = new Rect(0, 0, captureWidth, captureHeight);
            renderTexture = new RenderTexture(captureWidth,captureHeight,24);
            screenShot = new Texture2D(captureWidth, captureHeight,TextureFormat.RGB24,false);
        }
        
        // get main camera and render its output into the off=screen render texture created above
        Camera camera = Camera.main;
        camera.targetTexture = renderTexture;
        camera.Render();
        
        // mark the render texture as active and read current pixel data into the Texture2D
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect,0,0);
        
        // reset the texture and remove the render texture from the Camera since were done reading the screen data
        camera.targetTexture = null;
        RenderTexture.active = null;
        
        // get filename
        string filename = CreateFileName((int)rect.width, (int)rect.height);
        
        // get file header/data byte for each image format
        byte[] fileHeader = null;
        byte[] fileData = null;
        
        // set the format and encode

        switch (format)
        {
            case Format.RAW:
                fileData = screenShot.GetRawTextureData();
                break;
            case Format.PNG:
                fileData = screenShot.EncodeToPNG();
                break;
            case Format.JPG:
                fileData = screenShot.EncodeToJPG();
                break;
            case Format.PPM:
                string headerStr = string.Format("P6\n{0} {1}\n255\n", rect.width, rect.height);
                fileHeader = System.Text.Encoding.ASCII.GetBytes(headerStr);
                fileData = screenShot.GetRawTextureData();
                break;
        } 
        currentTexture = fileData;
        new System.Threading.Thread(() =>
        {
            var file = System.IO.File.Create(filename);

            if (fileHeader != null)
            {
                file.Write(fileHeader,0,fileHeader.Length);
            }
            file.Write(fileData,0,fileData.Length);
            file.Close();
            Debug.Log(string.Format("Screenshot Saved {0}, size {1}",filename,filename.Length));
            isProcessing = false;
        }
            ).Start();
        StartCoroutine(ShowImage());
        Destroy(renderTexture);
        renderTexture = null;
        screenShot = null;

    }

    public void TakeScreenShot()
    {
        if (!isProcessing)
        {
            CaptureScreenShot();
        }
        else
        {
            Debug.Log("Currently Processing");
        }
    }

    public IEnumerator ShowImage()
    {
        yield return new WaitForEndOfFrame();

        showImage.material.mainTexture = null;
        Texture2D texture = new Texture2D(captureWidth, captureHeight,TextureFormat.RGB24,false);
        texture.LoadImage(currentTexture);
        showImage.material.mainTexture = texture;
        
        OnShowImage?.Invoke();
    }
    
}
