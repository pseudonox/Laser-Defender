using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public TextMeshProUGUI scoreText;

    void Start()
    {
        if(SceneManager.GetActiveScene().name=="Game Over Screen")
        {
            scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
        }
    }
    public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
    
}
