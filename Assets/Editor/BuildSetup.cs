using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public static class BuildSetup
{
    [InitializeOnLoadMethod]
    static void Setup()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode) return;

        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

        var world = new GameObject("WorldBootstrap");
        world.AddComponent<WorldBootstrap>();

        var camera = new GameObject("Main Camera");
        camera.tag = "MainCamera";
        camera.AddComponent<Camera>();
        camera.transform.position = new Vector3(0, 35, -45);
        camera.transform.rotation = Quaternion.Euler(35, 0, 0);

        var light = new GameObject("Directional Light");
        var dl = light.AddComponent<Light>();
        dl.type = LightType.Directional;
        dl.intensity = 1.2f;

        EditorSceneManager.SaveScene(scene, "Assets/Scenes/MainCity.unity");
        Debug.Log("OpenWorld3D: MainCity scene generated.");
    }
}
