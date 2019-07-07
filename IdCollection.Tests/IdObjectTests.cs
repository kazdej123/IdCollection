using NUnit.Framework;

namespace IdCollection.Tests
{
	internal sealed class IdObjectTests
	{
		[Test]
		public static void IdObject_CreateNewIdObject_IdShouldEqualsToZero()
		{
			Assert.AreEqual(0, new IdObject().Id);
		}
	}
}
