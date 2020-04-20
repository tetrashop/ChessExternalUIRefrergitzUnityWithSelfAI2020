using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialInteligenceMove
{
	int Order=1;
	public int x,y,x1,y1;
	public RefrigtzChessPortable.RefrigtzChessPortableForm t=null;
	public  ArtificialInteligenceMove(){
		if(t==null){

			t = new RefrigtzChessPortable.RefrigtzChessPortableForm();
			t.Form1_Load ();

		}}
//	void Awake(){
//		if(t==null){
//
//			t = new RefrigtzChessPortable.RefrigtzChessPortableForm();
//			t.Form1_Load ();
//
//		}
//	}
	public bool MoveSelector(int i,int j,int i1,int j1)
	{
		if(Order==1)
		{
			t.Play(i,j);
			t.Play(i1,j1);
			Order=-1;




		}else
			if(Order==-1)
			{
				t.Play(-1,-1);
				x=t.R.CromosomRowFirst;
				y=t.R.CromosomColumnFirst;
				x1=t.R.CromosomRow;
				y1=t.R.CromosomColumn;


			}
		return true;
	}
}


