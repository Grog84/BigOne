using RootMotion;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightTestScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    Vector3 Origin = new Vector3(-0.12f, 20.77f, 3.49f);
    private List<Light> LightList = new List<Light>();
    public static List<Light> LightTriggerList = new List<Light>();
    private void Start()
    {
        //Trovo Tutte le luci
        Light[] _LightList;
        _LightList = FindObjectsOfType<Light>();
        foreach (Light item in _LightList)
        {
            // e seleziono solo i tipi Point (I nostri Faretti)
            if (item.type == LightType.Point)
            {
                LightList.Add(item);
            }
        }

    }
  
    private void Update()
    {
        Debug.Log(LightTriggerList.Count);
        if (LightTriggerList.Count == 0)
        {
            //Luce Fuori
            this.gameObject.transform.position = Origin;
          //  this.GetComponent<Light>().type = LightType.Directional;
        }
       else if (LightTriggerList.Count ==1)
        {
            this.gameObject.transform.position = LightTriggerList[0].gameObject.transform.position+Vector3.up;
            this.GetComponent<Light>().color = Color.white;
     //    this.GetComponent<Light>().type = LightType.Point;
            //Butta La luce alla prima luce
        }
       else if (LightTriggerList.Count >= 2)
        {
            foreach (Light item in LightTriggerList)
            {
                Debug.DrawLine(
                    Player.transform.position, 
                    item.gameObject.transform.position);
            }
            this.gameObject.transform.position = NearestSpotlight(LightTriggerList);
        }
    }

    public static void TriggerLightEnter(GameObject _light)
    {
        LightTriggerList.Add((Light)_light.GetComponent<Light>());
    }
    public static void TriggerLightExit(GameObject _light)
    {
        LightTriggerList.Remove((Light)_light.GetComponent<Light>());
    }
    public  Vector3 NearestSpotlight(List<Light> LightConflict)
    {

        float[] Distance = new float[LightConflict.Count];
        int index = -1;
        float min = 10000000000000;
        for (int i = 0; i < Distance.Length; i++)
        {
            Distance[i] = Vector3.Distance(Player.transform.position, LightConflict[i].gameObject.transform.position);

        }
        for (int i = 0; i < Distance.Length; i++)
        {
            if (Distance.Min() == Distance[i])
            {
                Debug.Log(Distance.Min());
                index = i;

            }

        }


        return LightConflict[index].transform.position;
    }
}




#region Script da Non buttare
//Vector3 Origin = new Vector3(-0.12f, 20.77f, 3.49f);

/* public bool onAnFaretto;

   [Range(0.0f, 10.0f)]
   public float range;*/
//public Transform player;
//public Light worldLight;
//    public Transform worldLightTransform;
//  private void Update()
//    {
//        Debug.DrawLine(player.position, this.gameObject.transform.position, Color.yellow);
//}
// worldLight.type = LightType.Point;
// worldLight.range = 5.15f;
//  worldLightTransform.position = this.gameObject.transform.position + Vector3.up;
//   worldLight.type = LightType.Directional;
//   worldLightTransform.position = Origin;
#endregion
#region Old Script Faretti

// private Light thisLight;
// private Transform thisTransform;



// 
///*
//         if (Vector3.Distance(player.position, item.GetComponent<Transform>().position) <= range)
//         {
//             this.gameObject.transform.position = item.GetComponent<Transform>().position;
//             this.gameObject.transform.position += Vector3.up;
//             this.gameObject.GetComponent<Light>().type = item.type;

//             //   onAnFaretto = true;
//         }
//         else //if(Vector3.Distance(player.position, item.GetComponent<Transform>().position) > range && this.gameObject.transform.position!=Origin)
//         {
//         this.gameObject.GetComponent<Light>().type = LightType.Directional;
//             this.gameObject.transform.position = Origin;

//         }
//      }*/

// // Update is called once per frame
//

// void Update()
// {
//     thisLight = this.GetComponent<Light>();
//     thisTransform = this.GetComponent<Transform>();
//     foreach (Light item in LightList)
//     {
//         Distance = Vector3.Distance(player.position, item.GetComponent<Transform>().position);
//         if (Distance <= range)
//         {
//             onAnFaretto = true;
//             AccendiFaretto(onAnFaretto);
//         }
//         if (!onAnFaretto)
//         {
//             SpegniFaretto();
//         }

//     }

//     
//     /*
//     else
//     {
//         onAnFaretto = false;
//         SpegniFaretto();
//     }*/

//     /* if (Distance > range)
//         onAnFaretto = false;*/
//     if (!onAnFaretto)
//     {

//     }
// }

// void AccendiFaretto(bool trigger)
// {
//     if (trigger)
//     {
//         worldLight.type = thisLight.type;
//         worldLightTransform.transform.position = thisTransform.transform.position;
//         worldLightTransform.position += Vector3.up;

//     }
//}

// void SpegniFaretto()
// {
//     worldLight.type = LightType.Directional;
//     worldLightTransform.position = new Vector3(0.12f, 20.77f, 3.49f);
// }
#endregion
#region LightFollowPalyer
/* public Light test;
public Transform playerTransform;
// Use this for initialization
void Start () {
  test = GetComponent<Light>();
}

  //values that will be set in the Inspector
public Transform Target;
public float RotationSpeed;




//values for internal use
private Quaternion _lookRotation;
private Vector3 _direction;
void roba()
{


GetComponent<Light>().intensity = 1;
      //find the vector pointing from our position to the target
      _direction = (Target.position - transform.position).normalized;

      //create the rotation we need to be in to look at the target
      _lookRotation = Quaternion.LookRotation(_direction);

      //rotate us over time according to speed until we are in the required rotation
      transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

}*/
#endregion

