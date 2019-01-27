using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonScript<GameManager>
{
	public Transform spawnPoint;

	public GameObject premeetingGroup, postMeetingGroup;

	public MeshRenderer uiTalisman;
	public Image fadeoutImage;

	public AudioSource cubeMusic, sphereMusic;


    public CanvasGroup  meetingText;

	public float maxMusicVol = 0.3f;

	public void Mix(float sphereness = 1.0f){
		cubeMusic.volume = (1 - sphereness) * maxMusicVol;
		sphereMusic.volume = (sphereness) * maxMusicVol;
	}

	public void Start(){
		
		uiTalisman.gameObject.SetActive(false);
		// uiTalisman.material.color = new Color(1f, 1f, 1f, 0f);
	}

	public void RespawnPlayer(PlayerController pc){
		// Material talisman = uiTalisman.material;
		AddAnimation(1.0f, (a) => {
			fadeoutImage.color = new Color(0, 0, 0, a);
			uiTalisman.gameObject.SetActive(true);
		});
		AddAnimation(1.0f, (a) => {
			fadeoutImage.color = new Color(0, 0, 0, 1-a);

			// talisman.color = new Color(1, 1, 1, a);
		}, 1.5f);

		AddDelayed(1.25f, () => pc.RespawnPlayer() );
		AddDelayed(2.25f, () => uiTalisman.gameObject.SetActive(false) );

	}

	public void TriggerMeeting(){
		AddAnimation(1.0f, (a) => {
			fadeoutImage.color = new Color(0, 0, 0, a);
			meetingText.alpha = a;
		});
		
		AddAnimation(1.0f, (a) => {
			fadeoutImage.color = new Color(0, 0, 0, 1-a);
			meetingText.alpha = 1-a;
			// talisman.color = new Color(1, 1, 1, a);
		}, 1.5f);
		
		AddDelayed(1.25f, () => {
			meetingText.gameObject.SetActive(false);
			premeetingGroup.SetActive(false);
			postMeetingGroup.SetActive(true);
		 } );

	}

}
