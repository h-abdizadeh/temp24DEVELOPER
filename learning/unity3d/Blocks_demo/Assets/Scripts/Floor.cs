using UnityEngine;

public class Floor : MonoBehaviour
{
    PlayerCamera player;
    AudioSource _audio;
    private void Start()
    {
        player = FindFirstObjectByType<PlayerCamera>();
        _audio=GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        var tag = collision.gameObject.transform.tag.ToLower(); 
        if (tag is "block")
        {
            player.score++;
            _audio.Play();
            Destroy(collision.gameObject);

        }
        
     
    }
    private void OnTriggerEnter(Collider other)//when block in fall collider by enemy cube is triger=true
    {
        if (other.tag.ToLower() is "block")
        {
            player.score++;
                 Destroy(other.gameObject);
        }
    }
   
}
