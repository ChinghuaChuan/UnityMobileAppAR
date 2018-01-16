using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstructionModel{
	private List<InstructionStep> steps = new List<InstructionStep>();

	public void LoadData() {
		steps.Clear ();
		TextAsset text_asset = (TextAsset)Resources.Load ("instructionsCSV");
		fgCSVReader.LoadFromString (text_asset.text, new fgCSVReader.ReadLineDelegate(csvReader));

		/*
		steps.Add (new InstructionStep(new List<string>{"0", "1st Step", "Details in the 1st Step."}));
		steps.Add (new InstructionStep(new List<string>{"1", "2nd Step", "Details in the 2nd Step."}));
		steps.Add (new InstructionStep(new List<string>{"2", "3rd Step", "Details in the 3rd Step."}));
		*/
	}

	// public getter method: to get a specific step
	public InstructionStep GetInstructionStep(int index) {
		if (index < 0 || index >= steps.Count)
			return null;
		return steps [index];
	}

	public int GetCount() {
		return steps.Count;
	}

	// helper method required by fgCSVReader
	private void csvReader(int line_index, List<string> line) {
		if (line_index == 0) 
			return;
		steps.Add (new InstructionStep (line));
	}
}
