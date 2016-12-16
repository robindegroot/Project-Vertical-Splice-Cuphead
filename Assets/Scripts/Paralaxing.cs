using UnityEngine;
using System.Collections;

public class Paralaxing : MonoBehaviour {

    public Transform[] Backgrounds;
    private float[] ParallaxScales;

    public float Smoothing = 1f;

    private Transform camera;
    private Vector2 PreviousCameraPosition;

    void Awake()
    {
        camera = Camera.main.transform;
    }
    void Start ()
    {
        PreviousCameraPosition = camera.position;

        ParallaxScales = new float[Backgrounds.Length];

        for(int i = 0; i < Backgrounds.Length; i++)
        {
            ParallaxScales[i] = Backgrounds[i].position.z * -1;
        }
	}
	

	void Update ()
    {
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            float paralax = (PreviousCameraPosition.x - camera.position.x) * ParallaxScales[i];
            float backgroundTargetPosX = Backgrounds[i].position.x + paralax;
            Vector2 backgroundTargetPos = new Vector2(backgroundTargetPosX, Backgrounds[i].position.y);

            Backgrounds[i].position = Vector2.Lerp(Backgrounds[i].position, backgroundTargetPos, Smoothing * Time.deltaTime);
        }
        PreviousCameraPosition = camera.position;
	}
}
