using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
	public class SerieRepository : IRepository<Serie>
	{
        private List<Serie> SerieList = new List<Serie>();
		public void Add(int id, Serie MyObject)
		{
			SerieList[id] = MyObject;
		}

		public void Delete(int id)
		{
			SerieList[id].Delete();
		}

		public void Update(Serie MyObject)
		{
			SerieList.Add(MyObject);
		}

		public List<Serie> List()
		{
			return SerieList;
		}

		public int NextId()
		{
			return SerieList.Count;
		}

		public Serie ReturnById(int id)
		{
			return SerieList[id];
		}
	}
}