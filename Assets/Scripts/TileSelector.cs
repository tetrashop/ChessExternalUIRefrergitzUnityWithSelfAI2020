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
using RefrigtzChessPortable;

public class TileSelector : MonoBehaviour
{
	public static int x, y; 
    public GameObject tileHighlightPrefab;

	public GameObject tileHighlight;
	public static TileSelector instance;

	static bool Log=true;


    public void Start ()
    { 
        Vector2Int gridPoint = Geometry.GridPoint(0, 0);
        Vector3 point = Geometry.PointFromGrid(gridPoint);
        tileHighlight = Instantiate(tileHighlightPrefab, point, Quaternion.identity, gameObject.transform);
        tileHighlight.SetActive(false);

    }
	public void Awake ()
	{
		instance = this;
	}
	public void Update ()

	{
		if (ArtificialInteligenceMove.UpdateIsRunning) {
//			tileHighlight.SetActive (false);
//

			if (Log) {
				Debug.Log ("Ready to UpdateIsRunning base");
				Log = false;
			}


//		if (RefrigtzChessPortable.AllDraw.CalIdle != 1&&RefrigtzChessPortable.AllDraw.CalIdle != 5) {
//			if (RefrigtzChessPortable.AllDraw.CalIdle ==0)
//				RefrigtzChessPortable.AllDraw.CalIdle = 2;
//		}	
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {

				Vector3 point = hit.point;
				Vector2Int gridPoint = Geometry.GridFromPoint (point);
		
				tileHighlight.SetActive (true);
				tileHighlight.transform.position = Geometry.PointFromGrid (gridPoint);
				if (Input.GetMouseButtonDown (0)) {
				

					GameObject selectedPiece = GameManager.instance.PieceAtGrid (gridPoint);
					if (GameManager.instance.DoesPieceBelongToCurrentPlayer (selectedPiece)) {
						x = gridPoint.x;
						y = gridPoint.y;
						GameManager.instance.SelectPiece (selectedPiece);
						// Reference Point 1: add ExitState call here later
						ExitState (selectedPiece);
						instance = this;
					}
				}
			} else {
				tileHighlight.SetActive (false);
				
			}
		} else
			Log = true;
    }

    public void EnterState()
    {
        enabled = true;
    }

	public void ExitState(GameObject movingPiece)
	{
		this.enabled = false;
		tileHighlight.SetActive (false);
		MoveSelector move = GetComponent<MoveSelector> ();
		move.EnterState (movingPiece);
		MoveSelector.Instance = move;
	}
}
