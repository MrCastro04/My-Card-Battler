using UnityEngine;

namespace Modules.@new
{
    public class MouseUtil 
    {
        private Camera _camera = Camera.main;

        public Vector3 GetMousePositionInWorldSpace(float zValue = 0)
        {
            Plane dragPlane = new(_camera.transform.forward, new Vector3(0f,0f,zValue));

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (dragPlane.Raycast(ray, out float distance))
            {
                return ray.GetPoint(distance);
            }

            return Vector3.zero;
        }
    }
}