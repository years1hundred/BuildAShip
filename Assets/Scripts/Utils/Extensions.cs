using UnityEngine;
using UnityEngine.UI;

namespace LD45Jam
{
    public static class Extensions
    {
        #region Component

        /// <summary>
        /// Activate the GameObject this component is attached to.
        /// </summary>
        public static void Activate(this Component c)
        {
            GameObject go = c.gameObject;
            if (!go.activeSelf)
                go.SetActive(true);
        }

        /// <summary>
        /// De-activate the GameObject this component is attached to.
        /// </summary>
        /// <param name="c">C.</param>
        public static void Deactivate(this Component c)
        {
            GameObject go = c.gameObject;
            if (go.activeSelf)
                go.SetActive(false);
        }

        /// <summary>
        /// De-activate the GameObject this component is attached to.
        /// </summary>
        /// <param name="c">C.</param>
        public static bool IsActivated(this Component c)
        {
            return c.gameObject.activeSelf;
        }

        #endregion

        #region Transform

        #region Transform Utility

        /// <summary>
        /// Sets the Transform components to default values.
        /// </summary>
        public static void ResetTransform(this GameObject go)
        {
            go.transform.position = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Sets the Transform components to default values.
        /// </summary>
        public static void ResetTransform(this Transform t)
        {
            t.position = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
        }

        /// <summary>
        /// Sets the X local scale to its inverse, flipping it. Note: This will break sprite batching.
        /// </summary>
        public static void FlipX(this GameObject go)
        {
            go.transform.FlipX();
        }

        /// <summary>
        /// Sets the X local scale to its inverse, flipping it. Note: This will break sprite batching.
        /// </summary>
        public static void FlipX(this Transform t)
        {
            t.SetScaleX(t.localScale.x * -1);
        }

        /// <summary>
        /// Sets the Y local scale to its inverse, flipping it. Note: This will break sprite batching.
        /// </summary>
        public static void FlipY(this GameObject go)
        {
            go.transform.FlipY();
        }

        /// <summary>
        /// Sets the Y local scale to its inverse, flipping it. Note: This will break sprite batching.
        /// </summary>
        public static void FlipY(this Transform t)
        {
            t.SetScaleY(t.localScale.y * -1);
        }

        /// <summary>
        /// Sets the Z local scale to its inverse, flipping it. Note: This will break sprite batching.
        /// </summary>
        public static void FlipZ(this GameObject go)
        {
            go.transform.FlipZ();
        }

        /// <summary>
        /// Sets the Z local scale to its inverse, flipping it. Note: This will break sprite batching.
        /// </summary>
        public static void FlipZ(this Transform t)
        {
            t.SetScaleZ(t.localScale.z * -1);
        }

        #endregion

        #region Transform Position

        /// <summary>
        /// Sets the X component of a Vector3 position in a given Transform.
        /// </summary>
        public static void SetPositionX(this GameObject go, float x)
        {
            go.transform.SetPositionX(x);
        }

        /// <summary>
        /// Sets the X component of a Vector3 position in a given Transform.
        /// </summary>
        public static void SetPositionX(this Transform t, float x)
        {
            t.position = new Vector3(x, t.position.y, t.position.z);
        }

        /// <summary>
        /// Sets the Y component of a Vector3 position in a given Transform.
        /// </summary>
        public static void SetPositionY(this GameObject go, float y)
        {
            go.transform.SetPositionY(y);
        }

        /// <summary>
        /// Sets the Y component of a Vector3 position in a given Transform.
        /// </summary>
        public static void SetPositionY(this Transform t, float y)
        {
            t.position = new Vector3(t.position.x, y, t.position.z);
        }

        /// <summary>
        /// Sets the Z component of a Vector3 position in a given Transform.
        /// </summary>
        public static void SetPositionZ(this GameObject go, float z)
        {
            go.transform.SetPositionZ(z);
        }

        /// <summary>
        /// Sets the Z component of a Vector3 position in a given Transform.
        /// </summary>
        public static void SetPositionZ(this Transform t, float z)
        {
            t.position = new Vector3(t.position.x, t.position.y, z);
        }

        /// <summary>
        /// Sets the Vector3 position in a given Transform.
        /// </summary>
        public static void SetPosition(this GameObject go, Vector3 position)
        {
            go.transform.position = position;
        }

        /// <summary>
        /// Sets the Vector3 position in a given Transform.
        /// </summary>
        public static void SetPosition(this Transform t, Vector3 position)
        {
            t.position = position;
        }

        /// <summary>
        /// Sets the Vector3 position in a given Transform.
        /// </summary>
        public static void SetPosition(this GameObject go, float x, float y, float z = 0)
        {
            go.transform.SetPosition(x, y, z);
        }

        /// <summary>
        /// Sets the Vector3 position in a given Transform.
        /// </summary>
        public static void SetPosition(this Transform t, float x, float y, float z = 0)
        {
            t.position = new Vector3(x, y, z);
        }

        #endregion

        #region Transform Scale

        /// <summary>
        /// Sets the X local scale value of a given Transform.
        /// </summary>
        public static void SetScaleX(this GameObject go, float x)
        {
            go.transform.SetScaleX(x);
        }

        /// <summary>
        /// Sets the X local scale value of a given Transform.
        /// </summary>
        public static void SetScaleX(this Transform t, float x)
        {
            t.localScale = new Vector3(x, t.localScale.y, t.localScale.z);
        }

        /// <summary>
        /// Sets the Y local scale value of a given Transform.
        /// </summary>
        public static void SetScaleY(this GameObject go, float y)
        {
            go.transform.SetScaleY(y);
        }

        /// <summary>
        /// Sets the Y local scale value of a given Transform.
        /// </summary>
        public static void SetScaleY(this Transform t, float y)
        {
            t.localScale = new Vector3(t.localScale.x, y, t.localScale.z);
        }

        /// <summary>
        /// Sets the Z local scale value of a given Transform.
        /// </summary>
        public static void SetScaleZ(this GameObject go, float z)
        {
            go.transform.SetScaleZ(z);
        }

        /// <summary>
        /// Sets the Z local scale value of a given Transform.
        /// </summary>
        public static void SetScaleZ(this Transform t, float z)
        {
            t.localScale = new Vector3(t.localScale.x, t.localScale.y, z);
        }

        /// <summary>
        /// Sets the local scale value of a given Transform.
        /// </summary>
        public static void SetScale(this GameObject go, Vector3 scale)
        {
            go.transform.localScale = scale;
        }

        /// <summary>
        /// Sets the local scale value of a given Transform.
        /// </summary>
        public static void SetScale(this Transform t, Vector3 scale)
        {
            t.localScale = scale;
        }

        /// <summary>
        /// Sets the local scale value of a given Transform.
        /// </summary>
        public static void SetScale(this GameObject go, float x, float y, float z = 1)
        {
            go.transform.SetScale(x, y, z);
        }

        /// <summary>
        /// Sets the local scale value of a given Transform.
        /// </summary>
        public static void SetScale(this Transform t, float x, float y, float z = 1)
        {
            t.localScale = new Vector3(x, y, z);
        }

        #endregion

        #endregion

        #region Float

        /// <summary>
        /// Remaps the value from a specified range (min, max) to specified target range (targetMin, targetMax).
        /// </summary>
        public static float RemapValue(this float value, float min, float max, float targetMin, float targetMax)
        {
            return targetMin + (value - min) * (targetMax - targetMin) / (max - min);
        }

        /// <summary>
        /// Remaps the value from range (0 to 1) to target range.
        /// </summary>
        public static float RemapValue01(this float value, float targetMin, float targetMax)
        {
            return RemapValue(Mathf.Clamp01(value), 0, 1, targetMin, targetMax);
        }

        #endregion

        #region Vector

        #region Vector2

        /// <summary>
        /// Sets the X component of a given Vector2.
        /// </summary>
        public static Vector2 SetX(this Vector2 v2, float x)
        {
            return new Vector2(x, v2.y);
        }

        /// <summary>
        /// Sets the Y component of a given Vector2.
        /// </summary>
        public static Vector2 SetY(this Vector2 v2, float y)
        {
            return new Vector2(v2.x, y);
        }

        #endregion

        #region Vector3

        /// <summary>
        /// Sets the X component of a given Vector3.
        /// </summary>
        public static Vector3 SetX(this Vector3 v3, float x)
        {
            return new Vector3(x, v3.y, v3.z);
        }

        /// <summary>
        /// Sets the Y component of a given Vector3.
        /// </summary>
        public static Vector3 SetY(this Vector3 v3, float y)
        {
            return new Vector3(v3.x, y, v3.z);
        }

        /// <summary>
        /// Sets the Z component of a given Vector3.
        /// </summary>
        public static Vector3 SetZ(this Vector3 v3, float z)
        {
            return new Vector3(v3.x, v3.y, z);
        }

        #endregion

        #endregion

        #region Rigidbody (2D/3D)

        #region Rigidbody2D Velocity

        /// <summary>
        /// Sets the X velocity of a given Rigidbody2D.
        /// </summary>
        public static void SetVelocityX(this Rigidbody2D rb2D, float x)
        {
            rb2D.velocity = new Vector2(x, rb2D.velocity.y);
        }

        /// <summary>
        /// Sets the Y velocity of a given Rigidbody2D.
        /// </summary>
        public static void SetVelocityY(this Rigidbody2D rb2D, float y)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, y);
        }

