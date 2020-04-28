/*https://stackoverflow.com/questions/11262357/best-practise-locking-files-and-sharing-between-threads*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigtzChessPortable
{
    class Logger ////: IDisposable
    {
        private FileStream file; //Only this instance have a right to own it
        private StreamWriter writer;
        private object mutex; //Mutex for synchronizing

        public Logger(string logPath)
        {
			try{  object o=new object();
				lock(o){
					using (file = File.Open(logPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                writer = new StreamWriter(file);
                mutex = new object();
					}
            }
			}catch(Exception t){
			}
        }

        // Log is thread safe, it can be called from many threads
        public void Log(string message)
        {
            lock (mutex)
            {
                writer.WriteLine(message);
            }
        }

        public void Dispose()
        {
            writer.Dispose(); //Will close underlying stream
        }
    }
}
