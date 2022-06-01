using System.Collections;
using GameInput;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class PlayerMovement
    {
        [UnityTest]
        public IEnumerator PlayerCanMove()
        {
            yield return PlayModeTest.StartOfflinePlaymodeTest();
            var movable = Object.FindObjectOfType<InputMovable>();
            var beforePosition = movable.transform.position;
            for (int i = 0; i < 20; i++)
            {
                movable.Move(1, 1);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            var afterPosition = movable.transform.position;
            Assert.IsTrue(Vector3.Distance(beforePosition, afterPosition) > 0.1f);
        }
        
        [UnityTest]
        public IEnumerator PlayerCanJump()
        {
            yield return PlayModeTest.StartOfflinePlaymodeTest();
            var movable = Object.FindObjectOfType<InputMovable>();
            var beforePosition = movable.transform.position;
            
            movable.Jump();
            yield return new WaitForSeconds(5f * Time.deltaTime);
            var afterPosition = movable.transform.position;
            Assert.IsTrue(Vector3.Distance(beforePosition, afterPosition) > 0.1f);
        }
    }
}
