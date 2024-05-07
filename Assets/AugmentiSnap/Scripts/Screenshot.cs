using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using UnityEngine.UI;
//import System.IO;
using System;
//using NatSuite.Sharing;

public class Screenshot : MonoBehaviour
{
    
    public UnityEvent BeforeFrameCapture;
    public UnityEvent AfterFrameCapture;



    public Animator animator;

    public void TakeScreenShot() 
    {
        animator.SetTrigger("Play");
        Invoke(nameof(StartTakingScreenShot), 5);
    }

    public void StartTakingScreenShot()
    {

        StartCoroutine(ScreenshotEncode());
    }

    IEnumerator ScreenshotEncode()
    {
        BeforeFrameCapture.Invoke();
        yield return new WaitForEndOfFrame();
        // create a texture to pass to encoding
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24,false);
        // put buffer into texture
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        // split the process up--ReadPixels() and the GetPixels() call inside of the encoder are both pretty heavy
        yield return 0;



        


        byte[] bytes = texture.EncodeToPNG();

        //Save Image to path and
       string filePath = SaveImageToPath(texture);

        NativeGallery.SaveImageToGallery(bytes, "AugmentiSnap", "AugmentiSnap {0}.png");
        new NativeShare().AddFile(filePath).Share();

        AfterFrameCapture.Invoke();
       
      
    }


   
    

    public static int ImageCount
    {
        set
        {
            PlayerPrefs.SetInt("ImageCount", value);
        }
        get
        {
            return PlayerPrefs.GetInt("ImageCount");
        }
    }
    public static string SaveImageToPath(Texture2D texture)
    {
        ImageCount++;
        string filePath = Path.Combine(Application.persistentDataPath, "Trail Explorer " + ImageCount + ".png");
        File.WriteAllBytes(filePath, texture.EncodeToPNG());
        print(filePath);
        return filePath;
        
    }

    


    
   
   

    


    

}

