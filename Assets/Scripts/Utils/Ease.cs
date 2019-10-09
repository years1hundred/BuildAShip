using UnityEngine;

namespace LD45Jam.Utils.Easing
{
    public static class Ease
    {
        #region Ease Functions

        public static float Float(float from, float to, float t, EaseType ease = EaseType.Linear)
        {
            EaseFunction easeFunc = GetEaseFunction(ease);
            return easeFunc(Mathf.Clamp01(t), from, to - from);
        }

        public static Vector2 Vector2(Vector2 from, Vector2 to, float t, EaseType ease = EaseType.Linear)
        {
            EaseFunction easeFunc = GetEaseFunction(ease);
            t = Mathf.Clamp01(t);
            return new Vector2(
                easeFunc(t, from.x, to.x - from.x),
                easeFunc(t, from.y, to.y - from.y)
            );
        }

        public static Vector3 Vector3(Vector3 from, Vector3 to, float t, EaseType ease = EaseType.Linear)
        {
            EaseFunction easeFunc = GetEaseFunction(ease);
            t = Mathf.Clamp01(t);
            return new Vector3(
                easeFunc(t, from.x, to.x - from.x),
                easeFunc(t, from.y, to.y - from.y),
                easeFunc(t, from.z, to.z - from.z)
            );
        }

        public static Vector4 Vector4(Vector4 from, Vector4 to, float t, EaseType ease = EaseType.Linear)
        {
            EaseFunction easeFunc = GetEaseFunction(ease);
            t = Mathf.Clamp01(t);
            return new Vector4(
                easeFunc(t, from.x, to.x - from.x),
                easeFunc(t, from.y, to.y - from.y),
                easeFunc(t, from.z, to.z - from.z),
                easeFunc(t, from.w, to.w - from.w)
            );
        }

        public static Quaternion Quaternion(Quaternion from, Quaternion to, float t, EaseType ease = EaseType.Linear)
        {
            return UnityEngine.Quaternion.Lerp(from, to, Float(0, 1, t, ease));
        }

        public static Color Color(Color from, Color to, float t, EaseType ease = EaseType.Linear)
        {
            EaseFunction easeFunc = GetEaseFunction(ease);
            t = Mathf.Clamp01(t);
            return new Color(
                easeFunc(t, from.r, to.r - from.r),
                easeFunc(t, from.g, to.g - from.g),
                easeFunc(t, from.b, to.b - from.b),
                easeFunc(t, from.a, to.a - from.a)
            );
        }

        #endregion

        #region Easing Type Implementation

        /*
             * Implementations based on Robert Penner's easing equations
             * http://robertpenner.com/easing/
             * http://gizma.com/easing/
             *
             * t = current time
             * b = initial value (from)
             * c = change in value (to - from)
             * d = duration (always 1, to get 0..1)
             */

        #region EaseFunction Switch

        private delegate float EaseFunction(float time, float begin, float end, float duration = 1);

        private static EaseFunction GetEaseFunction(EaseType type)
        {
            switch (type)
            {
                case EaseType.Linear:
                    return Ease.Linear;

                case EaseType.InSine:
                    return Ease.InSine;

                case EaseType.OutSine:
                    return Ease.OutSine;

                case EaseType.InOutSine:
                    return Ease.InOutSine;

                case EaseType.InQuad:
                    return Ease.InQuad;

                case EaseType.OutQuad:
                    return Ease.OutQuad;

                case EaseType.InOutQuad:
                    return Ease.InOutQuad;

                case EaseType.InCubic:
                    return Ease.InCubic;

                case EaseType.OutCubic:
                    return Ease.OutCubic;

                case EaseType.InOutCubic:
                    return Ease.InOutCubic;

                case EaseType.InQuart:
                    return Ease.InQuart;

                case EaseType.OutQuart:
                    return Ease.OutQuart;

                case EaseType.InOutQuart:
                    return Ease.InOutQuart;

                case EaseType.InQuint:
                    return Ease.InQuint;

                case EaseType.OutQuint:
                    return Ease.OutQuint;

                case EaseType.InOutQuint:
                    return Ease.InOutQuint;

                case EaseType.InExpo:
                    return Ease.InExpo;

                case EaseType.OutExpo:
                    return Ease.OutExpo;

                case EaseType.InOutExpo:
                    return Ease.InOutExpo;

                case EaseType.InCirc:
                    return Ease.InCirc;

                case EaseType.OutCirc:
                    return Ease.OutCirc;

                case EaseType.InOutCirc:
                    return Ease.InOutCirc;

                case EaseType.InBack:
                    return Ease.InBack;

                case EaseType.OutBack:
                    return Ease.OutBack;

                case EaseType.InOutBack:
                    return Ease.InOutBack;

                case EaseType.InBounce:
                    return Ease.InBounce;

                case EaseType.OutBounce:
                    return Ease.OutBounce;

                case EaseType.InOutBounce:
                    return Ease.InOutBounce;

                case EaseType.InElastic:
                    return Ease.InElastic;

                case EaseType.OutElastic:
                    return Ease.OutElastic;

                case EaseType.InOutElastic:
                    return Ease.InOutElastic;

                default:
                    return Ease.Linear;
            }
        }

