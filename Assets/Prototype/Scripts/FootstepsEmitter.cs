using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomAudio;

public class FootstepsEmitter : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string m_EventPath;
    //public AudioEntry lastEntry;
    public FMOD.Studio.System m_System;
    public FMOD.Studio.Bus m_Bus;
    

    [HideInInspector] public bool playStep = false;

    // FMOD Parameters
    [HideInInspector] float walkState = 1f;  // 0 - crouch , 1 - Walk , 2 - Run

    public FootstepsDatabase footstepsDB;

    FootstepsParameters m_footstepsParameters;
    [HideInInspector] public TerrainReader m_TerrainReader;

    string lastFloorName = "None";

    private void Start()
    {
        m_TerrainReader = GetComponent<TerrainReader>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playStep)
        {
            playStep = false;
            PlayFootstepSound();
        }

    }

    void PlayFootstepSound()
    {
        GetFloorComposition();
        m_System.getBus("" , out m_Bus);

        if (m_EventPath != null)
        {
            FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(m_EventPath);
            e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

            SetParameter(e, "Boy_status", walkState);
            SetParameter(e, "Boy_surface", (float)footstepsDB.entryList[m_TerrainReader.surfaceIndex].fmodParam);
            

            //Debug.Log("SoundStart");
            e.start();
            e.release();//Release each event instance immediately, there are fire and forget, one-shot instances. 
        }
    }

    void GetFloorComposition()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1000.0f))
        {
            /* New Implementation
            int materialIndex = GetMaterialIndex(hit);
            if (materialIndex != -1)
            {
                Material material = hit.collider.gameObject.GetComponent<Renderer>().materials[materialIndex];
            }
            */

            Floor thisFloor = hit.transform.GetComponent<Floor>();
            if (thisFloor != null)
            {
                string thisFloorName = thisFloor.GetFloorName();
                if (lastFloorName != thisFloorName)
                {
                    m_footstepsParameters = thisFloor.GetFloorParameters();
                }
            }
        }

    }


    void SetParameter(FMOD.Studio.EventInstance e, string name, float value)
    {
        FMOD.Studio.ParameterInstance parameter;
        FMOD.RESULT getOk = e.getParameter(name, out parameter);
        if (getOk == FMOD.RESULT.ERR_INVALID_PARAM)
        {
            return;
        }
        parameter.setValue(value);
    }

    public virtual void MakeStep()
    {
        //Debug.Log("Made step");
        playStep = true;
    }

    public void SetState(string state)
    {
        switch (state)
        {
            case "Walk":
                walkState = 0f;
                break;
            case "Run":
                walkState = 1f;
                break;
            case "Crouch":
                walkState = 2f;
                break;
            default:
                break;
        }
    }

    int GetMaterialIndex(RaycastHit hit)
    {
        Mesh m = hit.collider.gameObject.GetComponent<MeshFilter>().mesh;
        int[] triangle = new int[]
        {
            m.triangles[hit.triangleIndex * 3 + 0],
            m.triangles[hit.triangleIndex * 3 + 1],
            m.triangles[hit.triangleIndex * 3 + 2]
        };
        for (int i = 0; i < m.subMeshCount; ++i)
        {
            int[] triangles = m.GetTriangles(i);
            for (int j = 0; j < triangles.Length; j += 3)
            {
                if (triangles[j + 0] == triangle[0] &&
                    triangles[j + 1] == triangle[1] &&
                    triangles[j + 2] == triangle[2])
                    return i;
            }
        }
        return -1;
    }
}