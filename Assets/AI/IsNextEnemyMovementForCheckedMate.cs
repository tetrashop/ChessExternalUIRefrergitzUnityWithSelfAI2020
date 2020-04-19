using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Drawing;
using System.Threading.Tasks;

namespace RefrigtzChessPortable
{
    class IsNextEnemyMovementForCheckedMate:AllDraw
    {
       
        StringBuilder Space = new StringBuilder("&nbsp;");
//

        

//

        int[,] TableIsNextEnemyMovementForCheckedMate = new int[8, 8];
        public IsNextEnemyMovementForCheckedMate(int Order, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments,int[,] Tab)
            : base(Order, MovementsAStarGreedyHeuristicTFou, IgnoreSelfObject, UsePenaltyRegardMechnisa, BestMovment, PredictHurist, OnlySel, AStarGreedyHuris, Arrangments)
        {
            //long Time = TimeElapced.TimeNow();Spaces++;
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    TableIsNextEnemyMovementForCheckedMate[i, j] = Tab[i, j];
            ////{ //AllDraw.OutPut.Append("\r\n");for (int l = 0; l < Spaces; l++) //AllDraw.OutPut.Append(Space);  //AllDraw.OutPut.Append("IsNextEnemyMovementForCheckedMate:" + (TimeElapced.TimeNow() - Time).ToString());}
        }
        public IsNextEnemyMovementForCheckedMate(int Order, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments, AllDraw THi,int[,] Tab)
            : base(Order, MovementsAStarGreedyHeuristicTFou, IgnoreSelfObject, UsePenaltyRegardMechnisa, BestMovment, PredictHurist, OnlySel, AStarGreedyHuris, Arrangments, THi)
        {
            //long Time = TimeElapced.TimeNow();Spaces++;
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    TableIsNextEnemyMovementForCheckedMate[i, j] = Tab[i, j];
            ////{ //AllDraw.OutPut.Append("\r\n");for (int l = 0; l < Spaces; l++) //AllDraw.OutPut.Append(Space);  //AllDraw.OutPut.Append("IsNextEnemyMovementForCheckedMate:" + (TimeElapced.TimeNow() - Time).ToString());}
        }
        public bool Is()
        {
            //long Time = TimeElapced.TimeNow();Spaces++;
            bool IS= false;
            int a = 1;
            if (OrderP== -1)
                a = -1;
            String A1 = AllDraw.ActionString.ToString();
            bool A2 = AllDraw.ActionStringReady;
            bool A3 = AllDraw.AStarGreadyFirstSearch;
            int A4 = AllDraw.AStarGreedyiLevelMax;
            int A5 = AllDraw.AStarGreedytMaxCount;
            bool A6 = AllDraw.Blitz;
            int A7 = AllDraw.CastleMovments;
            int A8 = AllDraw.ConvertedKind;
            bool A9 = AllDraw.ConvertWait;
            int A10 = AllDraw.CurrentHeuristic;
            int A11 = AllDraw.DepthIterative;
            bool A12 = AllDraw.DrawTable;
            bool A13 = AllDraw.DynamicAStarGreedytPrograming;
            int A14 = AllDraw.ElefantMovments;
            bool A15 = AllDraw.EndOfGame;
            bool A16 = AllDraw.FoundATable;
            int A17 = AllDraw.HourseMovments;
            String A18 = AllDraw.ImageRoot;
            String A19 = AllDraw.ImagesSubRoot;
            int A20 = AllDraw.increasedProgress;
            int A21 = AllDraw.KingMovments;
            int A22 = AllDraw.LastColumn;
            int A23 = AllDraw.LastRow;
            int A24 = AllDraw.Less;
            int A25 = AllDraw.LoopHeuristicIndex;
            int A26 = AllDraw.MaxAStarGreedy;
            int A27 = AllDraw.MaxAStarGreedyHeuristicProgress;
            int A28 = AllDraw.MinisterMovments;
            int A29 = AllDraw.MinThinkingTreeDepth;
            int A30 = AllDraw.MouseClick;
            int A31 = AllDraw.MovmentsNumber;
            int A32 = AllDraw.NextColumn;
            int A33 = AllDraw.NextRow;
            bool A34 = AllDraw.NoTableFound;
            int A35 = AllDraw.OrderPlate;
            String A36 = AllDraw.OutPut.ToString();
            bool A37 = AllDraw.Person;
            bool A38 = AllDraw.RedrawTable;
            bool A39 = AllDraw.RegardOccurred;
            String A40 = AllDraw.Root;
            int A41 = AllDraw.SignAttack;
            int A42 = AllDraw.SignDistance;
            int A43 = AllDraw.SignKiller;
            int A44 = AllDraw.SignKingDangour;
            int A45 = AllDraw.SignKingSafe;
            int A46 = AllDraw.SignMovments;
            int A47 = AllDraw.SignObjectDangour;
            int A48 = AllDraw.SignReducedAttacked;
            int A49 = AllDraw.SignSupport;
            bool A50 = AllDraw.SodierConversionOcuured;
            int A51 = AllDraw.SodierMovments;
            bool A52 = AllDraw.StateCP;
            bool A53 = AllDraw.Stockfish;
            List<AllDraw> A54 = new List<AllDraw>();
            for (var i = 0; i < AllDraw.StoreADraw.Count; i++)
                A54.Add(AllDraw.StoreADraw[i]);
            List<int> A55 = new List<int>();
            for (var i = 0; i < AllDraw.StoreADrawAStarGreedy.Count; i++)
                A55.Add(AllDraw.StoreADrawAStarGreedy[i]);
            int A56 = AllDraw.SuppportCountStaticBrown;
            int A57 = AllDraw.SuppportCountStaticGray;
            String A58 = AllDraw.SyntaxToWrite;
            List<int[,]> A59 = new List<int[,]>();
            for (var i = 0; i < AllDraw.TableCurrent.Count; i++)
                A59.Add(AllDraw.TableCurrent[i]);
            List<int[,]> A60 = new List<int[,]>();
            for (var i = 0; i < AllDraw.TableListAction.Count; i++)
                A60.Add(AllDraw.TableListAction[i]);
            int[,] A61 = new int[8, 8];
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    A61[i, j] = AllDraw.TableVeryfy[i, j];
            int[,] A62 = new int[8, 8];
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    A62[i, j] = AllDraw.TableVeryfyConst[i, j];
            int A63 = AllDraw.TaskBegin;
            int A64 = AllDraw.TaskEnd;
            String A65 = AllDraw.THIScomboBoxMaxLevelText;
            AllDraw A66 = null;
            if (AllDraw.THISDummy != null)
                AllDraw.THISDummy.Clone(A66);
            bool A67 = AllDraw.THISSecradioButtonBrownOrderChecked;
            bool A68 = AllDraw.THISSecradioButtonGrayOrderChecked;
            bool A69 = AllDraw.UseDoubleTime;
            String B1 = ThinkingRefrigtzChessPortable.ActionsString;
            int B2 = ThinkingRefrigtzChessPortable.BeginThread;
            int B3 = ThinkingRefrigtzChessPortable.EndThread;
            int B4 = ThinkingRefrigtzChessPortable.FoundFirstMating;
            int B5 = ThinkingRefrigtzChessPortable.FoundFirstSelfMating;
            bool B6 = ThinkingRefrigtzChessPortable.KingMaovableBrown;
            bool B7 = ThinkingRefrigtzChessPortable.KingMaovableGray;
            bool B8 = ThinkingRefrigtzChessPortable.LearningVarsCheckedMateOccured;
            bool B9 = ThinkingRefrigtzChessPortable.LearningVarsCheckedMateOccuredOneCheckedMate;
            int B10 = ThinkingRefrigtzChessPortable.MaxHeuristicx;
            bool B11 = ThinkingRefrigtzChessPortable.NotSolvedKingDanger;
            int B12 = ThinkingRefrigtzChessPortable.NumbersOfAllNode;
            bool B13 = ThinkingRefrigtzChessPortable.ThinkingRun;





            AllDraw.Blitz = false;

            MaxAStarGreedy = 1;
            int[,] tab = Initiate(0, 0, a, TableIsNextEnemyMovementForCheckedMate, OrderP, false, false, 0, true);
            if (ThinkingRefrigtzChessPortable.FoundFirstSelfMating > 0)
                IS = true;

            AllDraw.ActionString =new StringBuilder(A1);
            AllDraw.ActionStringReady= A2;
             AllDraw.AStarGreadyFirstSearch= A3 ;
            AllDraw.AStarGreedyiLevelMax = A4;
            AllDraw.AStarGreedytMaxCount = A5;
            AllDraw.Blitz = A6;
            AllDraw.CastleMovments = A7;
             AllDraw.ConvertedKind= A8 ;
             AllDraw.ConvertWait = A9 ;
             AllDraw.CurrentHeuristic= A10 ;
             AllDraw.DepthIterative = A11 ;
             AllDraw.DrawTable = A12 ;
             AllDraw.DynamicAStarGreedytPrograming =A13 ;
             AllDraw.ElefantMovments = A14 ;
             AllDraw.EndOfGame= A15 ;
             AllDraw.FoundATable = A16 ;
            AllDraw.HourseMovments = A17 ;
             AllDraw.ImageRoot = A18 ;
             AllDraw.ImagesSubRoot= A19 ;
             AllDraw.increasedProgress = A20;
             AllDraw.KingMovments= A21;
             AllDraw.LastColumn = A22;
             AllDraw.LastRow = A23;
             AllDraw.Less = A24;
             AllDraw.LoopHeuristicIndex = A25;
             AllDraw.MaxAStarGreedy = A26;
             AllDraw.MaxAStarGreedyHeuristicProgress = A27;//AllDraw.MouseClick = A30;
             AllDraw.MinisterMovments = A28;
             AllDraw.MinThinkingTreeDepth = A29;
             //AllDraw.MouseClick = A30;
             AllDraw.MovmentsNumber = A31;
             AllDraw.NextColumn = A32;
             AllDraw.NextRow = A33;
             AllDraw.NoTableFound = A34;
             AllDraw.OrderPlate = A35;
             //AllDraw.OutPut.Append(A36);
             AllDraw.Person = A37;
             AllDraw.RedrawTable = A38;
             AllDraw.RegardOccurred = A39;
             AllDraw.Root = A40;
            AllDraw.SignAttack = A41;
             AllDraw.SignDistance =A42;
             AllDraw.SignKiller = A43;
             AllDraw.SignKingDangour = A44;
             AllDraw.SignKingSafe= A45;
             AllDraw.SignMovments = A46;
             AllDraw.SignObjectDangour = A47;
            AllDraw.SignReducedAttacked = A48;
             AllDraw.SignSupport= A49;
            AllDraw.SodierConversionOcuured = A50;
             AllDraw.SodierMovments = A51;
             AllDraw.StateCP = A52;
            AllDraw.Stockfish = A53;
            AllDraw.StoreADraw.Clear();
            for (var i = 0; i < AllDraw.StoreADraw.Count; i++)
                AllDraw.StoreADraw.Add(A54[i]);
            AllDraw.StoreADrawAStarGreedy.Clear();
            for (var i = 0; i < AllDraw.StoreADrawAStarGreedy.Count; i++)
                AllDraw.StoreADrawAStarGreedy.Add(A55[i]);
             AllDraw.SuppportCountStaticBrown= A56;
             AllDraw.SuppportCountStaticGray= A57;
            AllDraw.SyntaxToWrite = A58;
            AllDraw.TableCurrent.Clear();
            for (var i = 0; i < AllDraw.TableCurrent.Count; i++)
                AllDraw.TableCurrent.Add(A59[i]);
            AllDraw.TableListAction.Clear();
            for (var i = 0; i < AllDraw.TableListAction.Count; i++)
                AllDraw.TableListAction.Add(A60[i]);
            
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    AllDraw.TableVeryfy[i, j] = A61[i, j];
            
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    AllDraw.TableVeryfyConst[i, j] = A62[i, j];
             AllDraw.TaskBegin= A63;
             AllDraw.TaskEnd= A64;
             AllDraw.THIScomboBoxMaxLevelText= A65;
            if (A66 != null)
                A66.Clone(AllDraw.THISDummy);
             AllDraw.THISSecradioButtonBrownOrderChecked= A67;
             AllDraw.THISSecradioButtonGrayOrderChecked= A68;
             AllDraw.UseDoubleTime= A69;
             ThinkingRefrigtzChessPortable.ActionsString= B1;
             ThinkingRefrigtzChessPortable.BeginThread = B2;
             ThinkingRefrigtzChessPortable.EndThread = B3;
             ThinkingRefrigtzChessPortable.FoundFirstMating = B4;
             ThinkingRefrigtzChessPortable.FoundFirstSelfMating = B5;
             ThinkingRefrigtzChessPortable.KingMaovableBrown = B6;
             ThinkingRefrigtzChessPortable.KingMaovableGray = B7;
             ThinkingRefrigtzChessPortable.LearningVarsCheckedMateOccured = B8;
             ThinkingRefrigtzChessPortable.LearningVarsCheckedMateOccuredOneCheckedMate = B9;
             ThinkingRefrigtzChessPortable.MaxHeuristicx = B10;
             ThinkingRefrigtzChessPortable.NotSolvedKingDanger =B11;
             ThinkingRefrigtzChessPortable.NumbersOfAllNode = B12;
             ThinkingRefrigtzChessPortable.ThinkingRun = B13;
            ////{ //AllDraw.OutPut.Append("\r\n");for (int l = 0; l < Spaces; l++) //AllDraw.OutPut.Append(Space);  //AllDraw.OutPut.Append("Is:" + (TimeElapced.TimeNow() - Time).ToString());}
            return IS;
        }
    }
}
