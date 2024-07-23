using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AzarPostProcesado : MonoBehaviour
{
    public PostProcessProfile postProcessProfile;

    private void Start()
    {
        ModifyPostProcessingEffects();
    }

    private void ModifyPostProcessingEffects()
    {
        if (postProcessProfile != null)
        {
            // Ambient Occlusion
            AmbientOcclusion ambientOcclusion;
            if (postProcessProfile.TryGetSettings(out ambientOcclusion))
            {

                ambientOcclusion.intensity.value = Random.Range(0f, 1.5f);
                ambientOcclusion.thicknessModifier.value = Random.Range(1f, 10f);
                ambientOcclusion.color.value = Random.ColorHSV(0f, 1, 0.3f, 1f, 0f, 0.7f);
            }

            // Chromatic Aberration
            ChromaticAberration chromaticAberration;
            if (postProcessProfile.TryGetSettings(out chromaticAberration))
            {

                chromaticAberration.intensity.value = Random.Range(0f, 1f);
            }

            // Bloom
            Bloom bloom;
            if (postProcessProfile.TryGetSettings(out bloom))
            {

                bloom.intensity.value = Random.Range(0.5f, 10f);
                bloom.threshold.value = Random.Range(0f, 1f);
                bloom.softKnee.value = Random.Range(0f, 1f);
                bloom.diffusion.value = Random.Range(1f, 10f);
                bloom.anamorphicRatio.value = Random.Range(-1f, 1f);
                bloom.color.value = Random.ColorHSV(0f, 1, 0.3f, 1f, 0f, 0.7f);
            }

            // Color Grading
            ColorGrading colorGrading;
            if (postProcessProfile.TryGetSettings(out colorGrading))
            {

                colorGrading.temperature.value = Random.Range(-15f, 15f);
                colorGrading.tint.value = Random.Range(-15f, 15f);
                colorGrading.hueShift.value = Random.Range(-180f, 180f);
                colorGrading.saturation.value = Random.Range(-30f, 100f);
                colorGrading.contrast.value = Random.Range(-50f, 100f);
            }
        }
    }
}