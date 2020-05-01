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
using RefrigtzChessPortable;

[SerializeField]


public class MoveSelector : MonoBehaviour
{	
//	static bool OutrPoutInWorking = false;
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

//	bool TU=false;
	System.Threading.Tasks.Task ff = null;
	System.Threading.Tasks.Task f = null;

	bool xc = false;
	bool xx = false;
	private GameObject	selectobject;
	public static MoveSelector Instance;
	int k = -1;
	int p = -1;
	int m = -1;
	int s = -1;

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
	public bool MoveAI()
	{
		object o = new object ();
		lock(o){	
			if(Order==1)
		{
				ArtificialInteligenceMove.Ret().t.Play(k,p);
			ArtificialInteligenceMove.Ret().t.Play(m,s);
			Order = -1;
				return true;
		}else
			if(Order==-1)
				{
					object oo = new object ();
					lock(oo){	RefrigtzChessPortable.AllDraw.MaxAStarGreedy=RefrigtzChessPortable.AllDraw.PlatformHelperProcessorCount;
					RefrigtzChessPortable.AllDraw.MaxAStarGreedy=RefrigtzChessPortable.AllDraw.PlatformHelperProcessorCount;
					RefrigtzChessPortable.AllDraw.MaxAStarGreedyHeuristicProgress=RefrigtzChessPortable.AllDraw.PlatformHelperProcessorCount;
					RefrigtzChessPortable.AllDraw.AStarGreedyiLevelMax=RefrigtzChessPortable.AllDraw.PlatformHelperProcessorCount;
			
					}
					object ooo = new object ();
					lock(oo){	
						int a=	ArtificialInteligenceMove.Ret().t.Play(-1,-1);
					if (a == -2)
						Debug.LogError ("Table zero");
				x=ArtificialInteligenceMove.Ret().t.R.CromosomRowFirst;
				y=ArtificialInteligenceMove.Ret().t.R.CromosomColumnFirst;
				x1=ArtificialInteligenceMove.Ret().t.R.CromosomRow;
				y1=ArtificialInteligenceMove.Ret().t.R.CromosomColumn;
					}
			Order = 1;
					return true;
			}
	}
		return false;
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
			
		object pp = new object ();
		lock (pp) {
			bool aa = false;
		
			aa = ArtificialInteligenceMove.Ret () != null;
			aa = aa &&
			ArtificialInteligenceMove.Ret ().t != null;
			if (aa) {

				if (ArtificialInteligenceMove.Ret ().t.LoadP) {



					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

					RaycastHit hit;
					if (Physics.Raycast (ray, out hit)) {
						Vector3 point = hit.point;
						Vector2Int gridPoint = Geometry.GridFromPoint (point);
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


							if (Order == 1) {
								object OO = new object ();
								lock (OO) {

									k = TileSelector.x;
									p = 7 - TileSelector.y;
									m = gridPoint.x;
									s = 7 - gridPoint.y;

									ff =	System.Threading.Tasks.Task.Factory.StartNew (() => xc = MoveAI ());
									ff.Wait ();
								}
							}
							UnityThread.executeInUpdate(() =>
								{

									var output = Task.Factory.StartNew (() => {

										object OOO = new object ();
										lock (OOO) {
											if (Order == -1) {

												OrB = 1;




												f = System.Threading.Tasks.Task.Factory.StartNew (() => xx = MoveAI ());
												f.Wait ();
												if (x != -1 && y != -1 && x1 != -1 && y1 != -1) {


													Debug.Log ("Thinking Finished.");
													Vector2Int gridPointN = new Vector2Int (x, 7 - y);

													selectobject = GameManager.instance.PieceAtGrid (gridPointN);

													if (GameManager.instance.DoesPieceBelongToCurrentPlayer (selectobject)) {
														GameManager.instance.SelectPiece (selectobject);
														TileSelector.instance.ExitState (selectobject);
													}
													string A = "x:'" + x.ToString () + "';y:'" + y.ToString () + "';x1:'" + x1.ToString () + "';y1:'" + y1.ToString () + "'\r\n";
													A += "================================================================================================\r\n";
													System.IO.File.AppendAllText ("A.txt"
														, A);										//									movingPiece=selectobject;
													//									EnterState(selectobject);
													Vector2Int gridPointNN = new Vector2Int (x1, 7 - y1);


													MoveSelector.Instance.tileHighlight.SetActive (true);
													MoveSelector.Instance.tileHighlight.transform.position = Geometry.PointFromGrid (gridPointNN);

													if (MoveSelector.Instance.moveLocations.Count == 0)
														Debug.Log ("enter state not valid.");

													if (!Exist (MoveSelector.Instance.moveLocations, gridPointNN)) {
														return;
													}
													//										
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

													object OOOOO = new object ();
													lock (OOOOO) {				
														tileHighlight.SetActive (false);
														x = ArtificialInteligenceMove.Ret ().t.R.CromosomRowFirst = -1;
														y = ArtificialInteligenceMove.Ret ().t.R.CromosomColumnFirst = -1;
														x1 = ArtificialInteligenceMove.Ret ().t.R.CromosomRow = -1;
														y1 = ArtificialInteligenceMove.Ret ().t.R.CromosomColumn = -1;

														RefrigtzChessPortable.AllDraw.CalIdle = 0;
														RefrigtzChessPortable.AllDraw.IdleInWork = true;
													}
													//												}
												} else
													Debug.LogError ("Thinking Failed.");
											}									
										}


									});
									output.Wait ();
									output.Dispose ();

									ArtificialInteligenceMove.UpdateIsRunning = false;

							});
						}
					} else {
						tileHighlight.SetActive (false);
					}
				}
			}
		}



	}
	 
//	void UserWait()

	void Awake(){

		UnityThread.initUnityThread();
		if (ArtificialInteligenceMove.tta == null) {
			ArtificialInteligenceMove.tta= new ArtificialInteligenceMove ();

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
