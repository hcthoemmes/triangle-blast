using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewPlayModeTest {

    NewBehaviourScript m = new NewBehaviourScript();
    Vector2 v = new Vector2(5, 5);

	[Test]
	public void NewPlayModeTestSimplePasses() {
        Assert.True(m.pixelLengthToScreenLength(0,0,v) == 0);
		// Use the Assert class to test conditions.
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
