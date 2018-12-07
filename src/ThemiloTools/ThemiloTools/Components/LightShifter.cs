﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ThemiloTools.Components
{
    public class LightShifter : MonoBehaviour
    {
        // Variables
        public Color sunlightColor;
        public Single sunlightIntensity;
        public Single sunlightShadowStrength;
        public Color scaledSunlightColor;
        public Single scaledSunlightIntensity;
        public Color IVASunColor;
        public Single IVASunIntensity;
        public Color ambientLightColor;
        public Color sunLensFlareColor;
        public Boolean givesOffLight;
        public Double AU;
        public FloatCurve brightnessCurve;
        public FloatCurve intensityCurve;
        public FloatCurve scaledIntensityCurve;
        public FloatCurve ivaIntensityCurve;
        public Double solarInsolation;
        public Double solarLuminosity;
        public Double radiationFactor;
        public Flare sunFlare;

        // Prefab that makes every star yellow by default
        public static LightShifter prefab
        {
            get
            {
                // If the prefab is null, create it
                GameObject prefabGOB = new GameObject("LightShifter");
                LightShifter prefab = prefabGOB.AddComponent<LightShifter>();

                // Fill it with default values
                prefab.sunlightColor = Color.white;
                prefab.sunlightIntensity = 0.9f;
                prefab.sunlightShadowStrength = 0.7523364f;
                prefab.scaledSunlightColor = Color.white;
                prefab.scaledSunlightIntensity = 0.9f;
                prefab.IVASunColor = new Color(1.0f, 0.977f, 0.896f, 1.0f);
                prefab.IVASunIntensity = 0.8099999f;
                prefab.sunLensFlareColor = Color.white;
                prefab.ambientLightColor = new Color(0.06f, 0.06f, 0.06f, 1.0f);
                prefab.AU = 13599840256;
                prefab.brightnessCurve = new FloatCurve(new Keyframe[]
                {
                        new Keyframe(-0.01573471f, 0.217353f, 1.706627f, 1.706627f),
                        new Keyframe(5.084181f, 3.997075f, -0.001802375f, -0.001802375f),
                        new Keyframe(38.56295f, 1.82142f, 0.0001713f, 0.0001713f)
                });
                prefab.givesOffLight = true;
                prefab.solarInsolation = PhysicsGlobals.SolarInsolationAtHome;
                prefab.solarLuminosity = PhysicsGlobals.SolarLuminosityAtHome;
                prefab.radiationFactor = PhysicsGlobals.RadiationFactor;
                prefab.sunFlare = null;
                prefab.intensityCurve = new FloatCurve(new Keyframe[]
                {
                        new Keyframe(0, prefab.sunlightIntensity),
                        new Keyframe(1, prefab.sunlightIntensity)
                });
                prefab.scaledIntensityCurve = new FloatCurve(new Keyframe[]
                {
                        new Keyframe(0, prefab.scaledSunlightIntensity),
                        new Keyframe(1, prefab.scaledSunlightIntensity)
                });
                prefab.ivaIntensityCurve = new FloatCurve(new Keyframe[]
                {
                        new Keyframe(0, prefab.IVASunIntensity),
                        new Keyframe(1, prefab.IVASunIntensity)
                });

                // Return the prefab
                return prefab;
            }
        }

        /// <summary>
        /// Applies the ambient color.
        /// </summary>
        public void ApplyAmbient()
        {
            DynamicAmbientLight ambientLight = FindObjectOfType(typeof(DynamicAmbientLight)) as DynamicAmbientLight;
            if (ambientLight)
                ambientLight.vacuumAmbientColor = ambientLightColor;
        }
    }
}
