using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TerrainReader : MonoBehaviour {

    public LayerMask groundMask;
    [ReadOnly]
    public int surfaceIndex;

    Terrain m_Terrain;
    TerrainData m_TerrainData;
    Vector3 m_TerrainPosition;

    Material lastMaterial;

    Ray m_TerrainRay;
    RaycastHit m_TerrainRayHit;

    float[] cellMix;
    int alphamapWidth, alphamapHeight;
    float[,,] splatmapData;

    void GetTexMixture(Vector3 position)
    {
        int mapX = (int)(((position.x - m_TerrainPosition.x) / m_TerrainData.size.x) * alphamapWidth);
        int mapZ = (int)(((position.z - m_TerrainPosition.z) / m_TerrainData.size.z) * alphamapHeight);

        // get the splat data for this cell as a 1x1xN 3d array (where N = number of textures)
        //float[,,] splatmapData = m_TerrainData.GetAlphamaps(mapX, mapZ, 1, 1);

        // extract the 3D array data to a 1D array:


        for (int i = 0; i < cellMix.Length; i++)
        {
            cellMix[i] = splatmapData[mapZ, mapX, i]; // or the other way around ?
        }

    }

    int GetMainTexture(Vector3 position)
    {
        // returns the zero-based index of the most dominant texture
        // on the main terrain at this world position.
        GetTexMixture(position);

        float maxMix = 0;
        int maxIndex = 0;

        for (int i = 0; i < cellMix.Length; i++)
        {
            if (cellMix[i] > maxMix)
            {
                maxIndex = i;
                maxMix = cellMix[i];

            }
        }

        //Debug.Log(maxIndex);
        return maxIndex;

    }

    // Use this for initialization
    void Start () {

        m_TerrainData = Terrain.activeTerrain.terrainData;
        alphamapWidth = m_TerrainData.alphamapWidth;
        alphamapHeight = m_TerrainData.alphamapHeight;

        m_TerrainRay = new Ray(transform.position + Vector3.up, Vector3.down);
        Physics.Raycast(m_TerrainRay, out m_TerrainRayHit, 1.5f);

        splatmapData = m_TerrainData.GetAlphamaps(0, 0, alphamapWidth, alphamapHeight);
        cellMix = new float[splatmapData.GetUpperBound(2) + 1];


        if (m_TerrainRayHit.collider.tag == "Ground")
        {
            m_Terrain = m_TerrainRayHit.collider.GetComponent<Terrain>();
            m_TerrainPosition = m_Terrain.transform.position;
        }
        else
        {
            lastMaterial = m_TerrainRayHit.collider.GetComponent<MeshRenderer>().material;
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        m_TerrainRay = new Ray(transform.position + Vector3.up, Vector3.down);
        Physics.Raycast(m_TerrainRay, out m_TerrainRayHit, 1.5f);
        Debug.DrawLine(m_TerrainRay.origin, m_TerrainRay.origin + m_TerrainRay.direction * 0.1f, Color.red);

        if (m_TerrainRayHit.collider.tag == "Ground")
        {    
            surfaceIndex = GetMainTexture(m_TerrainRayHit.point);
        }
        else
        {
            surfaceIndex = 0;
        }

    }
}
