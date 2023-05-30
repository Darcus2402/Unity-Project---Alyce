using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PostProcessingScript : MonoBehaviour
{
    private Volume volume;
    private VolumeProfile volumeProfile;
    private Bloom bloomExample;
    private ShadowsMidtonesHighlights Ombre;


    public float bloomIntensity;

    [SerializeField] private GameObject VolumeObject;
    // Start is called before the first frame update


    void Start() {
		volume = GetComponent<Volume>();

		volumeProfile = volume.sharedProfile;
        volume.profile.TryGet<Bloom>(out bloomExample);




    }

    [ContextMenu("test")]
    private void Test() {
        bloomExample.intensity.value = bloomIntensity;
    }
}
