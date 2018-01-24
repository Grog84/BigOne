/* ======================================================================================== */
/* FMOD Studio - Unity Integration Demo.                                                    */
/* Firelight Technologies Pty, Ltd. 2012-2016.                                              */
/* Liam de Koster-Kjaer                                                                     */
/*                                                                                          */
/* Use this script in conjunction with the Viking Village scene tutorial and Unity 5.4.     */
/* http://www.fmod.org/training/                                                            */
/*                                                                                          */
/* 1. Import Viking Village asset package                                                   */
/* 2. Import FMOD Studio Unity Integration package                                          */
/* 3. Replace Audio listener with FMOD Studio listener on player controller                 */
/*   (FlyingRigidBodyFPSController_HighQuality)                                             */
/* 4. Add footsteps script to the player controller                                         */
/* 5. Set footsteps script variable ‘Step Distance’ to a reasonable value (2.0f)            */
/* 6. Change terrain texture import settings so we can sample pixel values                  */
/*     - terrain_01_m                                                                       */
/*     - terrain_wetmud_01_sg                                                               */
/*         - Texture Type: Advanced                                                         */
/*         - Non Power of 2: N/A                                                            */
/*         - Mapping: None                                                                  */
/*         - Convolution Type: N/A                                                          */
/*         - Fixup Edge Seams: N/A                                                          */
/*         - Read/Write Enabled: Yes                                                        */
/*         - Import Type: Default                                                           */
/*         - Alpha from Greyscale: No                                                       */
/*         - Alpha is Transparency: No                                                      */
/*         - Bypass sRGB sampling: No                                                       */
/*         - Encode as RGBM: Off                                                            */
/*         - Sprite Mode: None                                                              */
/*         - Generate Mip Maps: No                                                          */
/*         - Wrap Mode: Repeat                                                              */
/*         - Filter Mode: Bilinear                                                          */
/*         - Aniso Level: 3                                                                 */
/* ======================================================================================== */


using UnityEngine;
using System.Collections;

//This script plays footstep sounds.
//It will play a footstep sound after a set amount of distance travelled.
//When playing a footstep sound, this script will cast a ray downwards. 
//If that ray hits the ground terrain mesh, it will retreive material values to determine the surface at the current position.
//If that ray does not hit the ground terrain mesh, we assume it has hit a wooden prop and set the surface values for wood.
public class Footsteps : MonoBehaviour
{
	//FMOD Studio variables
	//The FMOD Studio Event path.
	//This script is designed for use with an event that has a game parameter for each of the surface variables, but it will still compile and run if they are not present.
	[FMODUnity.EventRef]
	public string m_EventPath;

	//Surface variables
	//Range: 0.0f - 1.0f
	//These values represent the amount of each type of surface found when raycasting to the ground.
	//They are exposed to the UI (public) only to make it easy to see the values as the player moves through the scene.
	public float m_Wood;
	public float m_Water;
	public float m_Dirt;
	public float m_Sand;

	//Step variables
	//These variables are used to control when the player executes a footstep.
	//This is very basic, and simply executes a footstep based on distance travelled.
	//Ideally, in this case, footsteps would be triggered based on the headbob script. Or if there was an animated player model it could be triggered from the animation system.
	//You could also add variation based on speed travelled, and whether the player is running or walking. 
	public float m_StepDistance = 2.0f;
	float m_StepRand;
	Vector3 m_PrevPos;
	float m_DistanceTravelled;

	//Debug variables
	//If m_Debug is true, this script will:
	// - Draw a debug line to represent the ray that was cast into the ground.
	// - Draw the triangle of the mesh that was hit by the ray that was cast into the ground.
	// - Log the surface values to the console.
	// - Log to the console when an expected game parameter is not found in the FMOD Studio event.
	public bool m_Debug;
	Vector3 m_LinePos;
	Vector3 m_TrianglePoint0;
	Vector3 m_TrianglePoint1;
	Vector3 m_TrianglePoint2;

	void Start()
	{
		//Initialise random, set seed
		Random.InitState(System.DateTime.Now.Second);

		//Initialise member variables
		m_StepRand = Random.Range(0.0f, 0.5f);
		m_PrevPos = transform.position;
		m_LinePos = transform.position;
	}

