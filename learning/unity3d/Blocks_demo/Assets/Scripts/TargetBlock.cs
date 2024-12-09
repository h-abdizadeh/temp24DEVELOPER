using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class TargetBlock : MonoBehaviour
{
    AudioSource _audio;
    public List<AudioSource> blockAudios;
    bool soundPlay=false;
    // Start is called before the first frame update
    void Start()
    {
        blockAudios = FindObjectsByType<GameObject>(FindObjectsSortMode.None).Where(g => g.transform.name.Contains("enemy")).Select(b => b.GetComponent<AudioSource>()).ToList();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        blockAudios = FindObjectsByType<GameObject>(FindObjectsSortMode.None).Where(g => g.transform.name.Contains("enemy")).Select(b => b.GetComponent<AudioSource>()).ToList();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (!_audio.isPlaying && !blockAudios.Any(b => b.isPlaying) /*&& !soundPlay */)
        {
            _audio.Play();
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (!_audio.isPlaying && !blockAudios.Any(b=>b.isPlaying) /*&& !soundPlay*/)
        {
            _audio.Play();
        }
    }
}
