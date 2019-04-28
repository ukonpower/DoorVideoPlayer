using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoController : MonoBehaviour
{
    private VideoPlayer vp;
    private RawImage rawImage;
  　  private string[] videoList;
    private int lastVideo = -1;
    private int cNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        rawImage = GetComponent<RawImage>();
        videoList = getVideoFiles();
    }

    string[] getVideoFiles(){
        string basePath = Application.streamingAssetsPath + "/videos/";

        DirectoryInfo dInfo = new DirectoryInfo(basePath);
        FileInfo[] fInfo = dInfo.GetFiles("*.mp4");

        string[] paths = new string[fInfo.Length];
        for(int i = 0; i < fInfo.Length; i++)
        {
            paths[i] = basePath + fInfo[i].Name;
        }
        return paths;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo(){
        cNum = (cNum + 1) % videoList.Length;

        vp.url = videoList[cNum];
        vp.Play();
        lastVideo = cNum;
    }

    public void StopVideo(){
        vp.url = Application.streamingAssetsPath + "/videos/alpha.webm";
        vp.Play();
    }
}