	void Update()
	{
		m_DistanceTravelled += (transform.position - m_PrevPos).magnitude;
		if(m_DistanceTravelled >= m_StepDistance + m_StepRand)//TODO: Play footstep sound based on position from headbob script
		{
			PlayFootstepSound();
			m_StepRand = Random.Range(0.0f, 0.5f);//Adding subtle random variation to the distance required before a step is taken - Re-randomise after each step.
			m_DistanceTravelled = 0.0f;
		}

		m_PrevPos = transform.position;

		if(m_Debug)
		{
			Debug.DrawLine(m_LinePos, m_LinePos + Vector3.down * 1000.0f);
			Debug.DrawLine(m_TrianglePoint0, m_TrianglePoint1);
			Debug.DrawLine(m_TrianglePoint1, m_TrianglePoint2);
			Debug.DrawLine(m_TrianglePoint2, m_TrianglePoint0);
		}
	}

	void PlayFootstepSound()
	{
		//Defaults
		m_Water = 0.0f;
		m_Dirt = 1.0f;
		m_Sand = 0.0f;
		m_Wood = 0.0f;

		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.down, out hit, 1000.0f))
		{
			if(m_Debug)
				m_LinePos = transform.position;

			if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))//The Viking Village terrain mesh (terrain_near_01) is set to the Ground layer.
			{
				int materialIndex = GetMaterialIndex(hit);
				if(materialIndex != -1)
				{
					Material material = hit.collider.gameObject.GetComponent<Renderer>().materials[materialIndex];
					if(material.name == "mat_terrain_near_01 (Instance)")//This texture name is specific to the terrain mesh in the Viking Village scene.
					{
						if(m_Debug)
						{//Calculate the points for the triangle in the mesh that we have hit with our raycast.
							MeshFilter mesh = hit.collider.gameObject.GetComponent<MeshFilter>();
							if(mesh)
							{
								Mesh m = hit.collider.gameObject.GetComponent<MeshFilter>().mesh;
								m_TrianglePoint0 = hit.collider.transform.TransformPoint(m.vertices[m.triangles[hit.triangleIndex * 3 + 0]]);
								m_TrianglePoint1 = hit.collider.transform.TransformPoint(m.vertices[m.triangles[hit.triangleIndex * 3 + 1]]);
								m_TrianglePoint2 = hit.collider.transform.TransformPoint(m.vertices[m.triangles[hit.triangleIndex * 3 + 2]]);
							}
						}

						//The mask texture determines how the material's main two textures are blended.
						//Colour values from each texture are blended based on the mask texture's alpha channel value.
							//0.0f is full dirt texture, 1.0f is full sand texture, 0.5f is half of each. 
						Texture2D maskTexture = material.GetTexture("_Mask") as Texture2D;
						Color maskPixel = maskTexture.GetPixelBilinear(hit.textureCoord.x, hit.textureCoord.y);

						//The specular texture maps shininess / gloss / reflection to the terrain mesh.
						//We are using it to determine how much water is shown at the cast ray's point of intersection.
						Texture2D specTexture2 = material.GetTexture("_SpecGlossMap2") as Texture2D;
						//We apply tiling assuming it is not already applied to hit.textureCoord2
						float tiling = 40.0f;//This is a public variable set on the material, we could reference the actual variable but I ran out of time.
						float u = hit.textureCoord.x % (1.0f / tiling);
						float v = hit.textureCoord.y % (1.0f / tiling);
						Color spec2Pixel = specTexture2.GetPixelBilinear(u, v);

						float specMultiplier = 6.0f;//We use a multiplier to better represent the amount of water.
						m_Water = maskPixel.a * Mathf.Min(spec2Pixel.a * specMultiplier, 0.9f);//Only the sand texture has water, so we multiply by the mask pixel alpha value.
						m_Dirt = (1.0f - maskPixel.a);
						m_Sand = maskPixel.a - m_Water * 0.1f;//Ducking the sand a little for the water
						m_Wood = 0.0f;
					}
				}
			}
			else//If the ray hits somethign other than the ground, we assume it hit a wooden prop (This is specific to the Viking Village scene) - and set the parameter values for wood.
			{
				m_Water = 0.0f;
				m_Dirt = 0.0f;
				m_Sand = 0.0f;
				m_Wood = 1.0f;
			}
		}

		if(m_Debug)
			Debug.Log("Wood: " + m_Wood + " Dirt: " + m_Dirt + " Sand: " + m_Sand + " Water: " + m_Water);

		if(m_EventPath != null)
		{
			FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(m_EventPath);
			e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

			SetParameter(e, "Wood", m_Wood);
			SetParameter(e, "Dirt", m_Dirt);
			SetParameter(e, "Sand", m_Sand);
			SetParameter(e, "Water", m_Water);

			e.start();
			e.release();//Release each event instance immediately, there are fire and forget, one-shot instances. 
		}
	}

	void SetParameter(FMOD.Studio.EventInstance e, string name, float value)
	{
		FMOD.Studio.ParameterInstance parameter;
		e.getParameter(name, out parameter);
        if (true)
            //if (parameter == null)
		{
			if(m_Debug)
				Debug.Log("Parameter named: " + name + " does not exist");
			return;
		}
		parameter.setValue(value);
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
		for(int i = 0; i < m.subMeshCount; ++i)
		{
			int[] triangles = m.GetTriangles(i);
			for(int j = 0; j < triangles.Length; j += 3)
			{
				if(triangles[j + 0] == triangle[0] &&
					triangles[j + 1] == triangle[1] &&
					triangles[j + 2] == triangle[2])
					return i;
			}
		}
		return -1;
	}


    //From web

