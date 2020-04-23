using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialInteligenceMove
{
	int Order=1;
	public int x,y,x1,y1;
	public RefrigtzChessPortable.RefrigtzChessPortableForm t=null;
	System.Threading.Thread ttt = null; 
	bool Idle = false;
	public  ArtificialInteligenceMove(){
		var tt = new System.Threading.Thread (new System.Threading.ThreadStart (Awake));
		tt.Start ();
		ttt = new System.Threading.Thread (new System.Threading.ThreadStart (ThinkingIdle));
		ttt.Start ();
			}
		

	void Awake()
	{
		if (t == null) {
					
	

				
			t = new RefrigtzChessPortable.RefrigtzChessPortableForm ();
			t.Form1_Load ();
				


		}
	}
	public void ThinkingIdle()
	{
		object O=new object();
		lock(O){
			Debug.Log("Idle ethod Begin");

		do {
				if(t!=null){
					if(t.LoadP||Idle){
						if(RefrigtzChessPortable.AllDraw.CalIdle==0&&RefrigtzChessPortable.AllDraw.IdleInWork)
					{
						Debug.Log("Idle Begin");
								RefrigtzChessPortable.AllDraw.IdleInWork=true;
							Idle=true;
									
				t.Play(-1,-1);
							
					}
			else
				if(RefrigtzChessPortable.AllDraw.CalIdle==5)
						{		RefrigtzChessPortable.AllDraw.CalIdle=1;
							Debug.Log("Ready to 1 yyyyyyybase");

						}
					do	{System.Threading.Thread.Sleep(10);}while(RefrigtzChessPortable.AllDraw.CalIdle==1);
					}
				}
						

				} while(RefrigtzChessPortable.AllDraw.CalIdle!=3);
		}

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

			Order = -1;
			}
		return true;
	}
}


