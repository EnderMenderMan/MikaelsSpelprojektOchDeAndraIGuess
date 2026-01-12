
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class videoscript : MonoBehaviour
{

    VideoPlayer video;

    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }


    private void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(7);
    }
}