        #endregion

        #region Linear

        // Linear interpolation (same as Mathf.Lerp)
        private static float Linear(float t, float b, float c, float d = 1)
        {
            return c * t / d + b;
        }

        #endregion

        #region Sine

        // sinusoidal easing in - accelerating from zero velocity
        private static float InSine(float t, float b, float c, float d = 1)
        {
            return -c * Mathf.Cos(t / d * (Mathf.PI / 2)) + c + b;
        }

        // sinusoidal easing out - decelerating to zero velocity
        private static float OutSine(float t, float b, float c, float d = 1)
        {
            return c * Mathf.Sin(t / d * (Mathf.PI / 2)) + b;
        }

        // sinusoidal easing in/out - accelerating until halfway, then decelerating
        private static float InOutSine(float t, float b, float c, float d = 1)
        {
            return -c / 2 * (Mathf.Cos(Mathf.PI * t / d) - 1) + b;
        }

        #endregion

        #region Quad

        // Quadratic easing in - accelerating from zero velocity
        private static float InQuad(float t, float b, float c, float d = 1)
        {
            t /= d;
            return c * t * t + b;
        }

        // quadratic easing out - decelerating to zero velocity
        private static float OutQuad(float t, float b, float c, float d = 1)
        {
            t /= d;
            return -c * t * (t - 2) + b;
        }

        // quadratic easing in/out - acceleration until halfway, then deceleration
        private static float InOutQuad(float t, float b, float c, float d = 1)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * t * t + b;
            t--;
            return -c / 2 * (t * (t - 2) - 1) + b;
        }

        #endregion

        #region Cubic

        // cubic easing in - accelerating from zero velocity
        private static float InCubic(float t, float b, float c, float d = 1)
        {
            t /= d;
            return c * t * t * t + b;
        }

        // cubic easing out - decelerating to zero velocity
        private static float OutCubic(float t, float b, float c, float d = 1)
        {
            t /= d;
            t--;
            return c * (t * t * t + 1) + b;
        }

