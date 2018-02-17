using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ParticleSystemManager : SerializedMonoBehaviour
{
    public static ParticleSystemManager instance = null;
    //Transform player;

    [BoxGroup("ParticleDB")]
    [TableMatrix(HorizontalTitle = "Texture", VerticalTitle = "State")]
    //public GameObject[,] LabledTable = new GameObject[15, 10];
    //[Sirenix.Serialization.OdinSerialize]
    [SerializeField]
    public GameObject[,] MyDB = new GameObject[4, 3];

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
       // player = GMController.instance.m_CharacterInterfaces[(int)GMController.instance.isCharacterPlaying].transform;
    }

    public void EmitRightParticle(int texture, int state, Vector3 textureNormal, Vector3 position)
    {
        if (MyDB[texture, state] != null)
        {
            //Set Position and Rotation
            MyDB[texture, state].transform.position = position + Vector3.up * 0.2f;
            // MyDB[texture, state].transform.rotation = Quaternion.LookRotation(textureNormal);
            //Emit single burst of particles
            MyDB[texture, state].transform.GetChild(0).GetComponent<FootstepsParticle>().EmitParticle();
        }
    }


}
