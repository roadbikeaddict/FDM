namespace FDM
{
    // ReSharper disable InconsistentNaming

    // Moments L, M, N
    public enum Moments
    {
        eL = 1,
        eM = 2,
        eN = 3
    }

    // Rates P, Q, R
    public enum Rates
    {
        eP = 1, 
        eQ = 2,     
        eR = 3
    };

    /// Velocities U, V, W
    public enum Velocities
    {
        eU = 1,
        eV = 2,
        eW = 3
    };

    /// Positions X, Y, Z
    public enum Positions
    {
        eX = 1,
        eY = 2,
        eZ = 3
    };

    /// Euler angles Phi, Theta, Psi
    public enum EulerAngles
    {
        ePhi = 1, 
        eTht = 2,   
        ePsi =3
    };

    /// Stability axis forces, Drag, Side force, Lift
    public enum StabilityAxisForces
    {
        eDrag = 1, 
        eSide = 2,  
        eLift = 3
    };

    /// Local frame orientation Roll, Pitch, Yaw
    public enum LocalFrameOrientation
    {
        eRoll = 1,
        ePitch = 2,
        eYaw = 3
    };

    /// Local frame position North, East, Down
    public enum LocalFramePosition
    {
        eNorth = 1, 
        eEast = 2,  
        eDown = 3
    };

    /// Locations Radius, Latitude, Longitude
    public enum Location
    {
        eLat = 1, 
        eLong = 2, 
        eRad = 3
    };

    /// Conversion specifiers
    public enum ConversionSpecifiers
    {
        inNone = 0, 
        inDegrees = 1, 
        inRadians = 2, 
        inMeters = 3, 
        inFeet = 4
    };

    public enum MessageType
    {
        eText = 0, 
        eInteger = 1, 
        eDouble = 2,
        eBool = 3
    }

    // ReSharper restore InconsistentNaming
 }