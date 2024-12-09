using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int inTargetArea;

    private void OnCollisionEnter(Collision collision)
    {
        var tempTransform = collision.transform;

        if (tempTransform.tag.ToLower() is "cube" || tempTransform.tag.ToLower() is "block")
        {        
            transform.GetComponent<ParticleSystem>().Play();
            StartCoroutine(Delay(transform));

            tempTransform.GetComponent<MeshRenderer>().enabled = false;
            tempTransform.GetComponent<ParticleSystem>().Play();
            tempTransform.GetComponent<BoxCollider>().isTrigger = true;

            if (tempTransform.tag.ToLower() is "cube")
                tempTransform.GetComponent<Rigidbody>().isKinematic = true;
           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        var tag = other.tag.ToLower();
        if (tag is "target" || tag is "stand")
        {
            //transform.name = "inTargetArea";
            Destroy(gameObject);
        }
    }



    private IEnumerator Delay(Transform t)
    {
        yield return new WaitForSecondsRealtime(Time.deltaTime);
        t.GetComponent<MeshRenderer>().enabled = false;
        t.GetComponent<Rigidbody>().isKinematic = false;
    }

}
