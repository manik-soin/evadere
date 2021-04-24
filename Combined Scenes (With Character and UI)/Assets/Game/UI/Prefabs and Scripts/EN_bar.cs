using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EN_bar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxEN(int en)
	{
		slider.maxValue = en;
		slider.value = 0;

		fill.color = gradient.Evaluate(0);
		
	}

	public void SetEN(int en)
	{
		slider.value = en;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