        // cubic easing in/out - acceleration until halfway, then deceleration
        private static float InOutCubic(float t, float b, float c, float d = 1)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t + 2) + b;
        }

        #endregion

        #region Quart

        // quartic easing in - accelerating from zero velocity
        private static float InQuart(float t, float b, float c, float d = 1)
        {
            t /= d;
            return c * t * t * t * t + b;
        }

        // quartic easing out - decelerating to zero velocity
        private static float OutQuart(float t, float b, float c, float d = 1)
        {
            t /= d;
            t--;
            return -c * (t * t * t * t - 1) + b;
        }

        // quartic easing in/out - acceleration until halfway, then deceleration
        private static float InOutQuart(float t, float b, float c, float d = 1)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * t * t * t * t + b;
            t -= 2;
            return -c / 2 * (t * t * t * t - 2) + b;
        }

        #endregion

        #region Quint

        // quintic easing in - accelerating from zero velocity
        private static float InQuint(float t, float b, float c, float d = 1)
        {
            t /= d;
            return c * t * t * t * t * t + b;
        }

        // quintic easing out - decelerating to zero velocity
        private static float OutQuint(float t, float b, float c, float d = 1)
        {
            t /= d;
            t--;
            return c * (t * t * t * t * t + 1) + b;
        }

        // quintic easing in/out - acceleration until halfway, then deceleration
        private static float InOutQuint(float t, float b, float c, float d = 1)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * t * t * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t * t * t + 2) + b;
        }

        #endregion

        #region Expo

        // exponential easing in - accelerating from zero velocity
        private static float InExpo(float t, float b, float c, float d = 1)
        {
            return (t == 0) ? b : c * Mathf.Pow(2, 10 * (t / d - 1)) + b;
        }

        // exponential easing out - decelerating to zero velocity
        private static float OutExpo(float t, float b, float c, float d = 1)
        {
            return (t == d) ? b + c : c * (-Mathf.Pow(2, -10 * t / d) + 1) + b;
        }

        // exponential easing in/out - accelerating until halfway, then decelerating
        private static float InOutExpo(float t, float b, float c, float d = 1)
        {
            if (t == 0)
                return b;
            if (t == d)
                return b + c;

            t /= d / 2;
            if (t < 1)
                return c / 2 * Mathf.Pow(2, 10 * (t - 1)) + b;
            t--;
            return c / 2 * (-Mathf.Pow(2, -10 * t) + 2) + b;
        }

        #endregion

        #region Circ

        // circular easing in - accelerating from zero velocity
        private static float InCirc(float t, float b, float c, float d = 1)
        {
            t /= d;
            return -c * (Mathf.Sqrt(1 - t * t) - 1) + b;
        }

        // circular easing out - decelerating to zero velocity
        private static float OutCirc(float t, float b, float c, float d = 1)
        {
            t /= d;
            t--;
            return c * Mathf.Sqrt(1 - t * t) + b;
        }

        // circular easing in/out - acceleration until halfway, then deceleration
        private static float InOutCirc(float t, float b, float c, float d = 1)
        {
            t /= d / 2;
            if (t < 1)
                return -c / 2 * (Mathf.Sqrt(1 - t * t) - 1) + b;
            t -= 2;
            return c / 2 * (Mathf.Sqrt(1 - t * t) + 1) + b;
        }

        #endregion

        #region Back

        private static float InBack(float t, float b, float c, float d = 1)
        {
            float s = 1.70158f;
            float postFix = t /= d;
            return c * (postFix) * t * ((s + 1) * t - s) + b;
        }

        private static float OutBack(float t, float b, float c, float d = 1)
        {
            float s = 1.70158f;
            return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
        }

        private static float InOutBack(float t, float b, float c, float d = 1)
        {
            float s = 1.70158f;
            if ((t /= d / 2) < 1)
                return c / 2 * (t * t * (((s *= (1.525f)) + 1) * t - s)) + b;
            float postFix = t -= 2;
            return c / 2 * ((postFix) * t * (((s *= (1.525f)) + 1) * t + s) + 2) + b;
        }

        #endregion

        #region Bounce

        private static float InBounce(float t, float b, float c, float d = 1)
        {
            return c - OutBounce(d - t, 0, c, d) + b;
        }

        private static float OutBounce(float t, float b, float c, float d = 1)
        {
            if ((t /= d) < (1 / 2.75f))
            {
                return c * (7.5625f * t * t) + b;
            }
            else if (t < (2 / 2.75f))
            {
                float postFix = t -= (1.5f / 2.75f);
                return c * (7.5625f * (postFix) * t + .75f) + b;
            }
            else if (t < (2.5 / 2.75))
            {
                float postFix = t -= (2.25f / 2.75f);
                return c * (7.5625f * (postFix) * t + .9375f) + b;
            }
            else
            {
                float postFix = t -= (2.625f / 2.75f);
                return c * (7.5625f * (postFix) * t + .984375f) + b;
            }
        }

        private static float InOutBounce(float t, float b, float c, float d = 1)
        {
            if (t < d / 2)
                return InBounce(t * 2, 0, c, d) * .5f + b;
            else
                return OutBounce(t * 2 - d, 0, c, d) * .5f + c * .5f + b;
        }

        #endregion

        #region Elastic

        private static float InElastic(float t, float b, float c, float d = 1)
        {
            if (t == 0)
                return b;
            if ((t /= d) == 1)
                return b + c;
            float p = d * .3f;
            float a = c;
            float s = p / 4;
            float postFix = a * Mathf.Pow(2, 10 * (t -= 1)); // this is a fix, again, with post-increment operators
            return -(postFix * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p)) + b;
        }

        private static float OutElastic(float t, float b, float c, float d = 1)
        {
            if (t == 0)
                return b;
            if ((t /= d) == 1)
                return b + c;
            float p = d * .3f;
            float a = c;
            float s = p / 4;
            return (a * Mathf.Pow(2, -10 * t) * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p) + c + b);
        }

        private static float InOutElastic(float t, float b, float c, float d = 1)
        {
            if (t == 0)
                return b;
            if ((t /= d / 2) == 2)
                return b + c;
            float p = d * (.3f * 1.5f);
            float a = c;
            float s = p / 4;

            if (t < 1)
            {
                float postFix = a * Mathf.Pow(2, 10 * (t -= 1)); // postIncrement is evil
                return -.5f * (postFix * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p)) + b;
            }
            else
            {
                float postFix = a * Mathf.Pow(2, -10 * (t -= 1)); // postIncrement is evil
                return postFix * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p) * .5f + c + b;
            }
        }

        #endregion

        #endregion
    }
}
