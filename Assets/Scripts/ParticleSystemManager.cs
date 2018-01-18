using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public static ParticleSystemManager instance = null;
    public ParticleDB particleData;
    Transform player;

    void Awake()
    {
        //Singleton
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        player = GMController.instance.m_CharacterInterfaces[(int)GMController.instance.isCharacterPlaying].transform;
    }

    public void EmitRightParticle(int texture, int state, Vector3 textureNormal)
    {
        particleData.MyDB[texture, state].transform.position = player.position;
        particleData.MyDB[texture, state].transform.rotation = Quaternion.LookRotation(Vector3.up);
        particleData.MyDB[texture, state].Emit(1);
    }
}
