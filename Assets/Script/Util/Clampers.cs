using System;
using System.Collections;
using System.Linq;
using UnityEngine;


public static class Clampers : object {
	public static int ClampInt(int val, int min, int max){
		float clamped = Mathf.Clamp((float)val, (float)min, (float)max);

		return (int)clamped;
	}

		public static double ClampDouble(double val, double min, double max) {
		float clamped = Mathf.Clamp((float)val, (float)min, (float)max);

		return (double)clamped;
	}
}