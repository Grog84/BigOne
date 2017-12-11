#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class MapTool : MonoBehaviour
{

    public void SaveConfig()
    {
        MapToolConfig myConfigFile = GetProfileFromPrefs();

        myConfigFile.sceneSetup = EditorSceneManager.GetSceneManagerSetup();
        EditorUtility.SetDirty(myConfigFile);
    }

    public void LoadConfig()
    {
        MapToolConfig myConfigFile = GetProfileFromPrefs();
        EditorSceneManager.RestoreSceneManagerSetup(myConfigFile.sceneSetup);
    }

    MapToolConfig GetProfileFromPrefs()
    {
        DeveloperProfileEnum activeProfile = (DeveloperProfileEnum)EditorPrefs.GetInt("MapConfig");

        string profilePath = "None";

        switch (activeProfile)
        {
            case DeveloperProfileEnum.NONE:
                break;
            case DeveloperProfileEnum.GIOVANNA:
                profilePath = "Profiles/Giovanna";
                break;
            case DeveloperProfileEnum.LORENZO:
                profilePath = "Profiles/Lorenzo";
                break;
            case DeveloperProfileEnum.STEFANO:
                profilePath = "Profiles/Stefano";
                break;
            case DeveloperProfileEnum.MANFREDO:
                profilePath = "Profiles/Manfredo";
                break;
            case DeveloperProfileEnum.MAXIILIANO:
                profilePath = "Profiles/Maximiliano";
                break;
            case DeveloperProfileEnum.FACUNDO:
                profilePath = "Profiles/Facundo";
                break;
            case DeveloperProfileEnum.GIOIA:
                profilePath = "Profiles/Gioia";
                break;
            case DeveloperProfileEnum.FABIO_D:
                profilePath = "Profiles/Fabio_D";
                break;
            case DeveloperProfileEnum.FABIO_R:
                profilePath = "Profiles/Fabio_R";
                break;
            case DeveloperProfileEnum.GIUSEPPE:
                profilePath = "Profiles/Giuseppe";
                break;
            case DeveloperProfileEnum.DARIO:
                profilePath = "Profiles/Dario";
                break;
            case DeveloperProfileEnum.FABIO_B:
                profilePath = "Profiles/Fabio_B";
                break;
            case DeveloperProfileEnum.ANDREA_V:
                profilePath = "Profiles/Andrea_V";
                break;
            case DeveloperProfileEnum.ALESSANDRO:
                profilePath = "Profiles/Alessandro";
                break;
            case DeveloperProfileEnum.ANDREA_T:
                profilePath = "Profiles/Andrea_T";
                break;
            case DeveloperProfileEnum.MASTER:
                profilePath = "Profiles/Master";
                break;
            default:
                break;
        }
        DeveloperProfile myProfile = (DeveloperProfile)Resources.Load(profilePath);
        MapToolConfig myConfigFile = myProfile.mapConfig;
        return myConfigFile;
    }

}
#endif
