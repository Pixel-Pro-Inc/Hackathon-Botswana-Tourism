using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
   private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Play()
    {
        videoPlayer.Play();
    }
    void Pause()
    {
        videoPlayer.Pause();
    }
    void Stop()
    {
        videoPlayer.Stop();
    }

    public void UrlToVideo(string url)
    {
        videoPlayer.source = VideoSource.Url;
        //videoPlayer.source = VideoSource.VideoClip; this should remain as a comment cause we never call it and the video already exists
        videoPlayer.url = url;
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += VideoPlayer_prepareCompleted;
    }

    private void VideoPlayer_prepareCompleted(VideoPlayer source)
    {
        Play();
    }
}
