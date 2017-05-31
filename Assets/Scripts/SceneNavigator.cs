using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneNavigator {
 
    private static Dictionary<string, int> parameters;
 
    public static void Load(string sceneName, Dictionary<string, int> parameters = null) {
		SceneNavigator.parameters = parameters;
        SceneManager.LoadScene(sceneName);
    }
 
    public static void Load(string sceneName, string paramKey, int paramValue) {
		SceneNavigator.parameters = new Dictionary<string, int>();
		SceneNavigator.parameters.Add(paramKey, paramValue);
        SceneManager.LoadScene(sceneName);
    }
 
    public static Dictionary<string, int> getSceneParameters() {
        return parameters;
    }
 
    public static int getParam(string paramKey) {
        if (parameters == null) return 0;
        return parameters[paramKey];
    }
 
    public static void setParam(string paramKey, int paramValue) {
        if (parameters == null)
			SceneNavigator.parameters = new Dictionary<string, int>();
		SceneNavigator.parameters.Add(paramKey, paramValue);
    }
 
}