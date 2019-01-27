using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoDisplayer : SingletonScript<LogoDisplayer>
{
    private Image logo;
    public Image fadeOut;
    public AudioClip logoDing;
    public CanvasGroup instructionsGroup;

    // Start is called before the first frame update
    void Start()
    {
        logo = GetComponent<Image>();

        logo.color = new Color(1f, 1f, 1f, 0f);
        fadeOut.color = new Color(0, 0, 0, 1);

		AddAnimation(1.0f, (a) => {
			fadeOut.color = new Color(0, 0, 0, 1-a);
		}, 1.5f);
		AddAnimation(0.1f, (a) => {
			logo.color = new Color(1, 1, 1, a);
		});
		AddAnimation(1.0f, (a) => {
			logo.color = new Color(1, 1, 1, 1 - a);
		}, 1.5f);

		AddAnimation(0.3f, (a) => {
			instructionsGroup.alpha = a;
		}, 2.5f);
		AddAnimation(1.0f, (a) => {
			instructionsGroup.alpha = 1-a;
		}, 4.5f);

        

		AddDelayed(0.25f, () => AudioSource.PlayClipAtPoint(logoDing, Camera.main.transform.position) );

    }
}
