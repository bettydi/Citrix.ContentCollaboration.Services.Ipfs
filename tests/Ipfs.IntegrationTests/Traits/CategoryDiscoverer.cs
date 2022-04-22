using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Ipfs.IntegrationTests
{
    /// <summary>
    /// This class discovers all of the tests and test classes that have
    /// applied the Category attribute
    /// </summary>
    public class CategoryDiscoverer : ITraitDiscoverer
    {
        internal const string Namespace = nameof(Ipfs) + "." + nameof(IntegrationTests);
        internal const string FullyQualifiedName = Namespace + "." + nameof(CategoryDiscoverer);

        /// <summary>
        /// Gets the trait values from the Category attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing the trait values.</param>
        /// <returns>The trait values.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var category = traitAttribute.GetNamedArgument<string>("Category");
            if (category != null)
            {
                yield return new KeyValuePair<string, string>("Category", category);
            }
        }
    }
}
