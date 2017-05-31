using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bracelet {

	private int mBraceletID;

	public Bracelet(int pBraceletID) {

		mBraceletID = pBraceletID;
	}

	public string getDescription(){
		return BraceletDataStorage.getBraceletDescription (mBraceletID);
	}
}
