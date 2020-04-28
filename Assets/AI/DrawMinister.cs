using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Drawing;
using System.IO;
namespace RefrigtzChessPortable
{
    [Serializable]
    public class DrawMinister//:DrawKing
    {
        

        StringBuilder Space = new StringBuilder("&nbsp;");
//// The field 'DrawMinister.Spaces' is assigned but its value is never used
// The field 'DrawMinister.Spaces' is assigned but its value is never used
        
 // The field 'DrawMinister.Spaces' is assigned but its value is never used
// // The field 'DrawMinister.Spaces' is assigned but its value is never used



        public int WinOcuuredatChiled = 0; public int[] LoseOcuuredatChiled = { 0, 0, 0 };
        
        
        
        //Initiate Global Variable.
        List<int[]> ValuableSelfSupported = new List<int[]>();

        public bool MovementsAStarGreedyHeuristicFoundT = false;
        public bool IgnoreSelfobjectsT = false;
        public bool UsePenaltyRegardMechnisamT = true;
        public bool BestMovmentsT = false;
        public bool PredictHeuristicT = true;
        public bool OnlySelfT = false;
        public bool AStarGreedyHeuristicT = false;

        public bool ArrangmentsChanged = true;
        public static long MaxHeuristicxM = -20000000000000000;
        public float Row, Column;
        public int color;
        public int[,] Table = null;
        public int Current = 0;
        public int Order;
        public ThinkingRefrigtzChessPortable[] MinisterThinking = new ThinkingRefrigtzChessPortable[AllDraw.MinisterMovments];
        int CurrentAStarGredyMax = -1;
        static void Log(Exception ex)
        {

            try
            {
                object a = new object();
                lock (a)
                {
                    string stackTrace = ex.ToString();
                    //Write to File.
                     File.AppendAllText(AllDraw.Root + "\\ErrorProgramRun.txt",  ": On" + DateTime.Now.ToString());

                }
            }

            catch (Exception t) { /*Log(t);*/ }

        }
        public void Dispose()
        {
            
            ValuableSelfSupported = null;
            
        }

        public bool MaxFound(ref bool MaxNotFound)
        {
            
            int a = ReturnHeuristic();
            if (MaxHeuristicxM < a)
            {
                object O2 = new object();
                lock (O2)
                {
                    MaxNotFound = false;
                    if (ThinkingRefrigtzChessPortable.MaxHeuristicx < MaxHeuristicxM)
                        ThinkingRefrigtzChessPortable.MaxHeuristicx = a;
                    MaxHeuristicxM = a;
                }
                
                return true;
            }

            MaxNotFound = true;
            
            return false;
        }
        public int ReturnHeuristic()
        {
            int HaveKilled = 0;
            
            int a = 0;
            for (var ii = 0; ii < AllDraw.MinisterMovments; ii++)

                a += MinisterThinking[ii].ReturnHeuristic(-1, -1, Order, false,ref HaveKilled);
            
            return a;
        }
        //constructor 1.
        
        //Constructor 2.
        public DrawMinister(int CurrentAStarGredy, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments, float i, float j, int a, int[,] Tab, int Ord, bool TB, int Cur//, ref AllDraw. THIS
            )
        {
            
            object balancelock = new object();
            lock (balancelock)
            {

                CurrentAStarGredyMax = CurrentAStarGredy;
                MovementsAStarGreedyHeuristicFoundT = MovementsAStarGreedyHeuristicTFou;
                IgnoreSelfobjectsT = IgnoreSelfObject;
                UsePenaltyRegardMechnisamT = UsePenaltyRegardMechnisa;
                BestMovmentsT = BestMovment;
                PredictHeuristicT = PredictHurist;
                OnlySelfT = OnlySel;
                AStarGreedyHeuristicT = AStarGreedyHuris;
                ArrangmentsChanged = Arrangments;
                //Initiate Global Variables.
                Table = new int[8, 8];
                for (var ii = 0; ii < 8; ii++)
                    for (var jj = 0; jj < 8; jj++)
                        Table[ii, jj] = Tab[ii, jj];
                for (var ii = 0; ii < AllDraw.MinisterMovments; ii++)
                    MinisterThinking[ii] = new ThinkingRefrigtzChessPortable(ii,5,CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)i, (int)j, a, CloneATable(Tab), 32, Ord, TB, Cur, 2, 5);

                Row = i;
                Column = j;
                color =a;
                Current = Cur;
                Order = Ord;
            }
            
        }
        int[,] CloneATable(int[,] Tab)
        {
            
            object O = new object();
            lock (O)
            {
                //Create and new an object.
                int[,] Table = new int[8, 8];
                //Assigne Parameter To New objects.
                for (var i = 0; i < 8; i++)
                    for (var j = 0; j < 8; j++)
                        Table[i, j] = Tab[i, j];
                //Return New object.
                
                return Table;
            }

        }
        bool[,] CloneATable(bool[,] Tab)
        {
            
            object O = new object();
            lock (O)
            {
                //Create and new an object.
                bool[,] Table = new bool[8, 8];
                //Assigne Parameter To New objects.
                for (var i = 0; i < 8; i++)
                    for (var j = 0; j < 8; j++)
                        Table[i, j] = Tab[i, j];
                //Return New object.
                
                return Table;
            }

        }
        //Clone a Copy.
        public void Clone(ref DrawMinister AA//, ref AllDraw. THIS
            )
        {
            
            int[,] Tab = new int[8, 8];
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    Tab[i, j] = this.Table[i, j];
            //Initiate an object and Clone a Construction objectve.
            AA = new DrawMinister(CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, Row, Column, this.color, this.CloneATable(Table), this.Order, false, this.Current);
            AA.ArrangmentsChanged = ArrangmentsChanged;
            for (var i = 0; i < AllDraw.MinisterMovments; i++)
            {

                AA.MinisterThinking[i] = new ThinkingRefrigtzChessPortable(i,5,CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)this.Row, (int)this.Column);
                this.MinisterThinking[i].Clone(ref AA.MinisterThinking[i]);


            }
            AA.Table = new int[8, 8];
            for (var ii = 0; ii < 8; ii++)
                for (var jj = 0; jj < 8; jj++)
                    AA.Table[ii, jj] = Tab[ii, jj];
            AA.Row = Row;
            AA.Column = Column;
            AA.Order = Order;
            AA.Current = Current;
            AA.color=color;
            
        }
        //Draw an Mnister on the Table.
       
    }
}

//End of Documentation.
