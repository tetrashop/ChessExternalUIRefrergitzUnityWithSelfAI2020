using System;

namespace RefrigtzChessPortable
{
	class MyGCCollectClass
	{
		private const long maxGarbage = 1000;
		private const long maxFree = 10000;

		public static bool ReadyMemmory()
		{
			try{MyGCCollectClass myGCCol = new MyGCCollectClass();

			// Determine the maximum number of generations the system
			// garbage collector currently supports.
			int MaxGenerationGc= GC.MaxGeneration;


			myGCCol.MakeSomeGarbage();

			// Determine which generation myGCCol object is stored in.
			int GetGenerationGc= GC.GetGeneration(myGCCol);

			// Determine the best available approximation of the number 
			// of bytes currently allocated in managed memory.
			long TotalMemory= GC.GetTotalMemory(false);
			if (TotalMemory > GetGenerationGc + maxFree)
					return true;}catch(Exception t){
				Console.Write (t.ToString ());
							return false;
			}
			return false;
		}
		

		void MakeSomeGarbage()
		{
			Version vt;

			for(int i = 0; i < maxGarbage; i++)
			{
				// Create objects and release them to fill up memory
				// with unused objects.
				vt = new Version();
			}
		}
	}
}