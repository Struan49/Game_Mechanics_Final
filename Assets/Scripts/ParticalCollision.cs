using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem; // Fixed typo from 'ParticalSystem' to 'ParticleSystem'
    public SpriteRenderer sr;
    public bool once = true;

    private void OnTriggerEnter2D(Collider2D other) // Fixed 'collider2D' to 'Collider2D'
    {
        if (other.gameObject.CompareTag("Player") && once) // Fixed 'compareTag' to 'CompareTag'
        {
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.main.duration; // Access 'main.duration' for correct duration

            em.enabled = true;
            collisionParticleSystem.Play();

            once = false;
            Destroy(sr); // Fixed 'Destory' to 'Destroy'
            Invoke(nameof(DestroyObj), dur); // Fixed 'invoke' to 'Invoke'
        }
    }

    void DestroyObj()
    {
        Destroy(gameObject); // Fixed 'Destory' to 'Destroy'
    }
}
