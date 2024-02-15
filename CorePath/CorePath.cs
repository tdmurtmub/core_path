using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace tdmm.FileSystem    
{
    /// <summary>
    /// Defines a platform independent class for specifying file and/or
    /// directory resources within a hierarchical file structure.
    /// </summary>
    public sealed class CorePath
    {
        /// <summary>
        /// Maximum length of a path and/or segment name.
        /// </summary>
        public const int MaxLength = 255;

        /// <summary>
        /// Generates a CorePath value with the given hierarchical structure.
        /// </summary>
        /// <param name="segments">Specifies the individual segments of the path hierarchy
        /// as a list of comma separated strings or a single array of strings.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public CorePath(params string[] segments)
        {
            segments.ToList().ForEach(ValidateSegmentName);
            this.path = segments.ToList();
            if (ToString().Length > MaxLength)
            {
                throw new ArgumentException($"Full path exceeds maximum length of {MaxLength} characters.");
            }
        }

        /// <summary>
        /// Exception thrown when any segment of the path contains invalid characters.
        /// </summary>
        public class SegmentNameException : Exception
        {
            /// <summary>
            /// Constructs the exception for named segment.
            /// </summary>
            /// <param name="name">The segment name.</param>
            public SegmentNameException(string name) : base($"Segment naming error: [{name}] Valid characters are A-Z, a-z, 0-9, underscore (_), dash (-) and dot (.)") { }
        }

        /// <summary>
        /// Creates the platform specific path for this value.
        /// </summary>
        /// <returns>The full path expanded for the platform.</returns>
        public override string ToString() => Path.Combine(path.ToArray());

        private static void ValidateSegmentName(string name)
        {
            if (name.Length > MaxLength)
            {
                throw new ArgumentException($"Segment name exceeds maximum length of {MaxLength} characters.");
            }
            if (!Regex.IsMatch(name, "^[a-zA-Z_0-9.-]+$"))
            {
                throw new SegmentNameException(name);
            }
        }

        private readonly IList<string> path;
    }
}