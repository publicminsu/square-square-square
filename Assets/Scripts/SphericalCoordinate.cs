using UnityEngine;

public class SphericalCoordinate
{
    private float minElevationRad, maxElevationRad;
    private float rotationSpeed = 3f;

    public float Radius { get; set; }//길이
    public float AzimuthRad { get; set; }//방위각
    public float ElevationRad { get; set; }//앙각

    public SphericalCoordinate(float radius, float azimuthDeg, float elevationDeg)
    {
        Radius = radius;
        AzimuthRad = Mathf.Deg2Rad * azimuthDeg;
        ElevationRad = Mathf.Deg2Rad * elevationDeg;

        minElevationRad = Mathf.Deg2Rad * 0.01f;
        maxElevationRad = Mathf.Deg2Rad * 179.99f;
    }

    public Vector3 ToCartesianCoordinate()
    {
        return new(
            Radius * Mathf.Sin(ElevationRad) * Mathf.Cos(AzimuthRad),
            Radius * Mathf.Cos(ElevationRad),
            Radius * Mathf.Sin(ElevationRad) * Mathf.Sin(AzimuthRad));
    }

    public void AddDirectionDeg(Vector2 directionDeg)
    {
        float speed = Mathf.Deg2Rad * rotationSpeed;
        AzimuthRad +=  directionDeg.x * speed;
        ElevationRad +=  directionDeg.y * speed;

        ElevationRad = Mathf.Clamp(ElevationRad, minElevationRad, maxElevationRad);
    }
}
