using UnityEngine;

public class SphericalCoordinate
{
    private const float minElevationRad = Mathf.Deg2Rad * 0.01f;
    private const float maxElevationRad = Mathf.Deg2Rad * 179.99f;
    private const float rotationSpeed = Mathf.Deg2Rad * 3f;

    public float Radius { get; set; }//길이
    public float AzimuthRad { get; set; }//방위각
    public float ElevationRad { get; set; }//앙각

    public SphericalCoordinate(float radius, float azimuthDeg, float elevationDeg)
    {
        Radius = radius;
        AzimuthRad = Mathf.Deg2Rad * azimuthDeg;
        ElevationRad = Mathf.Deg2Rad * elevationDeg;
    }

    public Vector3 ToCartesianCoordinate()
    {
        //방위각, 양각, 길이를 통해 구면 좌표계의 좌표를 구함.
        return new(
            Radius * Mathf.Sin(ElevationRad) * Mathf.Cos(AzimuthRad),
            Radius * Mathf.Cos(ElevationRad),
            Radius * Mathf.Sin(ElevationRad) * Mathf.Sin(AzimuthRad));
    }

    public void AddDirectionDeg(Vector2 directionDeg)
    {
        AzimuthRad += directionDeg.x * rotationSpeed;
        ElevationRad += directionDeg.y * rotationSpeed;

        //구의 맨 위 또는 맨 아래를 넘어가는 것 방지
        ElevationRad = Mathf.Clamp(ElevationRad, minElevationRad, maxElevationRad);
    }
}
