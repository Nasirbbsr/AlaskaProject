namespace Alaska.Model.ModelConstraint
{
    public interface IPrimaryKey<T>
          where T : struct
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        T Id { get; set; }
    }
}
