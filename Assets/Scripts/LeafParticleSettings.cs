using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeafParticleSettings : FootstepsParticle
{
    ParticleSystem particle;
    public ParticleSystem[] particleChilds;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        //Check if particle has child particles
        if(transform.childCount > 0)
        {
            particleChilds = new ParticleSystem[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                particleChilds[i] = transform.GetChild(i).GetComponent<ParticleSystem>();
            }
        }
    }
    public override void EmitParticle()
    {
        Debug.Log(transform.parent.name);
        //Get Particle Burst Info
        var emission = particle.emission;
        ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[emission.burstCount];
        emission.GetBursts(bursts);
        int min = bursts[0].minCount;
        int max = bursts[0].maxCount;

        particle.Emit(Random.Range(min, max));
        if (particleChilds.Length > 0)
        {
            for (int i = 0; i < particleChilds.Length; i++)
            {
                var emis = particleChilds[i].emission;
                ParticleSystem.Burst[] childBursts = new ParticleSystem.Burst[emis.burstCount];
                emis.GetBursts(childBursts);
                int minChild = childBursts[0].minCount;
                int maxChild = childBursts[0].maxCount;

                particleChilds[i].Emit(Random.Range(minChild, maxChild));
            }
        } 
    }

}
