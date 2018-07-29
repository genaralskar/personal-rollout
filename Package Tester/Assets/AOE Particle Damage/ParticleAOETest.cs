using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAOETest : MonoBehaviour {
    
    private ParticleSystem part;
    public ParticleSystem aoeParticle;
    public LayerMask aoeCheckLayers;

    private List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        //get WeaponManager for damage amount
    }

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        print("Particle collided at: " + collisionEvents[0].intersection);
        AOECheck(collisionEvents[0].intersection);
    }

    private void AOECheck(Vector3 pos)
    {
        Collider[] hitColliders = Physics.OverlapSphere(pos, aoeParticle.main.startSize.constant, aoeCheckLayers);
        print(aoeParticle.main.startSize.constant);
        int i = 0;
        while (i < hitColliders.Length)
        {
           //Get Hurtbox, do damage

            i++;
        }
    }


}