//void Start()
//{
//    mTerrainData = Terrain.activeTerrain.terrainData;
//    alphamapWidth = mTerrainData.alphamapWidth;
//    alphamapHeight = mTerrainData.alphamapHeight;

//    mSplatmapData = mTerrainData.GetAlphamaps(0, 0, alphamapWidth, alphamapHeight);
//    mNumTextures = mSplatmapData.Length / (alphamapWidth * alphamapHeight);
//}

//private Vector3 ConvertToSplatMapCoordinate(Vector3 playerPos)
//{
//    Vector3 vecRet = new Vector3();
//    Terrain ter = Terrain.activeTerrain;
//    Vector3 terPosition = ter.transform.position;
//    vecRet.x = ((playerPos.x - terPosition.x) / ter.terrainData.size.x) * ter.terrainData.alphamapWidth;
//    vecRet.z = ((playerPos.z - terPosition.z) / ter.terrainData.size.z) * ter.terrainData.alphamapHeight;
//    return vecRet;
//}

//void Update()
//{
//    int terrainIdx = GetActiveTerrainTextureIdx();
//    PlayFootStepSound(terrainIdx);
//}

//int GetActiveTerrainTextureIdx()
//{
//Vector3 playerPos = PlayerController.Instance.position;
//Vector3 TerrainCord = ConvertToSplatMapCoordinate(playerPos);
//int ret = 0;
//float comp = 0f;
//for (int i = 0; i < mNumTextures; i++)
//{
//    if (comp < mSplatmapData[(int)TerrainCord.z, (int)TerrainCord.x, i])
//        ret = i;
//}
//return ret;
//}

/* WEB 2
 You can read values from the "Mix Map" (a.k.a. Splat Map, Alpha Map, Control Texture - these are often used to refer to the same thing) using some undocumented terrain functions. The Mix Map controls the blending of each of your textures across the terrain, and is a 2D grid of values. The size of this grid is determine by the "Control Texture Resolution" setting in the terrain dialog box.

So, you'll need to convert the player's world coordinates to coordinates which represent the grid cell of the "control texture" which the player is currently within. A similar technique is described in this question, but in this case it converts it to the 2d heightmap grid:

How to translate WORLD coordinates to TERRAIN coordinates?

However instead of the heightmap size, you'll need to use the Mix Map size which can be read using the undocumented command, terrain.alphamapResolution.

So, to convert, you need to subtrack the terrain's position, divide by the terrain size, and multiply by that Mix Map Size:

var terrainData = terrain.terrainData;
var terrainPos = terrain.transform.position;
var mapX = ((player.x - terrainPos.x) / terrainData.size.x) * terrainData.alphamapWidth;
var mapZ = ((player.z - terrainPos.z) / terrainData.size.z) * terrainData.alphamapHeight;
Next you need to use those coordinates to sample the values which control the mix of textures at that position, using the undocumented function GetAlphamaps, like this:

var splatmapData = terrain.GetAlphamaps(x, y, width, height); 
Because the alphamap data is a 2d grid, the x & y values here are integers, as are the width & height values (which let you sample an area of the grid of any size). Because you're only interested in sampling the cell under the player, the width and height should be 1.

Now you're left with a variable (splatmapData) which contains a 3d array. To read the mix levels of each texture layer, you need something like this:

var texture1Level = splatmapData[0,0,0];  // texture layer 1
var texture2Level = splatmapData[0,0,1];  // texture layer 2
var texture3Level = splatmapData[0,0,2];  // texture layer 3
var texture4Level = splatmapData[0,0,3];  // texture layer 4
(the reason you have 0,0 at the start is because "splatmapData" could have contained a sampled area larger than 1x1 in size, so this specifies the location within the sampled area. Because our width & height was 1,1 - the sampled area is only one cell in size).

The number of lines above should match the number of texture layers you're using in your terrain. If an area is 100% covered in one texture, you should find that texture level has a value of 1.0, and the rest have a value of 0.0. If there is a blend of textures at that location, you'll find that more than one layer has a value larger than 0.0, and that they all add up to a total of 1.0.
 */
}
