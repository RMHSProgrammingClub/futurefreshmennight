using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
 
public class SceneFader : MonoBehaviour {
 
    public Image fadeOutUIImage;
    public float fadeSpeed = 0.8f; 

	private const float SCENE_TIMEOUT = 20f;
 
    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }

	void OnEnable() {
		StartCoroutine(Fade(FadeDirection.Out));
		string sceneName = "_SCENE";
		string currentScene = SceneManager.GetActiveScene().name;
		/* 
		 * _SCENE 0
		 * RollingBall 1 
		 */

		switch (currentScene)
		{
			case "_SCENE":
				sceneName = "RollingBall";
				break;
			case "RollingBall":
				sceneName = "_SCENE2";
				break;
			default:
				sceneName = "_SCENE";
				break;
		}
		StartCoroutine(WaitAndFade(SCENE_TIMEOUT, sceneName));
	}

	private IEnumerator WaitAndFade(float time, string scene) {
		yield return new WaitForSeconds(time);
		yield return FadeAndLoadScene(FadeDirection.In, scene);
	}

    private IEnumerator Fade(FadeDirection fadeDirection) 
    {
        float alpha = (fadeDirection == FadeDirection.Out)? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out)? 0 : 1;
        if (fadeDirection == FadeDirection.Out) {
            while (alpha >= fadeEndValue)
            {
                SetColorImage (ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false; 
        } else {
            fadeOutUIImage.enabled = true; 
            while (alpha <= fadeEndValue)
            {
                SetColorImage (ref alpha, fadeDirection);
                yield return null;
            }
        }
    }

    public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection, string sceneToLoad) 
    {
        yield return Fade(fadeDirection);
        SceneManager.LoadScene(sceneToLoad);
    }
 
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color (fadeOutUIImage.color.r,fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out)? -1 : 1) ;
    }
}