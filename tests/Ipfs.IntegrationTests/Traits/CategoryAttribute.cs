using System;
using Xunit.Sdk;

namespace Ipfs.IntegrationTests.Traits
{
    /// <summary>
    /// Apply this attribute to your test method to specify a category.
    /// </summary>
    [TraitDiscoverer(CategoryDiscoverer.FullyQualifiedName, CategoryDiscoverer.Namespace)]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CategoryAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Gets the value of the Category trait.
        /// </summary>
        public string Category { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryAttribute"/> class
        /// </summary>
        /// <param name="category">The category name to apply to a test</param>
        public CategoryAttribute(string category)
        {
            Category = category;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryAttribute"/> class
        /// </summary>
        protected CategoryAttribute()
        {
        }
    }

    /// <summary>
    /// A category representing critical smoke tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SmokeAttribute : CategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmokeAttribute"/> class
        /// </summary>
        public SmokeAttribute()
            : base("Smoke")
        {
        }
    }
}
