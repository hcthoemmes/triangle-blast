using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewPlayModeTest {

    NewBehaviourScript m = new NewBehaviourScript();
    Vector2 screenSize = new Vector2(100, 100);
    Vector2 worldSize = new Vector2(10, 10);

	[Test]
	public void NewPlayModeTestSimplePasses() {
        Assert.True(NewBehaviourScript.pixelVectorToWorldVector(new Vector2(0,0), worldSize,screenSize) == new Vector2(0,0));
		// Use the Assert class to test conditions.
	}

    [Test]
    public void PixelsToUnits() {
        Assert.AreEqual(new Vector2(1,1), NewBehaviourScript.pixelVectorToWorldVector(new Vector2(10, 10),worldSize,screenSize));
    }

    [Test]
    public void PixelsToUnits2() {
        Assert.AreEqual(new Vector2(10,10), NewBehaviourScript.pixelVectorToWorldVector(new Vector2(100, 100), worldSize, screenSize));
    }

    [Test]
    public void ShiftingTest() {
        var originalPoint = new Vector2(5, 5);
        var shiftedPoint = NewBehaviourScript.coordinateShift(worldSize.x, worldSize.y, originalPoint);
        Assert.AreEqual(new Vector2(0, 0), shiftedPoint);
    }

    [Test]
    public void OneSideIsZero() {
        var originalPoint = new Vector2(0, 10);
        var shiftedPoint = NewBehaviourScript.coordinateShift(worldSize.x, worldSize.y, originalPoint);
        Assert.AreEqual(new Vector2(-5, 5), shiftedPoint);
    }

    [Test]
    public void NonIntegralSide() {
        var originalPoint = new Vector2(8, 7.5f);
        var shiftedPoint = NewBehaviourScript.coordinateShift(worldSize.x, worldSize.y, originalPoint);
        Assert.AreEqual(new Vector2(3, 2.5f), shiftedPoint);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator NewPlayModeTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
