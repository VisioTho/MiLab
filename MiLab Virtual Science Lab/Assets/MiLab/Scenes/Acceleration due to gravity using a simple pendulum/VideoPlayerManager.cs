using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Slider videoLengthSlider;
    private float currentVideoTimeStamp;
    float videoLength;

    private void Start()
    {
        videoLength = (float)videoPlayer.length;
        videoLengthSlider.maxValue = videoLength;
    }
    private void OnMouseDown()
    {
        Debug.Log("pressed");
        if (!videoPlayer.isPlaying)
            videoPlayer.Play();
        else
            videoPlayer.Pause();
    }

    public void PlayVideo()
    {
        if (!videoPlayer.isPlaying)
            videoPlayer.Play();
    }

    public void PauseVideo()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
    }

    private void TrackVideo()
    {
        videoLengthSlider.value = (float)videoPlayer.time;
    }

    //}
    private void FixedUpdate()
    {
        TrackVideo();
    }

}