        /// <summary>
        /// Sets the velocity of a given Rigidbody2D.
        /// </summary>
        public static void SetVelocity(this Rigidbody2D rb2D, Vector2 v2)
        {
            rb2D.velocity = v2;
        }

        /// <summary>
        /// Sets the velocity of a given Rigidbody2D.
        /// </summary>
        public static void SetVelocity(this Rigidbody2D rb2D, float x, float y)
        {
            rb2D.velocity = new Vector2(x, y);
        }

        #endregion

        #region Rigidbody Velocity

        /// <summary>
        /// Sets the X velocity of a given Rigidbody.
        /// </summary>
        public static void SetVelocityX(this Rigidbody rb, float x)
        {
            Vector3 v3 = rb.velocity;
            v3.x = x;
            rb.velocity = v3;
        }

        /// <summary>
        /// Sets the Y velocity of a given Rigidbody.
        /// </summary>
        public static void SetVelocityY(this Rigidbody rb, float y)
        {
            Vector3 v3 = rb.velocity;
            v3.y = y;
            rb.velocity = v3;
        }

        /// <summary>
        /// Sets the Z velocity of a given Rigidbody.
        /// </summary>
        public static void SetVelocityZ(this Rigidbody rb, float z)
        {
            Vector3 v3 = rb.velocity;
            v3.z = z;
            rb.velocity = v3;
        }

