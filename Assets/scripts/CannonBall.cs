using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject ParticleShoot; 

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var layerID = collision.collider.gameObject.layer;
        var layerName = LayerMask.LayerToName(layerID);

        GameObject particlesObject = null;

        if(layerName == "Terrain")
            particlesObject = ParticleShoot;

        if(particlesObject != null)
        {
            var position = collision.contacts[0].point;
            GameObject particle = Instantiate(particlesObject, position, Quaternion.identity);
            Destroy(particle, 1f);
        }
    }
}
