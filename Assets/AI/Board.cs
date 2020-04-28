//
//www.IranProject.Ir
//
using System;
namespace RefrigtzChessPortable
{
    /// <summary>
    /// Summary description for Board.
    /// </summary>
	public class Board : System.Object
    {
        private int[,] square;

        public Board()
        {
            int i, j;
            square = new int[8, 8];
            square[0, 0] = 1;//Black castle
            square[1, 0] = 2;//Black knight
            square[2, 0] = 3;//Black bishop
            square[3, 0] = 4;//Black queen
            square[4, 0] = 5;//Black king
            square[5, 0] = 3;//Black bishop
            square[6, 0] = 2;//Black knight
            square[7, 0] = 1;//Black castle
            for (i = 0; i < 8; i++)
            {
                square[i, 1] = 6;//Black pawns
                square[i, 6] = 12;//White pawns
            }
            square[0, 7] = 7;//White castle
            square[1, 7] = 8;//White knight
            square[2, 7] = 9;//White bishop
            square[3, 7] = 10;//White queen
            square[4, 7] = 11;//White king
            square[5, 7] = 9;//White bishop
            square[6, 7] = 8;//White knight
            square[7, 7] = 7;//White castle
            for (i = 0; i < 8; i++)
                for (j = 2; j < 6; j++)
                    square[i, j] = 0;//Empty
        }
        public void Setsqure(int[,] Table)
        {
            square = new int[8, 8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (Table[i,j] == -1)
                        square[i, j] = 6;
                    else
                    if (Table[i,j] == 1)
                        square[i, j] = 12;
                    else
                    if (Table[i,j] == 2)
                        square[i, j] = 9;
                    else
                    if (Table[i,j] == -2)
                        square[i, j] = 3;
                    else
                    if (Table[i,j] == -3)
                        square[i, j] = 2;
                    else
                    if (Table[i,j] == 3)
                        square[i, j] = 8;
                    else
                    if (Table[i,j] == 4)
                        square[i, j] = 7;
                    else
                    if (Table[i,j] == -4)
                        square[i, j] = 1;
                    else
                    if (Table[i,j] == 5)
                        square[i, j] = 10;
                    else
                  if (Table[i,j] == -5)
                        square[i, j] = 4;
                    else
                  if (Table[i,j] == -6)
                        square[i, j] = 5;
                    else
                    if (Table[i,j] == 6)
                        square[i, j] = 11;
                    else
                        square[i, j] = 0;

                }

        }
        public int[,] GetTable()
        {
            int[,] Table = new int[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (square[i, j] == 6)
                        Table[i,j] = -1;
                    else
                          if (square[i, j] == 12)
                        Table[i,j] = 1;
                    else
                          if (square[i, j] == 9)
                        Table[i,j] = 2;
                    else
                          if (square[i, j] == 2)
                        Table[i,j] = -3;
                    else
                          if (square[i, j] == 3)
                        Table[i,j] = -2;
                    else
                          if (square[i, j] == 8)
                        Table[i,j] = 3;
                    else
                          if (square[i, j] == 7)
                        Table[i,j] = 4;
                    else
                          if (square[i, j] == 1)
                        Table[i,j] = -4;
                    else
                          if (square[i, j] == 10)
                        Table[i,j] = 5;
                    else
                        if (square[i, j] == 4)
                        Table[i,j] = -5;
                    else
                        if (square[i, j] == 5)
                        Table[i,j] = -6;
                    else
                          if (square[i, j] == 11)
                        Table[i,j] = 6;
                    else
                        Table[i,j] = 0;
                }
            return Table;
        }
        public int[,] GetSqure(int[,] Table)
        {
            object O = new object();
            lock (O)
            {
                int[,] square = new int[8, 8];
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        if (Table[i,j] == -1)
                            square[i, j] = 6;
                        else
                    if (Table[i,j] == 1)
                            square[i, j] = 12;
                        else
                    if (Table[i,j] == 2)
                            square[i, j] = 9;
                        else
                    if (Table[i,j] == -2)
                            square[i, j] = 3;
                        else
                    if (Table[i,j] == -3)
                            square[i, j] = 2;
                        else
                    if (Table[i,j] == 3)
                            square[i, j] = 8;
                        else
                    if (Table[i,j] == 4)
                            square[i, j] = 7;
                        else
                    if (Table[i,j] == -4)
                            square[i, j] = 1;
                        else
                    if (Table[i,j] == 5)
                            square[i, j] = 10;
                        else
                  if (Table[i,j] == -5)
                            square[i, j] = 4;
                        else
                  if (Table[i,j] == -6)
                            square[i, j] = 5;
                        else
                    if (Table[i,j] == 6)
                            square[i, j] = 11;
                        else
                            square[i, j] = 0;
                    }
                return square;
            }
        }
        public int getInfo(int i, int j)
        {
            return square[i, j];
        }

        public int getbcolor(int i, int j)
        {
            if ((i + j) % 2 == 0)
                return 2;//back intof the board is white
            else
                return 1;//back intof the board is black
        }

        public void setSquare(int value, int i, int j)
        {
            square[i, j] = value;
        }
        public Point searchKing(int color)
        {
            Point p = new Point();
            int i, j;
            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    if (getInfo(i, j) == (3 + (2 * color * color)))
                    {
                        p.x = i;
                        p.y = j;
                        return p;
                    }
                }

            
         
