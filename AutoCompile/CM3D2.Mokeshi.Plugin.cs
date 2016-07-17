using System;
using UnityEngine;
using UnityInjector;
using UnityInjector.Attributes;

namespace CM3D2.Mokeshi
{
	[PluginFilter("CM3D2x64"), PluginFilter("CM3D2x86"), PluginName("Mokeshi"), PluginVersion("0.0.0.0")]
	public class Mokeshi : PluginBase
	{
		public float m_lastupdate = 0.0f;

		public void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(this);
		}

		public void LateUpdate()
		{
			float t = Time.time;
			if (t - m_lastupdate < 1.0f) return;
			m_lastupdate = t;

			foreach (var re in FindObjectsOfType<SkinnedMeshRenderer>())
			{
				if (!re.enabled) continue;
				foreach (var mat in re.materials)
				{
					if (mat.shader.name.Contains("Mosaic"))
					{
						re.enabled = false;
						break;
					}
				}
			}
		}
	}
}