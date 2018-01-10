using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.CameraUI;

namespace RPG.Characters {
	public class Energy : MonoBehaviour {

		[SerializeField] RawImage energyBar = null;
		[SerializeField] float maxEnergy = 100f;
		[SerializeField] float pointsPerHit = 10f;

		float currentEnergy;
		CameraRaycaster cameraRaycaster;

		void Start () {
			currentEnergy = maxEnergy;
			cameraRaycaster = Camera.main.GetComponent<CameraRaycaster> ();
			cameraRaycaster.onMouseOverEnemy += OnMouseOverEnemy;
		}

		void OnMouseOverEnemy (Enemy enemy) {
			if (Input.GetMouseButtonDown (1)) {
				float newEnergy = currentEnergy - pointsPerHit;
				currentEnergy = Mathf.Clamp (newEnergy, 0, maxEnergy);
				UpdateEnergyBar ();
			}
		}

		void UpdateEnergyBar ()
		{
			float xValue = -(EnergyAsPercent() / 2f) - 0.5f;
			energyBar.uvRect = new Rect (xValue, 0f, 0.5f, 1f);
		}

		float EnergyAsPercent() {
			return currentEnergy / maxEnergy;
		}
	}
}