            //System.Windows.Forms.//MessageBox.Show(str);
            return p;
        }
        public int isMated(int color)
        {
            Point p = new Point();
            p = searchKing(color);
            King king = new King(color, p.x, p.y);
            if (king.isChecked(this) == 1)
            {
                if (canDefend(color) == 1)
                    return 0;
                else
                    return 1;
            }
            return 0;
        }

        public int canDefend(int color)
        {
            Board b = new Board();
            Castle castle = new Castle(color, 0, 0);
            Pawn pawn = new Pawn(color, 0, 0);
            Knight knight = new Knight(color, 0, 0);
            Bishop bishop = new Bishop(color, 0, 0);
            Queen queen = new Queen(color, 0, 0);
            int i, j, m, n, f = 0;
            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                    b.setSquare(this.getInfo(i, j), i, j);
            Point p = b.searchKing(color);
            King king = new King(color, p.x, p.y);
            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    if (b.getInfo(i, j) == 0)
                    {
                    }
                    else if (b.getInfo(i, j) == (color == 1 ? 1 : 7))
                    {
                        castle.x = i;
                        castle.y = j;
                        for (m = 0; m < 8; m++)
                            for (n = 0; n < 8; n++)
                            {
                                if (castle.move(b, m, n) == 1)
                                {
                                    f = b.getInfo(m, n);
                                    b.setSquare(0, i, j);
                                    b.setSquare((color == 1 ? 1 : 7), m, n);
                                    if (king.isChecked(b) == 0)
                                    {
                                        return 1;
                                    }
                                    b.setSquare((color == 1 ? 1 : 7), i, j);
                                    b.setSquare(f, m, n);

                                }
                            }
                    }
                    else if (b.getInfo(i, j) == (color == 1 ? 2 : 8))
                    {
                        knight.x = i;
                        knight.y = j;
                        for (m = 0; m < 8; m++)
                            for (n = 0; n < 8; n++)
                            {
                                if (knight.move(b, m, n) == 1)
                                {
                                    f = b.getInfo(m, n);
                                    b.setSquare(0, i, j);
                                    b.setSquare((color == 1 ? 2 : 8), m, n);
                                    if (king.isChecked(b) == 0)
                                    {
                                        return 1;
                                    }
                                    b.setSquare((color == 1 ? 2 : 8), i, j);
                                    b.setSquare(f, m, n);
                                }
                            }
                    }
                    else if (b.getInfo(i, j) == (color == 1 ? 3 : 9))
                    {
                        bishop.x = i;
                        bishop.y = j;
                        for (m = 0; m < 8; m++)
                            for (n = 0; n < 8; n++)
                            {
                                if (bishop.move(b, m, n) == 1)
                                {
                                    f = b.getInfo(m, n);
                                    b.setSquare(0, i, j);
                                    b.setSquare((color == 1 ? 3 : 9), m, n);
                                    if (king.isChecked(b) == 0)
                                    {
                                        return 1;
                                    }
                                    b.setSquare((color == 1 ? 3 : 9), i, j);
                                    b.setSquare(f, m, n);
                                }
                            }
                    }
                    else if (b.getInfo(i, j) == (color == 1 ? 4 : 10))
                    {
                        queen.x = i;
                        queen.y = j;
                        for (m = 0; m < 8; m++)
                            for (n = 0; n < 8; n++)
                            {
                                if (queen.move(b, m, n) == 1)
                                {
                                    f = b.getInfo(m, n);
                                    b.setSquare(0, i, j);
                                    b.setSquare((color == 1 ? 4 : 10), m, n);
                                    if (king.isChecked(b) == 0)
                                    {
                                        return 1;
                                    }
                                    b.setSquare((color == 1 ? 4 : 10), i, j);
                                    b.setSquare(f, m, n);
                                }
                            }
                    }

                    else if (b.getInfo(i, j) == (color == 1 ? 5 : 11))
                    {
                        for (m = 0; m < 8; m++)
                            for (n = 0; n < 8; n++)
                            {
                                if (king.move(b, m, n) == 1)
                                {
                                    f = b.getInfo(m, n);
                                    king.x = m;
                                    king.y = n;
                                    b.setSquare(0, i, j);
                                    b.setSquare((color == 1 ? 5 : 11), m, n);
                                    if (king.isChecked(b) == 0)
                                    {
                                        return 1;
                                    }
                                    b.setSquare((color == 1 ? 5 : 11), i, j);
                                    b.setSquare(f, m, n);
                                    king.x = p.x;
                                    king.y = p.y;
                                }
                            }
                    }

                    else if (b.getInfo(i, j) == (color == 1 ? 6 : 12))
                    {
                        pawn.x = i;
                        pawn.y = j;
                        for (m = 0; m < 8; m++)
                            for (n = 0; n < 8; n++)
                            {
                                if (pawn.move(b, m, n) == 1)
                                {
                                    f = b.getInfo(m, n);
                                    b.setSquare(0, i, j);
                                    b.setSquare((color == 1 ? 6 : 12), m, n);
                                    if (king.isChecked(b) == 0)
                                    {
                                        return 1;
                                    }
                                    b.setSquare((color == 1 ? 6 : 12), i, j);
                                    b.setSquare(f, m, n);
                                }
                            }
                    }
                }
            return 0;
        }
    }
}
