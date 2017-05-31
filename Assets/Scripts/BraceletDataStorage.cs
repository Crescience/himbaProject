using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BraceletDataStorage {

	private static string[] mDescriptions = {
		// Description for bracelet #1
		"A traditional black powder is to colour the paces of the bracelet. This colour is usually found on clothes wearied by small kids until the age of 12 years old. Many more colours can be used on the bracelet relatively to their living fact or environment.",
		// Description for bracelet #2
		"The bracelets are made from recycled PVC but horn of a cow is the preferable material for the Himba. They cut it into a cylinder form and which they then remove and clean the inside part of it.",
		// Description for bracelet #3
		"The creativity of bracelet pattern is significantly based on personal approach toward art and the vision on cows’ horns. And beautifying traditional Himba and Herero tribal art and jewellery. The bracelet honours the connection between the cattle and the himba people.",
		// Description for bracelet #4
		"The bracelet is a great from the combined cultures of Himba people and their surrounding environment. This bracelet interprets the magnificence namib desert’s waves with embedded flowers. The Namib desert captures the creativity of the himba.",
		// Description for bracelet #5
		"The black thin, up-cycled bracelets are hand-carved from the recycle water pipe, cow horn or the oryx. The black thin ribbons represent threes used to create himba’s houses",
		// Description for bracelet #6
		"The bracelet is aptly named Himba Red, a nod to the rich red ochre clay worn by the women of the Himba tribe. The design is captured from the traditional style of Himba women",
		// Description for bracelet #7
		"777777777"
	};

	public static string getBraceletDescription(int braceletID) {
		
		if (braceletID > 0 && braceletID <= mDescriptions.Length) {
			return mDescriptions [braceletID - 1];
		}
		return "";
	}
}
