using NUnit.Framework;
using System;

namespace IdCollection.Tests
{
	internal sealed class IdCollectionTests
    {
		private sealed class TestIdObject_A : IdObject { }

		private sealed class TestIdObject_B : IdObject { }

		[Test]
		public static void IdCollection_CreatesNewIdCollection_IdCollectionShouldBeEmpty()
		{
			CollectionAssert.IsEmpty(new IdCollection());
		}

		[Test]
		public static void Add_TriesToAddNullToEmptyIdCollection()
		{
			var idCollection = new IdCollection();

			_ = Assert.Throws<ArgumentNullException>(() => idCollection.Add(null));

			Assert.AreEqual(0, idCollection.Count);
			CollectionAssert.DoesNotContain(idCollection, null);
		}

		[Test]
		public static void Add_TriesToAddNullToNotEmptyIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject = new IdObject();

			idCollection.Add(idObject);
			_ = Assert.Throws<ArgumentNullException>(() => idCollection.Add(null));

			Assert.AreEqual(1, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject);
			CollectionAssert.DoesNotContain(idCollection, null);
			Assert.AreEqual(1, idObject.Id);
		}

		[Test]
		public static void Add_TriesToAddAlreadyAddedObjectAgainToIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject = new IdObject();

			idCollection.Add(idObject);
			_ = Assert.Throws<ArgumentException>(() => idCollection.Add(idObject));

