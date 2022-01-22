using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    public static AudioManager am;
    public enum Track {None, Drum2, Synth1, Guitar1, Synth2}
    public float lerpTime;
    public List<AudioSource> audioSources;


    private void Awake()
    {
        am = this;
    }

    IEnumerator AudioLerp(AudioSource _track, float _a, float _b)
    {
        float timer = 0f;
        while (timer < lerpTime)
        {
            _track.volume = Mathf.Lerp(_a, _b, timer / lerpTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    

    public void Mute(Track _track, bool _mute)
    {

        switch (_track)
        {
            case Track.Drum2:
                StartCoroutine(AudioLerp(audioSources[0], _mute ? 1 : 0, _mute ? 0 : 1));
                break;
            case Track.Synth1:
                StartCoroutine(AudioLerp(audioSources[1], _mute ? 1 : 0, _mute ? 0 : 1));
                break;
            case Track.Guitar1:
                StartCoroutine(AudioLerp(audioSources[2], _mute ? 1 : 0, _mute ? 0 : 1));
                break;
            case Track.Synth2:
                StartCoroutine(AudioLerp(audioSources[3], _mute ? 1 : 0, _mute ? 0 : 1));
                break;
            default:
                break;
        }
    }

}
