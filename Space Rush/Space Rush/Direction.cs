namespace Space_Rush
{
    public class Direction
    {
        private bool isActive;
        private Vector2d acceleration;

        public Direction(bool isActive, Vector2d acceleration)
        {
            this.isActive = isActive;
            this.acceleration = acceleration;
        }

        public bool IsActive()
        {
            return this.isActive;
        }

        public Vector2d GetAcceleration()
        {
            return this.acceleration;
        }

        public void IsActive(bool isActive)
        {
            this.isActive = isActive;
        }

        public void SetAcceleration(Vector2d acceleration)
        {
            this.acceleration = acceleration;
        }
    }
}