        /// <summary>
        /// Sets the velocity of a given Rigidbody.
        /// </summary>
        public static void SetVelocity(this Rigidbody rb, Vector3 v3)
        {
            rb.velocity = v3;
        }

        /// <summary>
        /// Sets the velocity of a given Rigidbody.
        /// </summary>
        public static void SetVelocity(this Rigidbody rb, float x, float y, float z = 0)
        {
            rb.velocity = new Vector3(x, y, z);
        }

        #endregion

        #endregion

        #region Color

        #region Color (Return Color)

        public static Color WithAlpha(this Color c, float alpha)
        {
            return new Color(c.r, c.g, c.b, alpha);
        }

        #endregion

        #region Color (Renderer)

        /// <summary>
        /// Sets the color for the material on this Renderer object.
        /// </summary>
        public static Color SetColor(this Renderer renderer, Color color)
        {
            renderer.sharedMaterial.color = color;
            return color;
        }

        /// <summary>
        /// Sets the value of the alpha channel for the material on this Renderer object.
        /// </summary>
        public static Color SetAlpha(this Renderer renderer, float alpha)
        {
            Color c = renderer.sharedMaterial.color;
            c.a = alpha;
            renderer.sharedMaterial.color = c;
            return c;
        }

        /// <summary>
        /// Sets the color for the material on this Renderer object.
        /// </summary>
        public static Color SetColorAlpha(this Renderer renderer, Color color, float alpha = 1)
        {
            Color c = color;
            c.a = alpha;
            renderer.sharedMaterial.color = c;
            return c;
        }

        #endregion

        #region Color (UI Graphic)

        /// <summary>
        /// Sets the color for this UI Graphic.
        /// </summary>
        public static Color SetColor(this Graphic graphic, Color color)
        {
            graphic.color = color;
            return color;
        }

        /// <summary>
        /// Sets the value of the alpha channel for this UI Graphic.
        /// </summary>
        public static Color SetAlpha(this Graphic graphic, float alpha)
        {
            Color c = graphic.color;
            c.a = alpha;
            graphic.color = c;
            return c;
        }

        /// <summary>
        /// Sets the color for this UI Graphic.
        /// </summary>
        public static Color SetColorAlpha(this Graphic graphic, Color color, float alpha = 1)
        {
            Color c = color;
            c.a = alpha;
            graphic.color = c;
            return c;
        }

        #endregion

        #endregion

        #region Camera

        /// <summary>
        /// Resizes given Transform object to that of provided Camera.
        /// Depth will determine position between near and far clipping planes.
        /// </summary>
        public static void ResizeToCameraFrustum(this Renderer renderer, Camera cam, float depth = 0)
        {
            Transform rT = renderer.transform;
            Transform cT = cam.transform;

            // Object should be visible within frustum's near and far clip panes
            // Remap depth from 0.01 to 0.99 (between the clipping panes)
            //		float newDepth = 0.01f + Mathf.Clamp01(depth) * 0.98f;
            float newDepth = depth.RemapValue01(cam.nearClipPlane + 0.01f, cam.farClipPlane - 0.01f);

            // Get the new height of the transform based on position in frustum
            float newHeight = Mathf.Tan(cam.fieldOfView * Mathf.Deg2Rad * 0.5f) * newDepth * 2f;

            // Set the position in place between the near
            rT.SetPosition(cT.position + cT.forward * newDepth);

            // Get the new scale of the object by the camera's aspect ratio
            rT.SetScale(newHeight * cam.aspect, newHeight, rT.localScale.z);
        }

        #endregion
    }
}
