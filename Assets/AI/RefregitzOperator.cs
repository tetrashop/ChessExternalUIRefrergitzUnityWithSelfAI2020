/**************************************************************************************************************
 * Ramin Edjlal Copyright 1397/04/20 **************************************************************************
 * 1397/04/26:Problem in Seirlization Recurisvely of linked list for refrigitz.********************************
 * ************************************************************************************************************
 */using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine;


namespace GalleryStudio
{
    [Serializable]
    public class RefregitzOperator//:RefregizMemmory
    {
        public static int AllDrawKind = 0;//0,1,2,3,4,5,6
        public static String AllDrawKindString = "";


        public bool MovementsAStarGreedyHeuristicFoundT = false;
        public bool IgnoreSelfobjectsT = false;
        public bool UsePenaltyRegardMechnisamT = true;
        public bool BestMovmentsT = false;
        public bool PredictHeuristicT = true;
        public bool OnlySelfT = false;
        public bool AStarGreedyHeuristicT = false;
        public bool ArrangmentsT = false;
		public static String Root =  GameManager.Root;//System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

        string SAllDraw ="";
        //static GalleryStudio.RefregizMemmory Node;
        //RefrigtzChessPortable.AllDraw Current = null;
        //GalleryStudio.RefregizMemmory Next = null;
        //int Kind = -1;
        static void Log(Exception ex)
        {
            
                object a = new object();
                lock (a)
                {
                    string stackTrace = ex.ToString();
                    File.AppendAllText(Root + "\\ErrorProgramRun.txt",  ": On" + DateTime.Now.ToString()); // path of file where stack trace will be stored.
                }
           
        }
        void SetAllDrawKindString()
        {
            if (AllDrawKind == 4)
                AllDrawKindString = "AllDrawBT.asd";//Both True
            else
                if (AllDrawKind == 3)
                AllDrawKindString = "AllDrawFFST.asd";//First false second true
            else
                if (AllDrawKind == 2)
                AllDrawKindString = "AllDrawFTSF.asd";//First true second false
            else
                if (AllDrawKind == 1)
                AllDrawKindString = "AllDrawFFSF.asd";//Fist false second false


        }
        public RefregitzOperator(int Order, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments//) : base(MovementsAStarGreedyHeuristicTFou, IgnoreSelfObject, UsePenaltyRegardMechnisa, BestMovment, PredictHurist, OnlySel, AStarGreedyHuris, Arrangments
            )
        {
            if (UsePenaltyRegardMechnisamT && AStarGreedyHeuristicT)
                AllDrawKind = 4;
            else
                                            if ((!UsePenaltyRegardMechnisamT) && AStarGreedyHeuristicT)
                AllDrawKind = 3;
            if (UsePenaltyRegardMechnisamT && (!AStarGreedyHeuristicT))
                AllDrawKind = 2;
            if ((!UsePenaltyRegardMechnisamT) && (!AStarGreedyHeuristicT))
                AllDrawKind = 1;
            //Set Configuration To True for some unknown reason!.
            //UpdateConfigurationTableVal = true;                             
            SetAllDrawKindString();
            SAllDraw = AllDrawKindString;
            object o = new object();
            lock (o)
            {
                MovementsAStarGreedyHeuristicFoundT = MovementsAStarGreedyHeuristicTFou;
                IgnoreSelfobjectsT = IgnoreSelfObject;
                UsePenaltyRegardMechnisamT = UsePenaltyRegardMechnisa;
                BestMovmentsT = BestMovment;
                PredictHeuristicT = PredictHurist;
                OnlySelfT = OnlySel;
                AStarGreedyHeuristicT = AStarGreedyHuris;
                ArrangmentsT = Arrangments;
                RefrigtzChessPortable.AllDraw Current = new RefrigtzChessPortable.AllDraw(Order, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsT);
            }
        }


        public RefrigtzChessPortable.AllDraw GetRefregiz(int No)
        {
            object o = new object();
            lock (o)
            {

                FileStream DummyFileStream = null;
                DummyFileStream = new FileStream(SAllDraw, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
                int p = 0;
                RefrigtzChessPortable.AllDraw Dummy = null;
                BinaryFormatter Formatters = new BinaryFormatter();
                DummyFileStream.Seek(0, SeekOrigin.Begin);
                
                    while (p <= No)
                    {
                        if (DummyFileStream.Length >= DummyFileStream.Position)
                            Dummy = (RefrigtzChessPortable.AllDraw)Formatters.Deserialize(DummyFileStream);
                        else
                            Dummy = null;
                        p++;
                    }
                    DummyFileStream.Flush(); DummyFileStream.Close();
               
                return Dummy;
            }
        }

    }
}