			Assert.AreEqual(1, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject);
			Assert.AreEqual(1, idObject.Id);
		}

		[Test]
		public static void Add_AddsOToIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject = new IdObject();

			idCollection.Add(idObject);

			Assert.AreEqual(1, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject);
			Assert.AreEqual(1, idObject.Id);
		}

		[Test]
		public static void Add_AddsAToIdCollection()
		{
			var idCollection = new IdCollection();
			var a = new TestIdObject_A();

			idCollection.Add(a);

			Assert.AreEqual(1, idCollection.Count);
			CollectionAssert.Contains(idCollection, a);
			Assert.AreEqual(1, a.Id);
		}

		[Test]
		public static void Add_AddsOOToIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject1 = new IdObject();
			var idObject2 = new IdObject();

			idCollection.Add(idObject1);
			idCollection.Add(idObject2);

			Assert.AreEqual(2, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject1);
			CollectionAssert.Contains(idCollection, idObject2);
			Assert.AreEqual(1, idObject1.Id);
			Assert.AreEqual(2, idObject2.Id);
		}

		[Test]
		public static void Add_AddsOAToIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject = new IdObject();
			var a = new TestIdObject_A();

			idCollection.Add(idObject);
			idCollection.Add(a);

			Assert.AreEqual(2, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject);
			CollectionAssert.Contains(idCollection, a);
			Assert.AreEqual(1, idObject.Id);
			Assert.AreEqual(1, a.Id);
		}

		[Test]
		public static void Add_AddsAOToIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject = new IdObject();
			var a = new TestIdObject_A();

			idCollection.Add(a);
			idCollection.Add(idObject);

			Assert.AreEqual(2, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject);
			CollectionAssert.Contains(idCollection, a);
			Assert.AreEqual(1, idObject.Id);
			Assert.AreEqual(1, a.Id);
		}

		[Test]
		public static void Add_AddsAAToIdCollection()
		{
			var idCollection = new IdCollection();
			var a1 = new TestIdObject_A();
			var a2 = new TestIdObject_A();

			idCollection.Add(a1);
			idCollection.Add(a2);

			Assert.AreEqual(2, idCollection.Count);
			CollectionAssert.Contains(idCollection, a1);
			CollectionAssert.Contains(idCollection, a2);
			Assert.AreEqual(1, a1.Id);
			Assert.AreEqual(2, a2.Id);
		}

		[Test]
		public static void Add_AddsOOOToIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject1 = new IdObject();
			var idObject2 = new IdObject();
			var idObject3 = new IdObject();

			idCollection.Add(idObject1);
			idCollection.Add(idObject2);
			idCollection.Add(idObject3);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject1);
			CollectionAssert.Contains(idCollection, idObject2);
			CollectionAssert.Contains(idCollection, idObject3);
			Assert.AreEqual(1, idObject1.Id);
			Assert.AreEqual(2, idObject2.Id);
			Assert.AreEqual(3, idObject3.Id);
		}

		[Test]
		public static void Add_AddsOOAToIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject1 = new IdObject();
			var idObject2 = new IdObject();
			var a = new TestIdObject_A();

			idCollection.Add(idObject1);
			idCollection.Add(idObject2);
			idCollection.Add(a);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject1);
			CollectionAssert.Contains(idCollection, idObject2);
			CollectionAssert.Contains(idCollection, a);
			Assert.AreEqual(1, idObject1.Id);
			Assert.AreEqual(2, idObject2.Id);
			Assert.AreEqual(1, a.Id);
		}

		[Test]
		public static void Add_AddsOAOToIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject1 = new IdObject();
			var a = new TestIdObject_A();
			var idObject2 = new IdObject();

			idCollection.Add(idObject1);
			idCollection.Add(a);
			idCollection.Add(idObject2);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject1);
			CollectionAssert.Contains(idCollection, a);
			CollectionAssert.Contains(idCollection, idObject2);
			Assert.AreEqual(1, idObject1.Id);
			Assert.AreEqual(1, a.Id);
			Assert.AreEqual(2, idObject2.Id);
		}

		[Test]
		public static void Add_AddsOAAToIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject = new IdObject();
			var a1 = new TestIdObject_A();
			var a2 = new TestIdObject_A();

			idCollection.Add(idObject);
			idCollection.Add(a1);
			idCollection.Add(a2);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject);
			CollectionAssert.Contains(idCollection, a1);
			CollectionAssert.Contains(idCollection, a2);
			Assert.AreEqual(1, idObject.Id);
			Assert.AreEqual(1, a1.Id);
			Assert.AreEqual(2, a2.Id);
		}

		[Test]
		public static void Add_AddsOABToIdCollection()
		{
			var idCollection = new IdCollection();
			var idObject = new IdObject();
			var a = new TestIdObject_A();
			var b = new TestIdObject_B();

			idCollection.Add(idObject);
			idCollection.Add(a);
			idCollection.Add(b);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, idObject);
			CollectionAssert.Contains(idCollection, a);
			CollectionAssert.Contains(idCollection, b);
			Assert.AreEqual(1, idObject.Id);
			Assert.AreEqual(1, a.Id);
			Assert.AreEqual(1, b.Id);
		}

		[Test]
		public static void Add_AddsAOOToIdCollection()
		{
			var idCollection = new IdCollection();
			var a = new TestIdObject_A();
			var idObject1 = new IdObject();
			var idObject2 = new IdObject();

			idCollection.Add(a);
			idCollection.Add(idObject1);
			idCollection.Add(idObject2);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, a);
			CollectionAssert.Contains(idCollection, idObject1);
			CollectionAssert.Contains(idCollection, idObject2);
			Assert.AreEqual(1, a.Id);
			Assert.AreEqual(1, idObject1.Id);
			Assert.AreEqual(2, idObject2.Id);
		}

		[Test]
		public static void Add_AddsAOAToIdCollection()
		{
			var idCollection = new IdCollection();
			var a1 = new TestIdObject_A();
			var idObject = new IdObject();
			var a2 = new TestIdObject_A();

			idCollection.Add(a1);
			idCollection.Add(idObject);
			idCollection.Add(a2);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, a1);
			CollectionAssert.Contains(idCollection, idObject);
			CollectionAssert.Contains(idCollection, a2);
			Assert.AreEqual(1, a1.Id);
			Assert.AreEqual(1, idObject.Id);
			Assert.AreEqual(2, a2.Id);
		}

		[Test]
		public static void Add_AddsAOBToIdCollection()
		{
			var idCollection = new IdCollection();
			var a = new TestIdObject_A();
			var idObject = new IdObject();
			var b = new TestIdObject_B();

			idCollection.Add(a);
			idCollection.Add(idObject);
			idCollection.Add(b);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, a);
			CollectionAssert.Contains(idCollection, idObject);
			CollectionAssert.Contains(idCollection, b);
			Assert.AreEqual(1, a.Id);
			Assert.AreEqual(1, idObject.Id);
			Assert.AreEqual(1, b.Id);
		}

		[Test]
		public static void Add_AddsAAOToIdCollection()
		{
			var idCollection = new IdCollection();
			var a1 = new TestIdObject_A();
			var a2 = new TestIdObject_A();
			var idObject = new IdObject();

			idCollection.Add(a1);
			idCollection.Add(a2);
			idCollection.Add(idObject);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, a1);
			CollectionAssert.Contains(idCollection, a2);
			CollectionAssert.Contains(idCollection, idObject);
			Assert.AreEqual(1, a1.Id);
			Assert.AreEqual(2, a2.Id);
			Assert.AreEqual(1, idObject.Id);
		}

		[Test]
		public static void Add_AddsAAAToIdCollection()
		{
			var idCollection = new IdCollection();
			var a1 = new TestIdObject_A();
			var a2 = new TestIdObject_A();
			var a3 = new TestIdObject_A();

			idCollection.Add(a1);
			idCollection.Add(a2);
			idCollection.Add(a3);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, a1);
			CollectionAssert.Contains(idCollection, a2);
			CollectionAssert.Contains(idCollection, a3);
			Assert.AreEqual(1, a1.Id);
			Assert.AreEqual(2, a2.Id);
			Assert.AreEqual(3, a3.Id);
		}

		[Test]
		public static void Add_AddsAABToIdCollection()
		{
			var idCollection = new IdCollection();
			var a1 = new TestIdObject_A();
			var a2 = new TestIdObject_A();
			var b = new TestIdObject_B();

			idCollection.Add(a1);
			idCollection.Add(a2);
			idCollection.Add(b);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, a1);
			CollectionAssert.Contains(idCollection, a2);
			CollectionAssert.Contains(idCollection, b);
			Assert.AreEqual(1, a1.Id);
			Assert.AreEqual(2, a2.Id);
			Assert.AreEqual(1, b.Id);
		}

		[Test]
		public static void Add_AddsABOToIdCollection()
		{
			var idCollection = new IdCollection();
			var a = new TestIdObject_A();
			var b = new TestIdObject_B();
			var idObject = new IdObject();

			idCollection.Add(a);
			idCollection.Add(b);
			idCollection.Add(idObject);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, a);
			CollectionAssert.Contains(idCollection, b);
			CollectionAssert.Contains(idCollection, idObject);
			Assert.AreEqual(1, a.Id);
			Assert.AreEqual(1, b.Id);
			Assert.AreEqual(1, idObject.Id);
		}

		[Test]
		public static void Add_AddsABAToIdCollection()
		{
			var idCollection = new IdCollection();
			var a1 = new TestIdObject_A();
			var b = new TestIdObject_B();
			var a2 = new TestIdObject_A();

			idCollection.Add(a1);
			idCollection.Add(b);
			idCollection.Add(a2);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, a1);
			CollectionAssert.Contains(idCollection, b);
			CollectionAssert.Contains(idCollection, a2);
			Assert.AreEqual(1, a1.Id);
			Assert.AreEqual(1, b.Id);
			Assert.AreEqual(2, a2.Id);
		}

		[Test]
		public static void Add_AddsABBToIdCollection()
		{
			var idCollection = new IdCollection();
			var a = new TestIdObject_A();
			var b1 = new TestIdObject_B();
			var b2 = new TestIdObject_B();

			idCollection.Add(a);
			idCollection.Add(b1);
			idCollection.Add(b2);

			Assert.AreEqual(3, idCollection.Count);
			CollectionAssert.Contains(idCollection, a);
			CollectionAssert.Contains(idCollection, b1);
			CollectionAssert.Contains(idCollection, b2);
			Assert.AreEqual(1, a.Id);
			Assert.AreEqual(1, b1.Id);
			Assert.AreEqual(2, b2.Id);
		}

		[Test]
		public static void ToListSortedByType_ReturnsEmptyListFrom_Empty_IdCollection()
		{
			CollectionAssert.IsEmpty(new IdCollection().ToListSortedByType());
		}
	}
}
