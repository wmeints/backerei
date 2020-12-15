namespace Backerei.Catalog.Domain
{
    /// <summary>
    /// Defines the shape of the cake.
    /// </summary>
    public class CakeShape
    {
        /// <summary>
        /// A blob-shaped cake. We don't know.
        /// </summary>
        public static CakeShape Unknown = new CakeShape(0, "Unknown");
        
        /// <summary>
        /// A round cake.
        /// </summary>
        public static CakeShape Round = new CakeShape(1, "Round");
        
        /// <summary>
        /// A square cake.
        /// </summary>
        public static CakeShape Square = new CakeShape(2, "Square");

        
        
        /// <summary>
        /// Initializes a new instance of <see cref="CakeShape"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private CakeShape(int id, string name)
        {
            
        }   
        
        /// <summary>
        /// Gets the ID of the shape.
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// Gets the name of the shape.
        /// </summary>
        public string Name { get; }

        protected bool Equals(CakeShape other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            
            return Equals((CakeShape) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}