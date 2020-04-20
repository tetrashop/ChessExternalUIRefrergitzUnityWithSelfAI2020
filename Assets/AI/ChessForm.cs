//
//www.IranProject.Ir
//
using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;

//using System.Data;
using RefrigtzChessPortable;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
namespace RefrigtzChessPortable
{
    [Serializable]
    public class RefrigtzChessPortableForm //: System.Windows.Forms.Form
    {
		public bool LoadP = false;
		static readonly bool UsePenaltyRegardMechnisam = false;
		static readonly bool AStarGreedyHeuristic = false;
		int AllDrawKind = 0;
		bool NotFoundBegin = false;
		bool Deeperthandeeper = false;
		readonly String path3 = @"temp";
		String AllDrawReplacement = "";

		public static int MovmentsNumber = 0;
		public static String Root = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
		public static String AllDrawKindString = "";
		public static int OrderPlate = 1;
		bool CoPermit = true;
		int ConClick = -1;
		bool WaitOnplay = false;
		public RefrigtzChessPortable.RefrigtzChessPortableGeneticAlgorithm R = new RefrigtzChessPortable.RefrigtzChessPortableGeneticAlgorithm(false, false,UsePenaltyRegardMechnisam, false, false, false, false, true);
		bool Person = true;
		public RefrigtzChessPortable.AllDraw Draw = new AllDraw(-1, false, false, UsePenaltyRegardMechnisam, false, false, false, AStarGreedyHeuristic, true);
		int[,] Table = null;
		bool FOUND = false;

		#region These are the global variables and objects for RefrigtzChessPortableForm class
			private int cl;
		private int order;
		private int x1;
		private int y1;
		private Board brd=new Board();
	#endregion

  [field: NonSerialized]
        private  CancellationTokenSource feedCancellationTokenSource =
            new CancellationTokenSource();


        public RefrigtzChessPortableForm()
       {
            
            //Init();
            //Init2();
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        
        void Initiate(int a, int Order)
        {
            Object O = new Object();
            lock (O)
            {
                int LeafAStarGrteedy = 0;
                AllDraw THIS = Draw.AStarGreedyString;
                Table = Draw.Initiate(1, 4, a, CloneATable(brd.GetTable()), Order, false, FOUND, LeafAStarGrteedy);
                //Draw.AStarGreedyString = THIS;
            }
        }
        void AliceAction(int Order)
        {
            
            
            
            Object O = new Object();
            lock (O)
            {
                bool B = AllDraw.Blitz;
                AllDraw.Blitz = false;
                RefrigtzChessPortable.ThinkingRefrigtzChessPortable.ThinkingRun = false;
                AllDraw Th = Draw.AStarGreedyString;
                if (Draw.IsAtLeastAllObjectIsNull())
                {
                    Draw.TableList.Clear();
                    Draw.TableList.Add(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]));
                    Draw.SetRowColumn(0);
                    Draw.IsCurrentDraw = true;
                }
                Draw.AStarGreedyString = Th;
                Initiate(-1, -1);
                AllDraw.Blitz = B;

            }
            
            
            
        }
         
