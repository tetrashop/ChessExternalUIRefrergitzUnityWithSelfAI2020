using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using RefrigtzChessPortable;
using System.Diagnostics;

namespace RefrigtzChessPortable
{
    [Serializable]
    public class TakeRoot
    {
        //bool WaitOnplay = false;

         String path3 = @"temp";
        String AllDrawReplacement = "";

        public static int AllDrawKind = 0;//0,1,2,3,4,5,6
        public static String AllDrawKindString = "";

        public RefrigtzChessPortable.AllDraw t = null;
        //public QuantumRefrigiz.AllDraw tt = null;

        static void Log(Exception ex)
        {
            try
            {
                Object a = new Object();
                lock (a)
                {
                    string stackTrace = ex.ToString();
                    File.AppendAllText(RefrigtzChessPortableForm.Root + "\\ErrorProgramRun.txt",  ": On" + DateTime.Now.ToString()); // path of file where stack trace will be stored.
                }
            }
            catch (Exception t) {  Log(t); }
        }
        void SetAllDrawKindString()
        {
            Object OO = new Object();
            lock (OO)
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
        }
        void SetAllDrawKind(bool UsePenaltyRegardMechnisam, bool AStarGreedyHeuristic)
        {
            Object OO = new Object();
            lock (OO)
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

        bool DrawManagement(bool FOUND,bool UsePenaltyRegardMechnisam, bool AStarGreedyHeuristic)
        {
            Object OO = new Object();
            lock (OO)
            {
                SetAllDrawKind(UsePenaltyRegardMechnisam, AStarGreedyHeuristic);

                //Set Configuration To True for some unknown reason!.
                //UpdateConfigurationTableVal = true;                             
                SetAllDrawKindString();


                bool Found = false;
                String P = Path.GetFullPath(path3);
                AllDrawReplacement = Path.Combine(P, AllDrawKindString);

//                Logger y = new Logger(AllDrawReplacement);
                //y.Dispose();

//                y = new Logger(AllDrawKindString);
                //y.Dispose();

                if (File.Exists(AllDrawKindString))
				{FileInfo f = new FileInfo (AllDrawKindString);
					if (f.Length == 0)
						return false;
					
                    if (File.Exists(AllDrawReplacement))
                    {
						f = new FileInfo (AllDrawReplacement);
						if (f.Length == 0)
							return false;
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

                return Found;
            }
        }

        public bool Load(bool FOUND, bool Quantum, RefrigtzChessPortableForm Curent, ref bool LoadTree, bool MovementsAStarGreedyHeuristicFound, bool IInoreSelfObjects, bool UsePenaltyRegardMechnisam, bool BestMovments, bool PredictHeuristic, bool OnlySelf, bool AStarGreedyHeuristic, bool ArrangmentsChanged)
        {
            Object OO = new Object();
            lock (OO)
            {
				if (!DrawManagement (FOUND, UsePenaltyRegardMechnisam, AStarGreedyHeuristic))
					return false;

                bool DrawDrawen = false;
                //Load Middle Targets.
                try
                {
                    if (File.Exists(RefrigtzChessPortableForm.AllDrawKindString))
                    {
                        if (RefrigtzChessPortableForm.MovmentsNumber >= 0)
                        {
                            //if (!Quantum)
                            {


                                GalleryStudio.RefregizMemmory tr = new GalleryStudio.RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged);


                                t = (RefrigtzChessPortable.AllDraw)tr.Load(Quantum, RefrigtzChessPortableForm.OrderPlate);
                                if (t != null)
                                {
                                    Curent.Draw = t;

                                    LoadTree = true;
                                    Curent.Draw = Curent.RootFound();

                                    //Curent.Draw.UpdateLoseAndWinDepenOfKind(Curent.Draw.OrderP);


                                    t = Curent.Draw;
                                    //Curent.SetDrawFounding(ref FOUND, ref THIS, false);
                                    DrawDrawen = true;

                                    //System.Windows.Forms.//MessageBox.Show("Load Completed.");
                                }
                            }
                            /*else
                            {
                                GalleryStudio.RefregizMemmory tr = new GalleryStudio.RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged);
                               tt =(QuantumRefrigiz.AllDraw) tr.LoadQ(Quantum, RefrigtzChessPortableForm.OrderPlate);
                                if (t != null)
                                {

                                    Curent.DrawQ = tt;

                                    LoadTree = true;


                                    Curent.DrawQ = Curent.RootFoundQ();

                                    tt = Curent.DrawQ;

                                    DrawDrawen = true;

                                    //System.Windows.Forms.//MessageBox.Show("Load Completed.");
                                }
                            }*/
                        }
                        File.Delete(RefrigtzChessPortableForm.AllDrawKindString);
                    }
                }
                catch (Exception t) {  Log(t); }
                //System.Threading.Thread ttt = new System.Threading.Thread(new System.Threading.ThreadStart(Wait));
                //ttt.Start();
                //ttt.Join();

                return DrawDrawen;
            }
        }

       

        public bool Save(bool FOUND,bool Quantum, RefrigtzChessPortableForm Curent, ref bool LoadTree, bool MovementsAStarGreedyHeuristicFound, bool IInoreSelfObjects, bool UsePenaltyRegardMechnisam, bool BestMovments, bool PredictHeuristic, bool OnlySelf, bool AStarGreedyHeuristic, bool ArrangmentsChanged)
        {
            Object OO = new Object();
            lock (OO)
            {
                //System.Threading.Thread ttt = new System.Threading.Thread(new System.Threading.ThreadStart(Wait));
                //ttt.Start();
                //ttt.Join();

                /*if (!Quantum)
                {
                    while (Curent.Draw.AStarGreedyString != null)
                        Curent.Draw = Curent.Draw.AStarGreedyString;
                }
                else
                {
                    while (Curent.DrawQ.AStarGreedyString != null)
                        Curent.DrawQ = Curent.DrawQ.AStarGreedyString;
                }
               if (UsePenaltyRegardMechnisam && AStarGreedyHeuristic)
                    AllDrawKind = 4;
                else
                                                     if ((!UsePenaltyRegardMechnisam) && AStarGreedyHeuristic)
                    AllDrawKind = 3;
                if (UsePenaltyRegardMechnisam && (!AStarGreedyHeuristic))
                    AllDrawKind = 2;
                if ((!UsePenaltyRegardMechnisam) && (!AStarGreedyHeuristic))
                    AllDrawKind = 1;
                //Set Configuration To True for some unknown reason!.
                //UpdateConfigurationTableVal = true;                             
                SetAllDrawKindString();
                */
                try
                {


                    RefrigtzChessPortable.AllDraw Stote = Curent.Draw;
                    if (!File.Exists(AllDrawKindString))
                    {


                        GalleryStudio.RefregizMemmory rt = new GalleryStudio.RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged


                            );
                        //if (!Quantum)
                        {
                            if (Curent.Draw != null)
                            {
                                Curent.Draw = Curent.RootFound();
                                rt.AllDrawCurrentAccess = Curent.Draw;
                                rt.RewriteAllDraw(RefrigtzChessPortableForm.OrderPlate);
                                RefrigtzChessPortable.AllDraw.DrawTable = false;
                                //.SetBoxText("\r\nSaved Completed.");
                                //Curent.RefreshBoxText();
                                //PictureBoxRefrigtzChessPortable.SendToBack();
                                //PictureBoxTimerGray.SendToBack();
                                //PictureBoxTimerBrown.SendToBack();
                                ////MessageBox.Show("Saved Completed.");
                            }
                        }
                        /*else {
                            if (Curent.DrawQ != null)
                            {
                                Curent.DrawQ = Curent.RootFoundQ();
                                rt.AllDrawCurrentAccessQ = Curent.DrawQ;
                                rt.RewriteAllDrawQ(RefrigtzChessPortableForm.OrderPlate);
                                QuantumRefrigiz.AllDraw.DrawTable = false;
    //Curent.SetBoxText("\r\nSaved Completed.");
                            //    Curent.RefreshBoxText();
                                //PictureBoxRefrigtzChessPortable.SendToBack();
                                //PictureBoxTimerGray.SendToBack();
                                //PictureBoxTimerBrown.SendToBack();
                                ////MessageBox.Show("Saved Completed.");
                            }
                        */
                    }
                    else
                          if (File.Exists(AllDrawKindString))
                    {
                        //DrawManagement(FOUND, UsePenaltyRegardMechnisam, AStarGreedyHeuristic);

                        File.Delete(RefrigtzChessPortableForm.AllDrawKindString);


                        GalleryStudio.RefregizMemmory rt = new GalleryStudio.RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged


                            );
                        //"Universal Root Founding";
                        if (Curent.Draw != null)
                        {
                            Curent.Draw = Curent.RootFound();
                            rt.AllDrawCurrentAccess = Curent.Draw;
                            rt.RewriteAllDraw(RefrigtzChessPortableForm.OrderPlate);
                            RefrigtzChessPortable.AllDraw.DrawTable = false;
                            // Curent.SetBoxText("\r\nSaved Completed.");
                            // Curent.RefreshBoxText();
                            //PictureBoxRefrigtzChessPortable.SendToBack();
                            //PictureBoxTimerGray.SendToBack();
                            //PictureBoxTimerBrown.SendToBack();
                            ////MessageBox.Show("Saved Completed.");
                        }
                        //DrawManagement(FOUND, UsePenaltyRegardMechnisam, AStarGreedyHeuristic);

                    }
                    Curent.Draw = Stote;
                    return true;
                 }
                catch (Exception t)
				{Log (t);
                    
                    return false;
                }
            }
        }
    }
}

