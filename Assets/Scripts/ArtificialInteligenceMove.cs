using System;
using UnityEngine;

public class ArtificialInteligenceMove : MonoBehaviour
{
	
	float currentSpeed = 0f;
	float targetSpeed = 30f;

	int Order=1;
	public int x,y,x1,y1;
	public RefrigtzChessPortable.RefrigtzChessPortableForm t=null;
	void Update ()
	{
		if (currentSpeed < targetSpeed)
			currentSpeed += Time.deltaTime;
	}
	void Start ()
	{
		t = new RefrigtzChessPortable.RefrigtzChessPortableForm();
		t.Form1_Load ();
	}
		public ArtificialInteligenceMove ()
		{
		
		}
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


