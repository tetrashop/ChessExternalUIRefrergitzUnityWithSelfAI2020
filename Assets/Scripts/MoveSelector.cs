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
[SerializeField]
public class MoveSelector : MonoBehaviour
{		public GameObject moveLocationPrefab;
	 public GameObject tileHighlightPrefab;
    public GameObject attackLocationPrefab;

    private GameObject tileHighlight;
    private GameObject movingPiece;
    private List<Vector2Int> moveLocations;
    private List<GameObject> locationHighlights;
	int Order=1;
	public int x,y,x1,y1;


	static int OrderAI=1;
	int xB,yB,OrB=-2;
	ArtificialInteligenceMove t;
	bool TU=false;
	System.Threading.Tasks.Task ff = null;
	System.Threading.Tasks.Task f = null;
	bool xc = false;
	bool xx = false;
	System.Threading.Tasks.Task Output = null;
	void Start ()
	{
		Awake();
		this.enabled = false;
		tileHighlight = Instantiate (tileHighlightPrefab, Geometry.PointFromGrid (new Vector2Int (0, 0)),
			Quaternion.identity, gameObject.transform);
		tileHighlight.SetActive (false);
	
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
			Order=-1;




		}else
			if(Order==-1)
			{
				t.t.Play(-1,-1);
				x=t.t.R.CromosomRowFirst;
				y=t.t.R.CromosomColumnFirst;
				x1=t.t.R.CromosomRow;
				y1=t.t.R.CromosomColumn;


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
		bool MoveAIBool = false;
		Vector2Int gridPoint = null;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			Vector3 point = hit.point;
			gridPoint = Geometry.GridFromPoint (point);

			tileHighlight.SetActive (true);
			tileHighlight.transform.position = Geometry.PointFromGrid (gridPoint);
			if (Input.GetMouseButtonDown (0)) {
				if (OrB == -2)
					OrB = 1;
				// Reference Point 2: check for valid move location
				if (!Exist (moveLocations, gridPoint)) {
					return;
				}
				if (GameManager.instance.PieceAtGrid (gridPoint) == null) {
					
					GameManager.instance.Move (movingPiece, gridPoint);
					MoveAIBool = true;
				} else {
					GameManager.instance.CapturePieceAt (gridPoint);
					GameManager.instance.Move (movingPiece, gridPoint);
					MoveAIBool = true;
				}
				ExitState ();
				tileHighlight.SetActive(false);
				//
			}
			
		}
			Output =	System.Threading.Tasks.Task.Factory.StartNew (() => {
			if (MoveAIBool) {
				bool aa = false;
					aa = t != null && GameCanged ();
				if (aa)
					aa = aa && t.t != null;
				if (aa) {
					if (t.t.LoadP) {	

						if (OrderAI == 1) {
							OrB = 0;

								
							if (!TU) {
								ff =	System.Threading.Tasks.Task.Factory.StartNew (() => xc = MoveAI (TileSelector.x, TileSelector.y, gridPoint.x, gridPoint.y));
								TU = true;
								ff.Wait ();
								OrderAI = -1;
								OrB = 1;
								TU = false;
								//							System.Threading.Thread d = new System.Threading.Thread (new System.Threading.ThreadStart (UserWait));
								//									
								Debug.Log ("Thinking...");
										
								f = System.Threading.Tasks.Task.Factory.StartNew (() => xx = MoveAI (-1, -1, -1, -1));
								f.Wait ();
											
													

								Debug.Log ("Thinking Finished.");
								Vector2Int gridPointN = new Vector2Int (x, 7 - y);


								//
								//				
								//				gridPointN =new Vector2Int(x,7-y); 

								movingPiece =	GameManager.instance.pieces [x, 7 - y];

								Vector2Int gridPointNN = new Vector2Int (x1, 7 - y1);

								tileHighlight.SetActive (true);
								tileHighlight.transform.position = Geometry.PointFromGrid (gridPointNN);

								Debug.Log ("tile selected.");
								//				Vector3 pointN = Geometry.PointFromGrid (gridPointNN);
								//				movingPiece.transform.position = pointN;
//								if (!Exist (moveLocations, gridPointN)) {
//									return;
//								}
								Debug.Log ("Move Source...");

								if (GameManager.instance.PieceAtGrid (gridPointN) == null) {

									GameManager.instance.Move (movingPiece, gridPointNN);
									MoveAIBool = false;
								} else {
									GameManager.instance.CapturePieceAt (gridPointNN);
									GameManager.instance.Move (movingPiece, gridPointNN);
									MoveAIBool = false;
								}
								Debug.Log ("Move Occured.");

								OrB = 1;
								OrderAI = 1;
								//				tileHighlight.SetActive (false);

								xx = false;
								// Reference Point 1: add ExitState call here later
								//				ExitState ();

								ExitState();
											

								tileHighlight.SetActive(false);

							}
						}
			
											
					}
				}}
			});
			Output.Wait ();	

//			System.Threading.Thread d = new System.Threading.Thread (new System.Threading.ThreadStart (ThinkingWait));
//			d.Start ();
//			//						
			// Reference Point 3: capture enemy piece here later	


	}

	 
	void UserWait()
	{
		ff.Wait ();

		Update ();
	}void ThinkingWait()
	{
		Output.Wait ();	

	}

	void Awake(){
		if (t == null) {
			t = new ArtificialInteligenceMove ();
		}

<<<<<<< HEAD

=======
		if (OrderAI == -1) {
			Update ();
		}
>>>>>>> b8bafb953c796dcfbae14fe7c799e526d6edf647
	
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
