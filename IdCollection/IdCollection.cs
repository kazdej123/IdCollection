using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IdCollection
{
	public sealed class IdCollection : IEnumerable
	{
		private readonly ICollection<IdObject> _idObjectsCollection = new List<IdObject>();
		private readonly IDictionary<string, int> _idObjectByTypeCountersDictionary = new Dictionary<string, int>();

		public int Count => _idObjectsCollection.Count;

		public void Add(IdObject idObject)
		{
			if (idObject == null) {
				throw new ArgumentNullException("Parametr \"idObject\" nie moze byc null.");
			}
			if (_idObjectsCollection.Contains(idObject)) {
				throw new ArgumentException("Ten obiekt juz jest w kolekcji. Nie mozna dodac go ponownie.");
			}

			var idObjectTypeName = idObject.GetType().Name;
			if (!_idObjectByTypeCountersDictionary.ContainsKey(idObjectTypeName)) {
				_idObjectByTypeCountersDictionary.Add(idObjectTypeName, 0);
			}
			idObject.Id = ++_idObjectByTypeCountersDictionary[idObjectTypeName];
			_idObjectsCollection.Add(idObject);
		}

		public List<IdObject> ToListSortedByType()
			=> _idObjectsCollection.OrderBy(o => o.GetType().Name).ThenBy(o => o.Id).ToList();

		public List<IdObject> ToListSortedById()
			=> _idObjectsCollection.OrderBy(o => o.Id).ThenBy(o => o.GetType().Name).ToList();

		public IEnumerator GetEnumerator() => _idObjectsCollection.GetEnumerator();
	}
}
