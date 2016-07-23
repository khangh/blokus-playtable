using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	// all of the rows of the board
	public GameObject[] rows = new GameObject[20];

	/* 
	 * Called when the component is enabled (in this case, the start of the application).
	 */
	void Awake() {
		enumerateCells ();
	}

	/*
	 * get (int col, int row)
	 * Given a col and row, return the cell at the col and row.
	 */
	public GameObject get(int col, int row) {
		GameObject myRow = rows [row];
		Row rowObject = myRow.GetComponent<Row> ();
		GameObject[] myCol = rowObject.cells;
		GameObject myCell = myCol [col];
		return myCell;
	}

	/*
	 * enumerateCells()
	 * Assigns a coordinate to all cells on the grid.
	 */
	public void enumerateCells() {
		/*for (int col = 0; col < 20; col += 1) {
			for (int row = 0; row < 20; row += 1) {

				GameObject myCell = get (col, row);
				Cell cell = myCell.GetComponent<Cell>();
				cell.column = col;
				cell.row = row;
			}
		}*/
	}
}
