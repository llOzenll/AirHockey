public struct Boundary{
    public float UpLimit, DownLimit, LeftLimit, RightLimit;

    public Boundary(float up, float down, float left, float right)
    {
        UpLimit = up; DownLimit = down; LeftLimit = left; RightLimit = right;
    }
}