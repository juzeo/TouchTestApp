#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("0vKc3YRraROkeHj8MTDb75d3l3kwZF2NklhJbmhPtwdq6v/8YHzvb4DOF1cSuStswBcEbqr6bhl6CXSvC7k6GQs2PTIRvXO9zDY6Ojo+Ozg6MTm5Ojo7mjQl1YyA5SIiEaqWWpXx1jMzpujFc3D7UGDUlwBkDhz0K2zAFwRuqvpuGXoJdK/wWqwlGjQ2pCbsioVNH8K2vVW/PoDOF1cSuejFc3D7UGDUlwBkDhz0VAElFD8QObigL4o6iIknBNrH2abumB+WS18gc4Hx0O05uKAvijqIiScE2sfZplGiB8/QYaZj4t7dmf17GXg7J31OPTIRvXO9zDY6Ojo+Ozi5OjQ7C7m5OjQ7C7k6MTm5Ojo7mjQl1YyA5SsrHLIBNVQ+MjEAn+AAUaIHz9BhNZqrYWtUKyscsgE1VD4yMQCf4ADi8pp9DjIbABTXy+9bRYa4GcDAMiIiEaqWWjakJuyKhU0fwra9Vb8+7pgflktfnLoZqGFBbAkyd7GcZXDzv8T+dQ9TWwi+VSndPNLynN2Ea6Zj4t7dmf17GXg7J31O4vKafQ4yaROkeHj8MTDb75d3l3kgc4Hx0O0K1t7oBFcwZF2NklhJbmhPtwdq6v/8YHzvb0SNnjk4Ojs6C7k6GQs2e9uEKgnrqED29RPUwpmV8dYzM6ZUASUUPxDzv8T+dQ9TWwi+VSndPBsAFNfL71tFhrgZwMAyCtbe6ARXnLoZqGFBbAkyd7GcZXA1mqtha1TwWqwlGjR724QqCeuoQPb1E9TCmUSNnjk4Ojs6");
        private static int[] order = new int[] { 7,28,3,7,16,5,18,17,20,23,20,11,15,28,25,20,20,17,23,21,26,22,28,25,28,25,27,28,28,29 };
        private static int key = 59;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
