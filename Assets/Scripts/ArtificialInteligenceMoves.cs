using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;
using RefrigtzChessPortable;

public class ArtificialInteligenceMove
{	public static bool UpdateIsRunning=false; 
	public static ArtificialInteligenceMove tta;
	int LevelMul=1;
	int Order=1;
	public int x,y,x1,y1;
	public RefrigtzChessPortable.RefrigtzChessPortableForm t=null;
	public static System.Threading.Thread ttt = null; 
	bool Idle = false;
	public static bool IdleProgress=true;
	public  ArtificialInteligenceMove(){
		object O=new object();
		lock(O){	var tt = new System.Threading.Thread (new System.Threading.ThreadStart (Awake));
		tt.Start ();
//			tt.Join ();
		ttt = new System.Threading.Thread (new System.Threading.ThreadStart (ThinkingIdle));
		ttt.Start ();

//			ttt.Join ();
			}
	}

	void Awake()
	{
		object O = new object ();
		lock (O) {
			if (ArtificialInteligenceMove.Ret () != null) {
				if (ArtificialInteligenceMove.Ret ().t == null) {
								
	


					ArtificialInteligenceMove.Ret ().t = new RefrigtzChessPortable.RefrigtzChessPortableForm ();
					ArtificialInteligenceMove.Ret ().t.Form1_Load ();


					RefrigtzChessPortable.AllDraw.UniqueLeafDetection = true;
				}
			} else {
					ArtificialInteligenceMove.tta = new ArtificialInteligenceMove ();
					if (ArtificialInteligenceMove.Ret ().t == null) {




						ArtificialInteligenceMove.Ret ().t = new RefrigtzChessPortable.RefrigtzChessPortableForm ();
						ArtificialInteligenceMove.Ret ().t.Form1_Load ();


						RefrigtzChessPortable.AllDraw.UniqueLeafDetection = true;

					}
				}
			}
		}
	public static ArtificialInteligenceMove Ret()
	{
		return tta;
	}
	public void ThinkingIdle()
	{
		object O=new object();
		lock(O){
			Debug.Log("Idle method Begin");
			bool ReadyZero = true;
			do {
				if(ArtificialInteligenceMove.Ret().t!=null)
				{
					if(ArtificialInteligenceMove.Ret().t.LoadP||Idle){
						if(RefrigtzChessPortable.AllDraw.CalIdle==0&&ReadyZero)
						{
							Debug.Log("Ready to 0 base.AI");

							ReadyZero=false;

						}
						if(RefrigtzChessPortable.AllDraw.CalIdle==0&&(!ArtificialInteligenceMove.UpdateIsRunning)
						)
										{

								bool Blit=RefrigtzChessPortable.AllDraw.Blitz;
							RefrigtzChessPortable.AllDraw.Blitz=false;
										Debug.Log("Idle Begin");
															Idle=true;
						RefrigtzChessPortable.AllDraw.TimeInitiation = GameManager.a;
							RefrigtzChessPortable.AllDraw.MaxAStarGreedy=RefrigtzChessPortable.AllDraw.PlatformHelperProcessorCount*LevelMul;
							var arrayA =Task.Factory.StartNew(() =>	t.Draw.InitiateAStarGreedyt(RefrigtzChessPortable.AllDraw.MaxAStarGreedy,1, 4, t.Draw.OrderP, CloneATable(t.brd.GetTable()), t.Draw.OrderP, false, false, 0));
							//var arrayA =Task.Factory.StartNew(() =>	t.Play(-1,-1));
                            arrayA.Wait();
							object i=new object();

							lock(i)
							{
								bool LoadTree=false;
								(new RefrigtzChessPortable.TakeRoot()).Save(false, false, ArtificialInteligenceMove.Ret().t, ref LoadTree, false, false, false, false, false, false, false, true);
							}
							RefrigtzChessPortable.AllDraw.Blitz=Blit;
//							System.Threading.Thread.Sleep(50);
							//LevelMul++;
							Debug.Log("Idle Finished");
							IdleProgress=false;
							ArtificialInteligenceMove.UpdateIsRunning=true;

							RefrigtzChessPortable.AllDraw.CalIdle=1;
						}
						if(RefrigtzChessPortable.AllDraw.CalIdle==2)
						{
							Debug.Log("Ready to 5 base");

							RefrigtzChessPortable.AllDraw.CalIdle=5;
						}
//						if(RefrigtzChessPortable.AllDraw.CalIdle==2)
//						{
//							Debug.Log("Ready to 5 base");
//
//							RefrigtzChessPortable.AllDraw.CalIdle=5;
//						}
//						Debug.Log("Ready to 0 base");

						if(RefrigtzChessPortable.AllDraw.CalIdle==5)
						{		RefrigtzChessPortable.AllDraw.CalIdle=1;
//						        RefrigtzChessPortable.AllDraw.IdleInWork=false;

							Debug.Log("Ready to 1 base");
							ReadyZero=true;
						}
						while(RefrigtzChessPortable.AllDraw.CalIdle==1)
						{	

							System.Threading.Thread.Sleep(1);
						}
						while(ArtificialInteligenceMove.UpdateIsRunning)
						{	
							System.Threading.Thread.Sleep(1);
						}

						RefrigtzChessPortable.AllDraw.IdleInWork=true;
						RefrigtzChessPortable.AllDraw.CalIdle=0;
						IdleProgress=true;
//				
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
				object OO = new object ();
				lock (OO) {
					t.Play (i, j);
					t.Play (i1, j1);
					Order = -1;
				}




			} else if (Order == -1) {
				object OO = new object ();
				lock (OO) {
					t.Play (-1, -1);
					x = t.R.CromosomRowFirst;
					y = t.R.CromosomColumnFirst;
					x1 = t.R.CromosomRow;
					y1 = t.R.CromosomColumn;

					Order = -1;
				}
			}
		}
		return true;
	}
}