        void ClearTableInitiationPreventionOfMultipleMove()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Table[i, j] == 0)
                    {
                        if (RefrigtzChessPortable.ThinkingRefrigtzChessPortable.TableInitiationPreventionOfMultipleMove[i, j] != 0)
                            RefrigtzChessPortable.ThinkingRefrigtzChessPortable.TableInitiationPreventionOfMultipleMove[i, j] = RefrigtzChessPortable.ThinkingRefrigtzChessPortable.NoOfMovableAllObjectMove - 1;
                    }
                }
            }

        }
		public void Form1_Load()
        {
            Object O = new Object();
            lock (O)
            {
                if (!LoadP)
                {
                    //MessageBox.Show("Wait...");
                    var parallelOptions = new ParallelOptions();
                    parallelOptions.MaxDegreeOfParallelism = AllDraw.PlatformHelperProcessorCount;
                    RefrigtzChessPortable.AllDraw.OrderPlateDraw = -1;
                    RefrigtzChessPortable.AllDraw.TableListAction.Add(CloneATable(brd.GetTable()));
                    Table = CloneATable(brd.GetTable());
                    RefrigtzChessPortable.ThinkingRefrigtzChessPortable.TableInitiation = CloneATable(brd.GetTable());
                    if (DrawManagement())
                    {
                        //Load AllDraw.asd
                        bool LoadTree = true;
                        TakeRoot y = new TakeRoot();
                        bool DrawDrawen = y.Load(FOUND, false, this, ref LoadTree, false, false, UsePenaltyRegardMechnisam, false, false, false, AStarGreedyHeuristic, true);
                        if (!DrawDrawen)
                        {
                            Draw = new RefrigtzChessPortable.AllDraw(OrderPlate, false, false, UsePenaltyRegardMechnisam, false, false, false, AStarGreedyHeuristic, true);
                            Draw.TableList.Clear();
                            Draw.TableList.Add(CloneATable(Table));
                            Draw.SetRowColumn(0);
                            RefrigtzChessPortable.AllDraw.DepthIterative = 0;

                            bool Store = Deeperthandeeper;
                            Deeperthandeeper = false;

                            OrderPlate = 1;
                            AllDraw.OrderPlate = OrderPlate;

                            int Ord = OrderPlate;
                            int aa = 1;
                            if (Ord == -1)
                                aa = -1;
                            bool B = AllDraw.Blitz;
                            AllDraw.Blitz = false;
                            RefrigtzChessPortable.AllDraw.MaxAStarGreedy = AllDraw.PlatformHelperProcessorCount;
                            
                            if (Draw.IsAtLeastAllObjectIsNull())
                            {
                                Draw.TableList.Clear();
                                Draw.TableList.Add(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 2]));
                                Draw.SetRowColumn(0);
                                Draw.IsCurrentDraw = true;
                            }
                            Draw.InitiateAStarGreedyt(RefrigtzChessPortable.AllDraw.MaxAStarGreedy, 0, 0, aa, CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]), Ord, false, FOUND, 0);

                            AllDraw.Blitz = B;
                            Deeperthandeeper = Store;
                            
                        }
                        else
                        {
                            FOUND = false;
                            Draw = y.t;
                            Thread arr = new Thread(new ThreadStart(SetDrawFound));
                            arr.Start();
                            arr.Join();
                        }
                    }
                    //MessageBox.Show("Ready...");
                    LoadP = true;
                }
            }
        }
        void ClickedSimAtClOne(int i, int j)
        {
            Object o = new Object();
            lock (o)
            {
                int ii = new int();
                int jj = new int();
                if (R.CromosomRowFirst == -1 || R.CromosomColumnFirst == -1 || R.CromosomRow == -1 || R.CromosomColumn == -1)
                {
                    ii = AllDraw.NextRow;
                    jj = AllDraw.NextColumn;
                }
                else
                {
                    ii = R.CromosomRow;
                    jj = R.CromosomColumn;
                }
                
                
                
                
                Play(ii, jj);
                
                AllDraw.NextRow = -1;
                AllDraw.NextColumn = -1;
                AllDraw.LastRow = -1;
                AllDraw.LastColumn = -1;
                cl = 0;
                Person = true;
            }
        }
        static void Log(Exception ex)
        {
            
            Object a = new Object();
            lock (a)
            {
                string stackTrace = ex.ToString();
                 File.AppendAllText(AllDraw.Root + "\\ErrorProgramRun.txt",  ": On" + DateTime.Now.ToString()); 
            }
            
        }
        int[,] CloneATable(int[,] Tab)
        {
            Object O = new Object();
            lock (O)
            {          
                int[,] Tabl = new int[8, 8];
                for (var i = 0; i < 8; i++)
                    for (var j = 0; j < 8; j++)
                        Tabl[i, j] = Tab[i, j];
                
                return Tabl;
            }
        }
        void WaitCon()
        {
            do { } while (ConClick == -1);
        }
        void WaitOnly()
        {
            do { } while (WaitOnplay);
        }
        public int Play(int i, int j)
        {
            Object o = new Object();
            lock (o)
            {
                
                
                
                try
                {
                    bool Com = false;
                    int k = 0;
                    int played = 0;

                    if (i == -1 && j == -1)
                    {
                        Again:
                        CoPermit = false;
                        Person = false;
                        
                        AllDraw.Blitz = true;
                        

                   
                        
                        
                        Table = brd.GetTable();
                        
                        
                        
                        
                        var newTask = Task.Factory.StartNew(() => AliceAction(-1));
                        newTask.Wait();
                        newTask.Dispose();
                        if (Draw.TableZero(Table))
                        {
                            //MessageBox.Show("Board is invalid;");
                            Draw.TableList.Clear();
                            Draw.TableList.Add(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]));
                            Draw.SetRowColumn(0);
                            Draw.IsCurrentDraw = true;
                            RefrigtzChessPortable.ThinkingRefrigtzChessPortable.NoOfMovableAllObjectMove++;
                            RefrigtzChessPortable.AllDraw.AllowedSupTrue = true;

                            goto Again;
                        }
                        RefrigtzChessPortable.AllDraw.AllowedSupTrue = false;




                        RefrigtzChessPortable.AllDraw.TableListAction.Add(CloneATable(Table));
                        R = new RefrigtzChessPortable.RefrigtzChessPortableGeneticAlgorithm(false, false, false, false, false, false, false, true);
                        if (R.FindGenToModified(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 2], RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1], RefrigtzChessPortable.AllDraw.TableListAction, 0, -1, true))
                        {
                            
                            int ii = new int();
                            int jj = new int();
                            if (R.CromosomRowFirst == -1 || R.CromosomColumnFirst == -1 || R.CromosomRow == -1 || R.CromosomColumn == -1)
                            {
                                
                                //MessageBox.Show("One or more cromosoms is invalid;");
                                RefrigtzChessPortable.AllDraw.TableListAction.RemoveAt(RefrigtzChessPortable.AllDraw.TableListAction.Count - 1);

                      
                                
                                
                                
                                
                                
                                
                                goto Again;
                            }
                            
                            ii = R.CromosomRowFirst;
                            jj = R.CromosomColumnFirst;
                            i = ii;
                            j = jj;
                            
                            k = brd.getInfo(i, j);
                            //if (k == 0)
                            
                            cl = 0;
                            if (RefrigtzChessPortable.AllDraw.OrderPlateDraw == 1)
                                RefrigtzChessPortable.ThinkingRefrigtzChessPortable.NoOfBoardMovedGray++;
                            else
                                RefrigtzChessPortable.ThinkingRefrigtzChessPortable.NoOfBoardMovedBrown++;
                        }
                        else
                        {
                            
                            
                            {
                                //MessageBox.Show("One or more DNA is invalid;");
                                
                                
                                
                                RefrigtzChessPortable.AllDraw.TableListAction.RemoveAt(RefrigtzChessPortable.AllDraw.TableListAction.Count - 1);
                                Table = brd.GetTable();
                                

                                
                                
                                
                                goto Again;
                            }
                        }
                        
                        
                    }
                    else
                    {
                        CoPermit = true;
                        k = brd.getInfo(i, j);
                        //if (k == 0)
                        
                    }
                  if (k > 6)
                    {
                        played = 2;
                    }
                    else if (k < 7 && k != 0)
                    {
                        played = 1;
                    }

                    if (cl == 0 && k != 0 && played == order)
                    {
                        x1 = i;
                        y1 = j;
                        //this.pb[i, j].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                        cl = 1;
                        Object oo = new Object();
                        lock (oo)
                        {
                            if ((!Person) && i != -1 && j != -1)
                                ClickedSimAtClOne(i, j);
                        }
                        return 0;
                    }
                    if (cl == 1)
                    {
                        Board b = new Board();
                        int m = brd.getInfo(x1, y1);
                        King king2 = new King(order, x1, y1);
                        int y, z;
                        for (y = 0; y < 8; y++)
                            for (z = 0; z < 8; z++)
                                b.setSquare(brd.getInfo(y, z), y, z);
                        switch (m)
                        {
                            case 1:
                                Castle cs2 = new Castle(1, x1, y1);
                                if (cs2.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(1, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                  // pb[x1, y1].Image = null;
                                    brd.setSquare(0, x1, y1);
                                    brd.setSquare(1, i, j);
                                    order++;
                                    if (brd.getbcolor(i, j) == 2)
                                    {
                                        //pb[i, j].Image = img1;
                                    }
                                    else if (brd.getbcolor(i, j) == 1)
                                    {
                                        //pb[i, j].Image = img2;
                                    }
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 2:
                                Knight kn = new Knight(1, x1, y1);
                                if (kn.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(2, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    brd.setSquare(0, x1, y1);
                                    brd.setSquare(2, i, j);
                                    order++;
                                    if (brd.getbcolor(i, j) == 2)
                                    {
                                        //pb[i, j].Image = img3;
                                    }
                                    else if (brd.getbcolor(i, j) == 1)
                                    {
                                        //pb[i, j].Image = img4;
                                    }
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 3:
                                Bishop bsp = new Bishop(1, x1, y1);
                                if (bsp.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(3, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                    // pb[x1, y1].Image = null;
                                    brd.setSquare(0, x1, y1);
                                    brd.setSquare(3, i, j);
                                    order++;
                                    if (brd.getbcolor(i, j) == 2)
                                    {
                                        //pb[i, j].Image = img5;
                                    }
                                    else if (brd.getbcolor(i, j) == 1)
                                    {
                                        //pb[i, j].Image = img6;
                                    }
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 4:
                                Queen qn2 = new Queen(1, x1, y1);
                                if (qn2.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(4, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    brd.setSquare(0, x1, y1);
                                    brd.setSquare(4, i, j);
                                    order++;
                                    if (brd.getbcolor(i, j) == 2)
                                    {
                                        //pb[i, j].Image = img7;
                                    }
                                    else if (brd.getbcolor(i, j) == 1)
                                    {
                                        //pb[i, j].Image = img8;
                                    }
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 5:
                                King kg2 = new King(1, x1, y1);
                                if (kg2.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(5, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    brd.setSquare(0, x1, y1);
                                    brd.setSquare(5, i, j);
                                    order++;
                                    if (brd.getbcolor(i, j) == 2)
                                    {
                                        //pb[i, j].Image = img9;
                                    }
                                    else if (brd.getbcolor(i, j) == 1)
                                    {
                                        //pb[i, j].Image = img10;
                                    }
                                    Com = true;
                                }
                                else if (kg2.move(brd, i, j) == 2)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(5, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                    // pb[x1, y1].Image = null;
                                    //pb[0, 0].Image = null;
                                    //pb[2, 0].Image = img9;
                                    //pb[3, 0].Image = img2;
                                    brd.setSquare(0, 0, 0);
                                    brd.setSquare(0, 4, 0);
                                    brd.setSquare(5, 2, 0);
                                    brd.setSquare(1, 3, 0);
                                    order++;
                                    Com = true;
                                }
                                else if (kg2.move(brd, i, j) == 3)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(5, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    //pb[7, 0].Image = null;
                                    //pb[5, 0].Image = img2;
                                    //pb[6, 0].Image = img9;
                                    brd.setSquare(0, 4, 0);
                                    brd.setSquare(0, 7, 0);
                                    brd.setSquare(1, 5, 0);
                                    brd.setSquare(5, 6, 0);
                                    order++;
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 6:
                                Pawn p = new Pawn(1, x1, y1);
                                if (p.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(6, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                    if (j == 7 && CoPermit)
                                    {
                                        //InitConv(y1);
                                        System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(WaitCon));
                                        t.Start();
                                        t.Join();
                                        if (ConClick == 1)
                                        {
                                            brd.setSquare(0, x1, y1);
                                            brd.setSquare(4, i, j);
                                        }
                                        else
                                         if (ConClick == 2)
                                        {
                                            brd.setSquare(0, x1, y1);
                                            brd.setSquare(1, i, j);
                                        }
                                        else
                                        if (ConClick == 3)
                                        {
                                            brd.setSquare(0, x1, y1);
                                            brd.setSquare(2, i, j);
                                        }
                                        else
                                        if (ConClick == 4)
                                        {
                                            brd.setSquare(0, x1, y1);
                                            brd.setSquare(3, i, j);
                                        }

                                    }
                                    else
                                    {
                                       // pb[x1, y1].Image = null;
                                        brd.setSquare(0, x1, y1);
                                        brd.setSquare(6, i, j);
                                    }
                                    order++;
                                    if (ConClick != -1)
                                    {
                                        if (ConClick == 1)
                                        {
                                            if (brd.getbcolor(i, j) == 2)
                                            {
                                                //pb[i, j].Image = img7;
                                            }
                                            else if (brd.getbcolor(i, j) == 1)
                                            {
                                                //pb[i, j].Image = img8;
                                            }
                                        }
                                        else
                                               if (ConClick == 2)
                                        {
                                            if (brd.getbcolor(i, j) == 2)
                                            {
                                                //pb[i, j].Image = img1;
                                            }
                                            else if (brd.getbcolor(i, j) == 1)
                                            {
                                                //pb[i, j].Image = img2;
                                            }
                                        }
                                        else
                                        if (ConClick == 3)
                                        {
                                            if (brd.getbcolor(i, j) == 2)
                                            {
                                                //pb[i, j].Image = img3;
                                            }
                                            else if (brd.getbcolor(i, j) == 1)
                                            {
                                                //pb[i, j].Image = img4;
                                            }
                                        }
                                        else
                                        if (ConClick == 4)
                                        {
                                            if (brd.getbcolor(i, j) == 2)
                                            {
                                                //pb[i, j].Image = img5;
                                            }
                                            else if (brd.getbcolor(i, j) == 1)
                                            {
                                                //pb[i, j].Image = img6;
                                            }
                                        }
                                        ConClick = -1;
                                        //DisposeConv();
                                    }
                                    else
                                    {
                                        if (brd.getbcolor(i, j) == 2)
                                        {
                                            //pb[i, j].Image = img11;
                                        }
                                        else if (brd.getbcolor(i, j) == 1)
                                        {
                                            //pb[i, j].Image = img12;
                                        }
                                    }
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 7:
                                Castle cs = new Castle(2, x1, y1);
                                if (cs.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(7, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    brd.setSquare(0, x1, y1);
                                    brd.setSquare(7, i, j);
                                    order--;
                                    if (brd.getbcolor(i, j) == 2)
                                    {
                                        //pb[i, j].Image = img21;
                                    }
                                    else if (brd.getbcolor(i, j) == 1)
                                    {
                                        //pb[i, j].Image = img22;
                                    }
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 8:
                                Knight kn2 = new Knight(2, x1, y1);
                                if (kn2.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(8, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    brd.setSquare(0, x1, y1);
                                    brd.setSquare(8, i, j);
                                    order--;
                                    if (brd.getbcolor(i, j) == 2)
                                    {
                                        //pb[i, j].Image = img23;
                                    }
                                    else if (brd.getbcolor(i, j) == 1)
                                    {
                                        //pb[i, j].Image = img24;
                                    }
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 9:
                                Bishop bsp2 = new Bishop(2, x1, y1);
                                if (bsp2.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(9, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    brd.setSquare(0, x1, y1);
                                    brd.setSquare(9, i, j);
                                    order--;
                                    if (brd.getbcolor(i, j) == 2)
                                    {
                                        //pb[i, j].Image = img25;
                                    }
                                    else if (brd.getbcolor(i, j) == 1)
                                    {
                                        //pb[i, j].Image = img26;
                                    }
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 10:
                                Queen qn = new Queen(2, x1, y1);
                                if (qn.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(10, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    brd.setSquare(0, x1, y1);
                                    brd.setSquare(10, i, j);
                                    order--;
                                    if (brd.getbcolor(i, j) == 2)
                                    {
                                        //pb[i, j].Image = img27;
                                    }
                                    else if (brd.getbcolor(i, j) == 1)
                                    {
                                        //pb[i, j].Image = img28;
                                    }
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 11:
                                King kg = new King(2, x1, y1);
                                if (kg.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(11, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    brd.setSquare(0, x1, y1);
                                    brd.setSquare(11, i, j);
                                    order--;
                                    if (brd.getbcolor(i, j) == 2)
                                    {
                                        //pb[i, j].Image = img29;
                                    }
                                    else if (brd.getbcolor(i, j) == 1)
                                    {
                                        //pb[i, j].Image = img30;
                                    }
                                    Com = true;
                                }
                                else if (kg.move(brd, i, j) == 2)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(11, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    //pb[0, 7].Image = null;
                                    //pb[2, 7].Image = img30;
                                    //pb[3, 7].Image = img21;
                                    brd.setSquare(0, 0, 7);
                                    brd.setSquare(0, 4, 7);
                                    brd.setSquare(11, 2, 7);
                                    brd.setSquare(5, 3, 7);
                                    order--;
                                    Com = true;
                                }
                                else if (kg.move(brd, i, j) == 3)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(11, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        cl = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                   // pb[x1, y1].Image = null;
                                    //pb[7, 7].Image = null;
                                   //pb[5, 7].Image = img21;
                                    //pb[6, 7].Image = img30;
                                    brd.setSquare(0, 4, 7);
                                    brd.setSquare(0, 7, 7);
                                    brd.setSquare(7, 5, 7);
                                    brd.setSquare(11, 6, 7);
                                    order--;
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                            case 12:
                                Pawn p2 = new Pawn(2, x1, y1);
                                if (p2.move(brd, i, j) == 1)
                                {
                                    b.setSquare(0, x1, y1);
                                    b.setSquare(12, i, j);
                                    if (king2.isChecked(b) == 1)
                                    {
                                        cl = 0;
                                        //this.//pb[x1, y1].BorderStyle = 0;
                                        //MessageBox.Show("شما نمی توانید این حرکت را انجام دهید");
                                        return 0;
                                    }
                                    if (j == 0 && CoPermit)
                                    {
                                        //InitConv(y1);
                                        System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(WaitCon));
                                        t.Start();
                                        t.Join();
                                        if (ConClick == 1)
                                        {
                                            brd.setSquare(0, x1, y1);
                                            brd.setSquare(9, i, j);
                                        }
                                        else
                                         if (ConClick == 2)
                                        {
                                            brd.setSquare(0, x1, y1);
                                            brd.setSquare(7, i, j);
                                        }
                                        else
                                        if (ConClick == 3)
                                        {
                                            brd.setSquare(0, x1, y1);
                                            brd.setSquare(9, i, j);
                                        }
                                        else
                                        if (ConClick == 4)
                                        {
                                            brd.setSquare(0, x1, y1);
                                            brd.setSquare(10, i, j);
                                        }

                                    }
                                    else
                                    {
                                       // pb[x1, y1].Image = null;
                                        brd.setSquare(0, x1, y1);
                                        brd.setSquare(12, i, j);
                                    }
                                    order--;
                                    if (ConClick != -1)
                                    {
                                        if (ConClick == 1)
                                        {
                                            if (brd.getbcolor(i, j) == 2)
                                            {
                                                //pb[i, j].Image = img27;
                                            }
                                            else if (brd.getbcolor(i, j) == 1)
                                            {
                                                //pb[i, j].Image = img28;
                                            }
                                        }
                                        else
                                               if (ConClick == 2)
                                        {
                                            if (brd.getbcolor(i, j) == 2)
                                            {
                                                //pb[i, j].Image = img21;
                                            }
                                            else if (brd.getbcolor(i, j) == 1)
                                            {
                                                //pb[i, j].Image = img22;
                                            }
                                        }
                                        else
                                        if (ConClick == 3)
                                        {
                                            if (brd.getbcolor(i, j) == 2)
                                            {
                                                //pb[i, j].Image = img23;
                                            }
                                            else if (brd.getbcolor(i, j) == 1)
                                            {
                                                //pb[i, j].Image = img24;
                                            }
                                        }
                                        else
                                        if (ConClick == 4)
                                        {
                                            if (brd.getbcolor(i, j) == 2)
                                            {
                                                //pb[i, j].Image = img25;
                                            }
                                            else if (brd.getbcolor(i, j) == 1)
                                            {
                                                //pb[i, j].Image = img26;
                                            }
                                        }
                                        ConClick = -1;
                                        //DisposeConv();
                                    }
                                    else
                                    {
                                        if (brd.getbcolor(i, j) == 2)
                                        {
                                            //pb[i, j].Image = img31;
                                        }
                                        else if (brd.getbcolor(i, j) == 1)
                                        {
                                            //pb[i, j].Image = img32;
                                        }
                                    }
                                    Com = true;
                                }
                                else
                                {
                                    cl = 0;
                                    //pb[x1, y1].BorderStyle = 0;
                                    return 0;
                                }
                                break;
                        }
                        RefrigtzChessPortable.ThinkingRefrigtzChessPortable.TableInitiationPreventionOfMultipleMove[x1, y1]++;
                        RefrigtzChessPortable.ThinkingRefrigtzChessPortable.TableInitiationPreventionOfMultipleMove[i, j]++;
                        
                        //this.//pb[x1, y1].BorderStyle = 0;
                        cl = 0;
                       
                        King king = new King(order, x1, y1);
                        
                        if (king.isChecked(brd) == 1)
                        {
                            if (brd.isMated(order) == 1)
                            {
                              }
                            else
                            {
                                Object oo = new Object();
                                lock (oo)
                                {
                                    if (Com && (order == 1))
                                    {
                                        MovmentsNumber++;
                                        
                                        
                                        Table = brd.GetTable();
                                        ClearTableInitiationPreventionOfMultipleMove();
                                        RefrigtzChessPortable.AllDraw.TableListAction.Add(CloneATable(brd.GetTable()));

                                        AllDraw.OrderPlate = OrderPlate;
                                        int Ord = OrderPlate;
                                        int aa = 1;
                                        if (Ord == -1)
                                            aa = -1;
                                        bool B = AllDraw.Blitz;
                                        AllDraw.Blitz = false;
                                        RefrigtzChessPortable.AllDraw.MaxAStarGreedy = AllDraw.PlatformHelperProcessorCount;

                                        AllDraw thiB = Draw.AStarGreedyString;
                                        if (Draw.IsAtLeastAllObjectIsNull())
                                        {
                                            Draw.TableList.Clear();
                                            Draw.TableList.Add(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]));
                                            Draw.SetRowColumn(0);
                                            Draw.IsCurrentDraw = true;
                                        }
                                        Draw.AStarGreedyString = thiB;

                                        Draw.InitiateAStarGreedyt(RefrigtzChessPortable.AllDraw.MaxAStarGreedy, 0, 0, aa, CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]), Ord, false, FOUND, 0);

                                        AllDraw.Blitz = B;
                                          
                                        System.Threading.Thread tt = new System.Threading.Thread(new System.Threading.ThreadStart(SetDrawFound));
                                        tt.Start();
                                        tt.Join();
                                        tt.Abort();
                                        AllDraw.OrderPlate = -1; OrderPlate = -1;



                                        Play(-1, -1);
                                        
                                        
                                        
                                    }
                                    else
                              if (Com && (order == 2))
                                    {
                                        MovmentsNumber++;
                                        Table = brd.GetTable();
                                        ClearTableInitiationPreventionOfMultipleMove();

                                        System.Threading.Thread tt = new System.Threading.Thread(new System.Threading.ThreadStart(SetDrawFound));
                                        tt.Start();
                                        tt.Join();
                                        tt.Abort();
                                        AllDraw.OrderPlate = 1; OrderPlate = 1;




                                    }
                                }
                            }
                        }
                        else
                        {
                           //this.lb.Items.AddRange(new object[] { lstr });
                        }
                        Object oi = new Object();
                        lock (oi)
                        {
                            if (Com && (order == 1))
                            {
                                MovmentsNumber++;
                                
                               
                                Table = brd.GetTable();
                                ClearTableInitiationPreventionOfMultipleMove();
                                RefrigtzChessPortable.AllDraw.TableListAction.Add(CloneATable(brd.GetTable()));


                                AllDraw.OrderPlate = OrderPlate;
                                int Ord = OrderPlate;
                                int aa = 1;
                                if (Ord == -1)
                                    aa = -1;
                                bool B = AllDraw.Blitz;
                                AllDraw.Blitz = false;
                                RefrigtzChessPortable.AllDraw.MaxAStarGreedy = AllDraw.PlatformHelperProcessorCount;

                                AllDraw thiB = Draw.AStarGreedyString;
                                if (Draw.IsAtLeastAllObjectIsNull())
                                {
                                    Draw.TableList.Clear();
                                    Draw.TableList.Add(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]));
                                    Draw.SetRowColumn(0);
                                    Draw.IsCurrentDraw = true;
                                }
                                Draw.AStarGreedyString = thiB;

                                Draw.InitiateAStarGreedyt(RefrigtzChessPortable.AllDraw.MaxAStarGreedy, 0, 0, aa, CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]), Ord, false, FOUND, 0);



                                AllDraw.Blitz = B;
                                
                                System.Threading.Thread tt = new System.Threading.Thread(new System.Threading.ThreadStart(SetDrawFound));
                                tt.Start();
                                tt.Join();
                                tt.Abort();

                                AllDraw.OrderPlate = -1; OrderPlate = -1;


                                Play(-1, -1);
                                
                                
                                
                            }
                            else
                              if (Com && (order == 2))
                            {
                                Table = brd.GetTable();
                                MovmentsNumber++;
                                ClearTableInitiationPreventionOfMultipleMove();

                                System.Threading.Thread tt = new System.Threading.Thread(new System.Threading.ThreadStart(SetDrawFound));
                                tt.Start();
                                tt.Join();
                                tt.Abort();
                                AllDraw.OrderPlate = 1; OrderPlate = 1;
                            }
                        }
                        return 1;
                    }
                }
                catch (Exception t) {  Log(t); }
                return 0;
            }
        }
        
        #region These are the Click events for Picture Boxes in the form
        private void Con1_Click1(object sender, System.EventArgs e)
        {
            ConClick = 1;
        }
        private void Con2_Click1(object sender, System.EventArgs e)
        {
            ConClick = 2;
        }
        private void Con3_Click1(object sender, System.EventArgs e)
        {
            ConClick = 3;
        }
        private void Con4_Click1(object sender, System.EventArgs e)
        {
            ConClick = 4;
        }
        private void Pb_Click1(object sender, System.EventArgs e)
        {
            Play(0, 0);
        }
        private void Pb_Click2(object sender, System.EventArgs e)
        {
            Play(1, 0);
        }
        private void Pb_Click3(object sender, System.EventArgs e)
        {
            Play(2, 0);
        }
        private void Pb_Click4(object sender, System.EventArgs e)
        {
            Play(3, 0);
        }
        private void Pb_Click5(object sender, System.EventArgs e)
        {
            Play(4, 0);
        }
        private void Pb_Click6(object sender, System.EventArgs e)
        {
            Play(5, 0);
        }
        private void Pb_Click7(object sender, System.EventArgs e)
        {
            Play(6, 0);
        }
        private void Pb_Click8(object sender, System.EventArgs e)
        {
            Play(7, 0);
        }
        private void Pb_Click9(object sender, System.EventArgs e)
        {
            Play(0, 1);
        }
        private void Pb_Click10(object sender, System.EventArgs e)
        {
            Play(1, 1);
        }
        private void Pb_Click11(object sender, System.EventArgs e)
        {
            Play(2, 1);
        }
        private void Pb_Click12(object sender, System.EventArgs e)
        {
            Play(3, 1);
        }
        private void Pb_Click13(object sender, System.EventArgs e)
        {
            Play(4, 1);
        }
        private void Pb_Click14(object sender, System.EventArgs e)
        {
            Play(5, 1);
        }
        private void Pb_Click15(object sender, System.EventArgs e)
        {
            Play(6, 1);
        }
        private void Pb_Click16(object sender, System.EventArgs e)
        {
            Play(7, 1);
        }
        private void Pb_Click17(object sender, System.EventArgs e)
        {
            Play(0, 2);
        }
        private void Pb_Click18(object sender, System.EventArgs e)
        {
            Play(1, 2);
        }
        private void Pb_Click19(object sender, System.EventArgs e)
        {
            Play(2, 2);
        }
        private void Pb_Click20(object sender, System.EventArgs e)
        {
            Play(3, 2);
        }
        private void Pb_Click21(object sender, System.EventArgs e)
        {
            Play(4, 2);
        }

        private void Pb_Click22(object sender, System.EventArgs e)
        {
            Play(5, 2);
        }
        private void Pb_Click23(object sender, System.EventArgs e)
        {
            Play(6, 2);
        }
        private void Pb_Click24(object sender, System.EventArgs e)
        {
            Play(7, 2);
        }
        private void Pb_Click25(object sender, System.EventArgs e)
        {
            Play(0, 3);
        }
        private void Pb_Click26(object sender, System.EventArgs e)
        {
            Play(1, 3);
        }
        private void Pb_Click27(object sender, System.EventArgs e)
        {
            Play(2, 3);
        }
        private void Pb_Click28(object sender, System.EventArgs e)
        {
            Play(3, 3);
        }
        private void Pb_Click29(object sender, System.EventArgs e)
        {
            Play(4, 3);
        }

        private void Pb_Click30(object sender, System.EventArgs e)
        {
            Play(5, 3);
        }
        private void Pb_Click31(object sender, System.EventArgs e)
        {
            Play(6, 3);
        }
        private void Pb_Click32(object sender, System.EventArgs e)
        {
            Play(7, 3);
        }
        private void Pb_Click33(object sender, System.EventArgs e)
        {
            Play(0, 4);
        }
        private void Pb_Click34(object sender, System.EventArgs e)
        {
            Play(1, 4);
        }
        private void Pb_Click35(object sender, System.EventArgs e)
        {
            Play(2, 4);
        }
        private void Pb_Click36(object sender, System.EventArgs e)
        {
            Play(3, 4);
        }
        private void Pb_Click37(object sender, System.EventArgs e)
        {
            Play(4, 4);
        }

        private void Pb_Click38(object sender, System.EventArgs e)
        {
            Play(5, 4);
        }
        private void Pb_Click39(object sender, System.EventArgs e)
        {
            Play(6, 4);
        }
        private void Pb_Click40(object sender, System.EventArgs e)
        {
            Play(7, 4);
        }
        private void Pb_Click41(object sender, System.EventArgs e)
        {
            Play(0, 5);
        }
        private void Pb_Click42(object sender, System.EventArgs e)
        {
            Play(1, 5);
        }
        private void Pb_Click43(object sender, System.EventArgs e)
        {
            Play(2, 5);
        }
        private void Pb_Click44(object sender, System.EventArgs e)
        {
            Play(3, 5);
        }
        private void Pb_Click45(object sender, System.EventArgs e)
        {
            Play(4, 5);
        }

        private void Pb_Click46(object sender, System.EventArgs e)
        {
            Play(5, 5);
        }
        private void Pb_Click47(object sender, System.EventArgs e)
        {
            Play(6, 5);
        }
        private void Pb_Click48(object sender, System.EventArgs e)
        {
            Play(7, 5);
        }
        private void Pb_Click49(object sender, System.EventArgs e)
        {
            Play(0, 6);
        }
        private void Pb_Click50(object sender, System.EventArgs e)
        {
            Play(1, 6);
        }
        private void Pb_Click51(object sender, System.EventArgs e)
        {
            Play(2, 6);
        }
        private void Pb_Click52(object sender, System.EventArgs e)
        {
            Play(3, 6);
        }
        private void Pb_Click53(object sender, System.EventArgs e)
        {
            Play(4, 6);
        }

        private void Pb_Click54(object sender, System.EventArgs e)
        {
            Play(5, 6);
        }
        private void Pb_Click55(object sender, System.EventArgs e)
        {
            Play(6, 6);
        }
        private void Pb_Click56(object sender, System.EventArgs e)
        {
            Play(7, 6);
        }
        private void Pb_Click57(object sender, System.EventArgs e)
        {
            Play(0, 7);
        }
        private void Pb_Click58(object sender, System.EventArgs e)
        {
            Play(1, 7);
        }
        private void Pb_Click59(object sender, System.EventArgs e)
        {
            Play(2, 7);
        }
        private void Pb_Click60(object sender, System.EventArgs e)
        {
            Play(3, 7);
        }
        private void Pb_Click61(object sender, System.EventArgs e)
        {
            Play(4, 7);
        }
        private void Pb_Click62(object sender, System.EventArgs e)
        {
            Play(5, 7);
        }
        private void Pb_Click63(object sender, System.EventArgs e)
        {
            Play(6, 7);
        }
        private void Pb_Click64(object sender, System.EventArgs e)
        {
            Play(7, 7);
        }
        #endregion
        
       
        public RefrigtzChessPortable.AllDraw RootFound()
        {
            Object O = new Object();
            lock (O)
            {
                try
                {
                    if (Draw != null)
                    {
                        while (Draw.AStarGreedyString != null)
                        {
                            Draw = Draw.AStarGreedyString;
                        }
                    }
                }
                catch (Exception t) {  Log(t); }
                return Draw;
            }
        }
        public void SetDrawFounding(ref bool FOUNDI, ref RefrigtzChessPortable.AllDraw THISI, bool FirstI)
        {
            /*    Object OO = new Object();
                lock (OO)
                {
                    if (Draw == null)
                        return;
                    int Dummy = OrderPlate;

                    RefrigtzChessPortable.AllDraw THISB = Draw.AStarGreedyString;
                    RefrigtzChessPortable.AllDraw THISStore = Draw;
                    //while (Draw.AStarGreedyString != null)
                    bool FOUND = false;
                    RefrigtzChessPortable.AllDraw THIS = null;
                    bool First = false;



                    Object O = new Object();
                    lock (O)
                    {
                        FOUND = false;
                        THIS = null;
                        int a = -1;
                        //if (First)

                        //else
                        int Ord = OrderPlate;
                        AllDraw.OrderPlate = Ord;
                        var output = Task.Factory.StartNew(() => Draw.FoundOfCurrentTableNode(CloneATable(Table), Ord, ref THIS, ref FOUND));
                        output.Wait();
                        output.Dispose();
                        if (FOUND)
                        {
                            Draw = THIS;



                            bool LoadTree = true;
                            Ord = OrderPlate;
                            //if (MovmentsNumber > 1)
                            (new TakeRoot()).Save(FOUND, false, this, ref LoadTree, false, false, UsePenaltyRegardMechnisam, false, false, false, AStarGreedyHeuristic, true);

                            Draw.IsCurrentDraw = true;


                        }
                        else
                        {
                            FOUND = false;

                            a = -1;
                            while (Draw.AStarGreedyString != null)
                                Draw = Draw.AStarGreedyString;

                            bool FirstS = false;
                            if ((RefrigtzChessPortable.AllDraw.TableListAction.Count > 2))
                            {
                                Ord = OrderPlate * -1;
                                AllDraw.OrderPlate = Ord;
                                OrderPlate = Ord;

                                int aa = 1;
                                if (Ord == -1)
                                    aa = -1;
                                output = Task.Factory.StartNew(() => Draw.FoundOfCurrentTableNode(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 2]), Ord, ref THIS, ref FOUND));
                                output.Wait();
                                output.Dispose();
                            }
                            else
                            if ((RefrigtzChessPortable.AllDraw.TableListAction.Count >= 1))
                            {
                                output = Task.Factory.StartNew(() => Draw.FoundOfCurrentTableNode(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]), Ord, ref THIS, ref FOUND));
                                output.Wait();
                                output.Dispose();
                                FirstS = true;
                            }


                            if (FOUND)
                            {
                                Draw = THIS;

                                Draw.IsCurrentDraw = true;




                                bool Store = Deeperthandeeper;
                                Deeperthandeeper = false;


                                int aa = 1;
                                if (Ord == -1)
                                    aa = -1;
                                bool B = AllDraw.Blitz;
                                AllDraw.Blitz = false;
                                RefrigtzChessPortable.AllDraw.MaxAStarGreedy = AllDraw.PlatformHelperProcessorCount;

                                if (!FirstS)
                                {

                                    AllDraw thiB = Draw.AStarGreedyString;
                                    if (Draw.IsAtLeastAllObjectIsNull())
                                    {
                                        Draw.TableList.Clear();
                                        Draw.TableList.Add(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 2]));
                                        Draw.SetRowColumn(0);
                                        Draw.IsCurrentDraw = true;
                                    }
                                    Draw.AStarGreedyString = thiB;


                                    output = Task.Factory.StartNew(() => Draw.InitiateAStarGreedyt(RefrigtzChessPortable.AllDraw.MaxAStarGreedy, 0, 0, aa, CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 2]), Ord, false, FOUND, 0));
                                    output.Wait();
                                    output.Dispose();
                                }
                                else
                                {
                                    FOUND = false;

                                    AllDraw thiB = Draw.AStarGreedyString;
                                    if (Draw.IsAtLeastAllObjectIsNull())
                                    {
                                        Draw.TableList.Clear();
                                        Draw.TableList.Add(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]));
                                        Draw.SetRowColumn(0);
                                        Draw.IsCurrentDraw = true;
                                    }
                                    Draw.AStarGreedyString = thiB;


                                    output = Task.Factory.StartNew(() => Draw.InitiateAStarGreedyt(RefrigtzChessPortable.AllDraw.MaxAStarGreedy, 0, 0, aa, CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]), Ord, false, FOUND, 0));
                                    output.Wait();
                                    output.Dispose();
                                }
                                AllDraw.Blitz = B;
                                Deeperthandeeper = Store;
                                //while (Draw.AStarGreedyString != null)

                                FOUND = false;
                                if (!First && (RefrigtzChessPortable.AllDraw.TableListAction.Count > 2))
                                {
                                    Ord = OrderPlate * -1;
                                    AllDraw.OrderPlate = Ord;
                                    OrderPlate = Ord;
                                }
                                output = Task.Factory.StartNew(() => Draw.FoundOfCurrentTableNode(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]), Ord, ref THIS, ref FOUND));
                                output.Wait();
                                output.Dispose();

                                if (FOUND)
                                {
                                    Draw = THIS;





                                    bool LoadTree = true;
                                    (new TakeRoot()).Save(FOUND, false, this, ref LoadTree, false, false, UsePenaltyRegardMechnisam, false, false, false, AStarGreedyHeuristic, true);
                                    AllDraw.OrderPlate = Ord;



                                }
                                else
                                {
                                    Draw = THISStore;
                                    if (MovmentsNumber == 1)
                                        NotFoundBegin = true;

                                    bool LoadTree = true;


                                    Draw.TableList.Clear();
                                    Draw.TableList.Add(CloneATable(Table));
                                    Draw.SetRowColumn(0);
                                    Draw.IsCurrentDraw = true;
                                    Draw.AStarGreedyString = THISB;
                                    RefrigtzChessPortable.ChessRules.CurrentOrder = OrderPlate;
                                    RefrigtzChessPortable.AllDraw.DepthIterative = 0;
                                    (new TakeRoot()).Save(FOUND, false, this, ref LoadTree, false, false, UsePenaltyRegardMechnisam, false, false, false, AStarGreedyHeuristic, true);


                                }
                            }
                            else
                            {
                                Draw = THISStore;
                                if (MovmentsNumber == 1)
                                    NotFoundBegin = true;
                                OrderPlate = Dummy;

                                bool LoadTree = true;


                                Draw.TableList.Clear();
                                Draw.TableList.Add(CloneATable(Table));
                                Draw.SetRowColumn(0);
                                Draw.IsCurrentDraw = true;
                                Draw.AStarGreedyString = THISB;
                                RefrigtzChessPortable.ChessRules.CurrentOrder = OrderPlate;
                                RefrigtzChessPortable.AllDraw.DepthIterative = 0;
                                (new TakeRoot()).Save(FOUND, false, this, ref LoadTree, false, false, UsePenaltyRegardMechnisam, false, false, false, AStarGreedyHeuristic, true);


                            }
                        }
                    }

                    if (RefrigtzChessPortable.AllDraw.FirstTraversalTree)
                        FOUND = false;
                    FOUNDI = FOUND;
                    THISI = THIS;
                    FirstI = First;
                    DrawManagement();
                }
    */

            Object OO = new Object();
            lock (OO)
            {
                if (Draw == null)
                    return;
                int Dummy = OrderPlate;

                RefrigtzChessPortable.AllDraw THISB = Draw.AStarGreedyString;
                RefrigtzChessPortable.AllDraw THISStore = Draw;
                //while (Draw.AStarGreedyString != null)
                bool FOUND = false;
                RefrigtzChessPortable.AllDraw THIS = null;
                bool First = false;



                Object O = new Object();
                lock (O)
                {
                    FOUND = false;
                    THIS = null;
                     //if (First)

                    //else
                    int Ord = OrderPlate;
                    AllDraw.OrderPlate = Ord;
                    var output = Task.Factory.StartNew(() => Draw.FoundOfCurrentTableNode(CloneATable(Table), Ord, ref THIS, ref FOUND));
                    output.Wait();
                    output.Dispose();
                    if (FOUND)
                    {
                        Draw = THIS;



                        bool LoadTree = true;
                        Ord = OrderPlate;
                        //if (MovmentsNumber > 1)
                        (new TakeRoot()).Save(FOUND, false, this, ref LoadTree, false, false, UsePenaltyRegardMechnisam, false, false, false, AStarGreedyHeuristic, true);

                        Draw.IsCurrentDraw = true;


                    }
                    else
                    {
                        bool Store = Deeperthandeeper;
                        Deeperthandeeper = false;


                        int aa = 1;
                        if (Ord == -1)
                            aa = -1;
                        bool B = AllDraw.Blitz;
                        AllDraw.Blitz = false;
                        RefrigtzChessPortable.AllDraw.MaxAStarGreedy = AllDraw.PlatformHelperProcessorCount * 2;

                        FOUND = false;

                        AllDraw thiB = Draw.AStarGreedyString;
                        if (Draw.IsAtLeastAllObjectIsNull())
                        {
                            Draw.TableList.Clear();
                            Draw.TableList.Add(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]));
                            Draw.SetRowColumn(0);
                            Draw.IsCurrentDraw = true;
                        }
                        Draw.AStarGreedyString = thiB;


                        output = Task.Factory.StartNew(() => Draw.InitiateAStarGreedyt(RefrigtzChessPortable.AllDraw.MaxAStarGreedy, 0, 0, aa, CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]), Ord, false, FOUND, 0));
                        output.Wait();
                        output.Dispose();
                        AllDraw.Blitz = B;
                        Deeperthandeeper = Store;
                        //while (Draw.AStarGreedyString != null)

                        FOUND = false;


                        output = Task.Factory.StartNew(() => Draw.FoundOfCurrentTableNode(CloneATable(RefrigtzChessPortable.AllDraw.TableListAction[RefrigtzChessPortable.AllDraw.TableListAction.Count - 1]), Ord, ref THIS, ref FOUND));
                        output.Wait();
                        output.Dispose();

                        if (FOUND)
                        {
                            Draw = THIS;





                            bool LoadTree = true;
                            (new TakeRoot()).Save(FOUND, false, this, ref LoadTree, false, false, UsePenaltyRegardMechnisam, false, false, false, AStarGreedyHeuristic, true);
                            AllDraw.OrderPlate = Ord;



                        }
                        else
                        {
                            Draw = THISStore;
                            if (MovmentsNumber == 1)
                                NotFoundBegin = true;

                            bool LoadTree = true;


                            Draw.TableList.Clear();
                            Draw.TableList.Add(CloneATable(Table));
                            Draw.SetRowColumn(0);
                            Draw.IsCurrentDraw = true;
                            Draw.AStarGreedyString = THISB;
                            RefrigtzChessPortable.ChessRules.CurrentOrder = OrderPlate;
                            RefrigtzChessPortable.AllDraw.DepthIterative = 0;
                            (new TakeRoot()).Save(FOUND, false, this, ref LoadTree, false, false, UsePenaltyRegardMechnisam, false, false, false, AStarGreedyHeuristic, true);


                        }

                    }
                }

                if (RefrigtzChessPortable.AllDraw.FirstTraversalTree)
                    FOUND = false;
                FOUNDI = FOUND;
                THISI = THIS;
                FirstI = First;
                DrawManagement();
            }

        }
        bool DrawManagement()
        {
            Object OO = new Object();
            lock (OO)
            {
                SetAllDrawKind();
                //Set Configuration To True for some unknown reason!.
                
                SetAllDrawKindString();
                bool Found = false;
                String P = Path.GetFullPath(path3);
                AllDrawReplacement = Path.Combine(P, AllDrawKindString);
                Logger y = new Logger(AllDrawReplacement);
                
                y = new Logger(AllDrawKindString);
                
                if (!NotFoundBegin)
                {
                    if (File.Exists(AllDrawKindString))
                    {
                        if (File.Exists(AllDrawReplacement))
                        {
                            if (((new System.IO.FileInfo(AllDrawKindString).Length) < (new System.IO.FileInfo(AllDrawReplacement)).Length))
                            {
                                File.Delete(AllDrawKindString);
                                File.Copy(AllDrawReplacement, AllDrawKindString);
                                Found = true;
                            }
                            else if (((new System.IO.FileInfo(AllDrawKindString).Length) > (new System.IO.FileInfo(AllDrawReplacement)).Length))
                            {
                                if (File.Exists(AllDrawReplacement))
                                    File.Delete(AllDrawReplacement);
                                File.Copy(AllDrawKindString, AllDrawReplacement);
                                Found = true;
                            }
                        }
                        else
                        {
                            if (!Directory.Exists(Path.GetFullPath(path3)))
                                Directory.CreateDirectory(Path.GetFullPath(path3));
                            File.Copy(AllDrawKindString, AllDrawReplacement);
                            Found = true;
                        }
                        Found = true;
                    }
                    else if (File.Exists(AllDrawReplacement))
                    {
                        File.Copy(AllDrawReplacement, AllDrawKindString);
                        Found = true;
                    }
                }
                else
                {
                    if (File.Exists(AllDrawKindString))
                        File.Delete(AllDrawKindString);
                    if (File.Exists(AllDrawReplacement))
                        File.Delete(AllDrawReplacement);
                    NotFoundBegin = false;
                }
                return Found;
            }
        }
        void SetAllDrawKindString()
        {
            Object O = new Object();
            lock (O)
            {
                if (AllDrawKind == 4)
                    AllDrawKindString = "AllDrawBT.asd";
                else
                if (AllDrawKind == 3)
                    AllDrawKindString = "AllDrawFFST.asd";
                else
                if (AllDrawKind == 2)
                    AllDrawKindString = "AllDrawFTSF.asd";
                else
                if (AllDrawKind == 1)
                    AllDrawKindString = "AllDrawFFSF.asd";

            }
        }
        void SetAllDrawKind()
        {
            Object O = new Object();
            lock (O)
            {
                if (UsePenaltyRegardMechnisam && AStarGreedyHeuristic)
                    AllDrawKind = 4;
                else
          if ((!UsePenaltyRegardMechnisam) && AStarGreedyHeuristic)
                    AllDrawKind = 3;
                if (UsePenaltyRegardMechnisam && (!AStarGreedyHeuristic))
                    AllDrawKind = 2;
                if ((!UsePenaltyRegardMechnisam) && (!AStarGreedyHeuristic))
                    AllDrawKind = 1;
            }
        }
        void SetDrawFound()
        {
            Object O = new Object();
            lock (O)
            {
                FOUND = false;
                RefrigtzChessPortable.AllDraw THIS = null;
                SetDrawFounding(ref FOUND, ref THIS, false);
            }
        }
    }
}
