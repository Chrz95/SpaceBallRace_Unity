using UnityEngine;

public class TimeManager : MonoBehaviour {

	public float SlowDownFactor = 0f ; 
	public float SlowDownLength = 10f ;

	void Update ()
	{
		if (!PauseMenu.GameIsPaused)
		{			
			Time.timeScale += (1 / (8*SlowDownLength) * Time.unscaledDeltaTime);
			Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
		}
	}
	public void SlowMotion()
	{
		Time.timeScale = SlowDownFactor ;
		Time.fixedDeltaTime = Time.timeScale * 0.02f ; 
	}
}
