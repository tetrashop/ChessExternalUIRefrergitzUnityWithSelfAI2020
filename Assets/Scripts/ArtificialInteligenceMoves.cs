using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;

public class ArtificialInteligenceMove
{
	int Order=1;
	public int x,y,x1,y1;
	public RefrigtzChessPortable.RefrigtzChessPortableForm t=null;
	System.Threading.Thread ttt = null; 
	bool Idle = false;
	public  ArtificialInteligenceMove(){
		object O=new object();
		lock(O){	var tt = new System.Threading.Thread (new System.Threading.ThreadStart (Awake));
		tt.Start ();
		ttt = new System.Threading.Thread (new System.Threading.ThreadStart (ThinkingIdle));
		ttt.Start ();
			}
	}

	void Awake()
	{
		object O = new object ();
		lock (O) {
			if (t == null) {
					
	

				
				t = new RefrigtzChessPortable.RefrigtzChessPortableForm ();
				t.Form1_Load ();
				


			}
		}
	}
	public void ThinkingIdle()
	{
		object O=new object();
		lock(O){
			Debug.Log("Idle method Begin");

			do {
					if(t!=null){
					if(t.LoadP||Idle){
						if(RefrigtzChessPortable.AllDraw.CalIdle==0&&RefrigtzChessPortable.AllDraw.IdleInWork)
					{
							
								bool Blit=RefrigtzChessPortable.AllDraw.Blitz;
							RefrigtzChessPortable.AllDraw.Blitz=false;
										Debug.Log("Idle Begin");
															Idle=true;
						RefrigtzChessPortable.AllDraw.TimeInitiation = (DateTime.Now.Hour * 60 * 60 * 1000) + (DateTime.Now.Minute * 60 * 1000) + (DateTime.Now.Second * 1000);
							RefrigtzChessPortable.AllDraw.MaxAStarGreedy=PlatformHelper.ProcessorCount;
							var arrayA =Task.Factory.StartNew(() =>	t.Draw.Initiate(1, 4, t.Draw.OrderP, CloneATable(t.brd.GetTable()), t.Draw.OrderP, false, false, 0));
							arrayA.Wait();
							bool LoadTree=false;
							(new RefrigtzChessPortable.TakeRoot()).Save(false, false, t, ref LoadTree, false, false, false, false, false, false, false, true);
							RefrigtzChessPortable.AllDraw.Blitz=Blit;
//							System.Threading.Thread.Sleep(5000);
							}
					
						else{
				if(RefrigtzChessPortable.AllDraw.CalIdle==5)
						{		RefrigtzChessPortable.AllDraw.CalIdle=1;
								Debug.Log("Idle Finished");

							Debug.Log("Ready to 1 base");

						}
						do	{System.Threading.Thread.Sleep(10);}while(RefrigtzChessPortable.AllDraw.CalIdle==1);
					}
				
					}
				}
				} while(RefrigtzChessPortable.AllDraw.CalIdle!=3);
		
		}
	}
	int[,] CloneATable(int[,] Tab)
	{
		object O = new object();
		lock (O)
		{          
			int[,] Tabl = new int[8, 8];
			for (var i = 0; i < 8; i++)
				for (var j = 0; j < 8; j++)
					Tabl[i, j] = Tab[i, j];

			return Tabl;
		}
	}
	public bool MoveSelector(int i,int j,int i1,int j1)
	{
		object O=new object();
		lock (O) {
			if (Order == 1) {
				t.Play (i, j);
				t.Play (i1, j1);
				Order = -1;




			} else if (Order == -1) {
				t.Play (-1, -1);
				x = t.R.CromosomRowFirst;
				y = t.R.CromosomColumnFirst;
				x1 = t.R.CromosomRow;
				y1 = t.R.CromosomColumn;

				Order = -1;
			}
		}
		return true;
	}
}


