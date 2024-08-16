using UnityEngine;

namespace Project.Utility
{
    public class SphericalCoordinate
    {
        private const float MinElevationRad = Mathf.Deg2Rad * 0.01f;
        private const float MaxElevationRad = Mathf.Deg2Rad * 179.99f;
        private const float RotationSpeed = Mathf.Deg2Rad * 60;

        public SphericalCoordinate(float radius, float azimuthDeg, float elevationDeg)
        {
            Radius = radius;
            AzimuthRad = Mathf.Deg2Rad * azimuthDeg;
            ElevationRad = Mathf.Deg2Rad * elevationDeg;
        }

        public float Radius { get; set; } //길이
        public float AzimuthRad { get; set; } //방위각
        public float ElevationRad { get; set; } //양각

        public Vector3 ToCartesianCoordinate()
        {
            //방위각, 양각, 길이(구면좌표계)를 통해 3차원 데카르트 좌표로 변환
            return new Vector3(
                Radius * Mathf.Sin(ElevationRad) * Mathf.Cos(AzimuthRad),
                Radius * Mathf.Cos(ElevationRad),
                Radius * Mathf.Sin(ElevationRad) * Mathf.Sin(AzimuthRad));
        }

        public void AddDirectionDeg(Vector2 directionDeg)
        {
            directionDeg *= RotationSpeed;
            AzimuthRad += directionDeg.x;
            ElevationRad += directionDeg.y;

            //구의 맨 위 또는 맨 아래를 넘어가는 것 방지
            ElevationRad = Mathf.Clamp(ElevationRad, MinElevationRad, MaxElevationRad);
        }
    }
}