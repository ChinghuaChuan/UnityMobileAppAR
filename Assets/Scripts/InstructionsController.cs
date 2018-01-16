using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsController : MonoBehaviour {

	public Text stepText;
	public Text titleText;
	public Text bodyText;

	private int currentStep;
	private InstructionModel currentInstructionModel = new InstructionModel ();

	// Use this for initialization
	void Awake () {
		currentInstructionModel.LoadData ();
	}

	void Start () {
		currentStep = 0;
		CurrentInstructionUpdate ();
	}

	public void NextStep() {
		if (currentStep < currentInstructionModel.GetCount()-1) {
			currentStep++;
			CurrentInstructionUpdate ();
		}
	}

	public void PreviousStep() {
		if (currentStep > 0) {
			currentStep--;
			CurrentInstructionUpdate ();
		}
	}

	private void CurrentInstructionUpdate() {
		InstructionStep step = currentInstructionModel.GetInstructionStep (currentStep);
		stepText.text = "Step: " + currentStep;	
		titleText.text = step.Title;
		bodyText.text = step.BodyText;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
