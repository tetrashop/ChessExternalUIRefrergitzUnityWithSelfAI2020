/*
 * Copyright (c) 2018 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;


[SerializeField]


public class MoveSelector : MonoBehaviour
{	

	public GameObject deprecatedTarget;
	public GameObject[] target;

	public GameObject moveLocationPrefab;
	 public GameObject tileHighlightPrefab;
    public GameObject attackLocationPrefab;

    private GameObject tileHighlight;
    private GameObject movingPiece;
    private List<Vector2Int> moveLocations;
    private List<GameObject> locationHighlights;
	int Order=1;
	public int x,y,x1,y1;


//	static int OrderAI=1;
	int xB,yB,OrB=-2;
	ArtificialInteligenceMove t;
//	bool TU=false;
	System.Threading.Tasks.Task ff = null;
	System.Threading.Tasks.Task f = null;

	bool xc = false;
	bool xx = false;
	private GameObject	selectobject;
	public static MoveSelector Instance;
//	System.Threading.Tasks.Task Output = null;
	void Start ()
	{
		this.enabled = false;
		tileHighlight = Instantiate (tileHighlightPrefab, Geometry.PointFromGrid (new Vector2Int (0, 0)),
			Quaternion.identity, gameObject.transform);
		tileHighlight.SetActive (false);
	
		Awake();
		}

	bool GameCanged()
	{
		if (OrB ==0)
			return false;		
		return true;

	}
	public bool MoveAI(int i,int j,int i1,int j1)
	{
		if(Order==1)
		{
			t.t.Play(i,7-j);
			t.t.Play(i1,7-j1);
			Order = -1;
		}else
			if(Order==-1)
			{
				t.t.Play(-1,-1);
				x=t.t.R.CromosomRowFirst;
				y=t.t.R.CromosomColumnFirst;
				x1=t.t.R.CromosomRow;
				y1=t.t.R.CromosomColumn;
			Order = 1;
  
			}
		return true;
	}
	bool Exist(List<Vector2Int> ite,Vector2Int t)
	{
		bool Is = false;
		for (int i = 0; i < ite.Count; i++) {
			if (ite[i].x == t.x && ite[i].y == t.y)
				return true;
		}
		return Is; 
	}

    void Update ()
	{
			
//		object OBO=new object();
//		lock(OBO){
//			if(RefrigtzChessPortable.AllDraw.CalIdle==0){
//				//signal to stop idle
//				RefrigtzChessPortable.AllDraw.CalIdle=2;
//				Debug.LogError ("0 base");
//				return;
//				//white to exit
//			}
//		}
		RefrigtzChessPortable.AllDraw.IdleInWork=false;

		object OAO=new object();
		lock(OAO){
			{	if(RefrigtzChessPortable.AllDraw.CalIdle==3)
				{
					//signal to stop idle
					RefrigtzChessPortable.AllDraw.CalIdle=2;
					Debug.LogError ("3 base");
					tileHighlight.SetActive(false);

					return;
					//white to exit
				}	if(RefrigtzChessPortable.AllDraw.CalIdle==4)
				{
					//signal to stop idle
					RefrigtzChessPortable.AllDraw.CalIdle=2;
					Debug.LogError ("4 base");
					tileHighlight.SetActive(false);

					return;
					//white to exit
				}	if(RefrigtzChessPortable.AllDraw.CalIdle==5)
				{
					//signal to stop idle
					RefrigtzChessPortable.AllDraw.CalIdle=2;
					Debug.LogError ("5 base");
					tileHighlight.SetActive(false);

					return;
					//white to exit
				}}
		}	
		bool aa = false;
		
		aa = t != null;
		aa = aa && t.t != null;
		if (!aa)
			return;
		if (!t.t.LoadP)
			return;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			Vector3 point = hit.point;
			Vector2Int gridPoint =Geometry.GridFromPoint (point);

			tileHighlight.SetActive (true);
			tileHighlight.transform.position = Geometry.PointFromGrid (gridPoint);
			if (Input.GetMouseButtonDown (0)) {
				// Reference Point 2: check for valid move location
				if (!Exist (moveLocations, gridPoint)) {
					return;
				}
				if (GameManager.instance.PieceAtGrid (gridPoint) == null) {
					
					GameManager.instance.Move (movingPiece, gridPoint);

				
				} else {
					GameManager.instance.CapturePieceAt (gridPoint);
					GameManager.instance.Move (movingPiece, gridPoint);
				
				}
				// Reference Point 3: capture enemy piece here later	
			ExitState ();

				var output = Task.Factory.StartNew(() => {
					if(Order==1){
					object OO=new object();
					lock(OO){
						if(RefrigtzChessPortable.AllDraw.IdleInWork&&(RefrigtzChessPortable.AllDraw.CalIdle==0||RefrigtzChessPortable.AllDraw.CalIdle==2||RefrigtzChessPortable.AllDraw.CalIdle==3||RefrigtzChessPortable.AllDraw.CalIdle==4)){
																		//signal to stop idle
							RefrigtzChessPortable.AllDraw.CalIdle=2;
							//white to exit
							do{ System.Threading.Thread.Sleep(10);}while(RefrigtzChessPortable.AllDraw.CalIdle!=1);
										}
					}
						//				xc =	MoveAI (TileSelector.x, TileSelector.y, gridPoint.x, gridPoint.y);
					
					ff =	System.Threading.Tasks.Task.Factory.StartNew (() => xc = MoveAI (TileSelector.x, TileSelector.y, gridPoint.x, gridPoint.y));
					ff.Wait ();
					}
					if(Order==-1){
					if(xc){
					OrB = 1;
						object OOO=new object();
					lock(OOO){
						if(RefrigtzChessPortable.AllDraw.IdleInWork&&(RefrigtzChessPortable.AllDraw.CalIdle==0||RefrigtzChessPortable.AllDraw.CalIdle==2||RefrigtzChessPortable.AllDraw.CalIdle==3||RefrigtzChessPortable.AllDraw.CalIdle==4)){
													//signal to stop idle
							RefrigtzChessPortable.AllDraw.CalIdle=2;
							//white to exit
							do{ System.Threading.Thread.Sleep(10);}while(RefrigtzChessPortable.AllDraw.CalIdle!=1);
										}
					}
				
							//xx = MoveAI (-1, -1, -1, -1);
					f = System.Threading.Tasks.Task.Factory.StartNew (() => xx = MoveAI (-1, -1, -1, -1));
					f.Wait ();
							if(x!=-1&&y!=-1&&x1!=-1&&y1!=-1)
							{
												

						if(xx){
									Debug.Log ("Thinking Finished.");
												Vector2Int gridPointN = Geometry.GridPoint (x, 7 - y);
									Debug.Log ("gridPointN.");

//					TileSelector instance=GetComponent<TileSelector>();

//										TileSelector.instance=GetComponent<TileSelector>();
//										Debug.Log ("TileSelector.instance=GetComponent<TileSelector>().");

									TileSelector.instance.tileHighlight.SetActive (true);
									Debug.Log ("TileSelector.instance.tileHighlight.SetActive (true).");

								TileSelector.instance.tileHighlight.transform.position = Geometry.PointFromGrid (gridPointN);
									Debug.Log ("TileSelector.instance.tileHighlight.transform.position = Geometry.PointFromGrid (gridPointN).");

									selectobject = GameManager.instance.pieces[x,7-y];
					
									Debug.Log ("GameObject\tselectobject = GameManager.instance.PieceAtGrid(gridPointN).");

					TileSelector.instance.EnterState ();
									Debug.Log ("TileSelector.instance.EnterState ().");

		        	if (GameManager.instance.DoesPieceBelongToCurrentPlayer(selectobject))
					{

									Debug.Log ("current player.");

									GameManager.instance.SelectPiece(selectobject);
						// Reference Point 1: add ExitState call here later
//									TileSelector.instance.enabled = false;
//									TileSelector.instance.tileHighlight.SetActive(false);
								TileSelector.instance.ExitState(selectobject);
								}
//									movingPiece=selectobject;
//									EnterState(selectobject);

						    Vector2Int gridPointNN = Geometry.GridPoint (x1, 7 - y1);
								
				
									MoveSelector.Instance.tileHighlight.SetActive (true);
									MoveSelector.Instance.tileHighlight.transform.position = Geometry.PointFromGrid (gridPointNN);
											// Reference Point 1: add ExitState call here later
									Debug.Log ("tile selected.");
									if(MoveSelector.Instance.moveLocations.Count==0)
										Debug.Log ("enter state not valid.");
									
										if (!Exist (MoveSelector.Instance.moveLocations, gridPointNN)) {
										return;
									}
									Debug.Log ("Move Source...");
					if (GameManager.instance.PieceAtGrid (gridPointNN) == null) {

										GameManager.instance.Move (MoveSelector.Instance.movingPiece, gridPointNN);

								} else {
						GameManager.instance.CapturePieceAt (gridPointNN);
										GameManager.instance.Move (MoveSelector.Instance.movingPiece, gridPointNN);

			
					}
			
					
							ExitState ();

					Debug.Log ("Move Occured.");

					OrB = 1;
					xx = false;
					// Reference Point 1: add ExitState call here later
					object OOOOO=new object();
					lock(OOOOO){				
							RefrigtzChessPortable.AllDraw.CalIdle=0;
								tileHighlight.SetActive (false);
									}
							}
							}else
								Debug.LogError("Thjinkingn Failed.");
						}
					}

				});
				output.Wait ();
						
				RefrigtzChessPortable.AllDraw.IdleInWork=true;



			

			
			
			
			}
		} else {
				tileHighlight.SetActive (false);

			}	
	
		x = t.t.R.CromosomRowFirst = -1;
		y = t.t.R.CromosomColumnFirst = -1;
		x1 = t.t.R.CromosomRow = -1;
		y1 = t.t.R.CromosomColumn = -1;

	}

	 
	void UserWait()
	{
		ff.Wait ();

		Update ();
	}
	bool ThinkingWait()
	{
		if(f==null)
		f = System.Threading.Tasks.Task.Factory.StartNew (() => xx = MoveAI (-1, -1, -1, -1));
	else
		if(f.IsCanceled)
		f = System.Threading.Tasks.Task.Factory.StartNew (() => xx = MoveAI (-1, -1, -1, -1));
		//f.Wait ();

		if(f.IsCompleted)
			return true;
		return false;
}

	void Awake(){
		if (t == null) {
			t = new ArtificialInteligenceMove ();

		}


		}


    private void CancelMove()
    {
        this.enabled = false;

        foreach (GameObject highlight in locationHighlights)
        {
            Destroy(highlight);
        }

        GameManager.instance.DeselectPiece(movingPiece);
        TileSelector selector = GetComponent<TileSelector>();
        selector.EnterState();
	  }

    public void EnterState(GameObject piece)
    {
        movingPiece = piece;
        this.enabled = true;

        moveLocations = GameManager.instance.MovesForPiece(movingPiece);
        locationHighlights = new List<GameObject>();

        if (moveLocations.Count == 0)
        {
            CancelMove();
        }

        foreach (Vector2Int loc in moveLocations)
        {
            GameObject highlight;
            if (GameManager.instance.PieceAtGrid(loc))
            {
                highlight = Instantiate(attackLocationPrefab, Geometry.PointFromGrid(loc), Quaternion.identity, gameObject.transform);
            }
            else
            {
                highlight = Instantiate(moveLocationPrefab, Geometry.PointFromGrid(loc), Quaternion.identity, gameObject.transform);
            }
            locationHighlights.Add(highlight);
        }
	
    }

    private void ExitState()
	{    this.enabled = false;
        TileSelector selector = GetComponent<TileSelector>();
        tileHighlight.SetActive(false);
        GameManager.instance.DeselectPiece(movingPiece);
        movingPiece = null;
        GameManager.instance.NextPlayer();
        selector.EnterState();
        foreach (GameObject highlight in locationHighlights)
        {
            Destroy(highlight);
        }
    }

}
