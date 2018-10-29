//-----------------------------------------------------------------------
// <copyright file="ChangeOccurredEventArgs.cs" company="Ion Gireada">
//     Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ChangeDetectorControlLibrary
{
    using System;

    /// <summary>
    /// Provides data for the ChangedOccurrent event.
    /// </summary>
    public class ChangeOccurredEventArgs : EventArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeOccurredEventArgs"/> class.
        /// </summary>
        /// <param name="changedOccurred">The value of property.</param>
        public ChangeOccurredEventArgs(bool changedOccurred)
            : this()
        {
            this.ChangedOccurred = changedOccurred;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeOccurredEventArgs"/> class.
        /// </summary>
        public ChangeOccurredEventArgs()
        {
            ChangedOccurred = false;
            Sender = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeOccurredEventArgs"/> class.
        /// </summary>
        public ChangeOccurredEventArgs(object sender, bool p) : this(p)
        {
            // TODO: Complete member initialization
            this.Sender = sender;
        }

        /// <summary>
        /// Gets or sets a value indicating whether a changed occurred.
        /// </summary>
        public bool ChangedOccurred { get; set; }

        /// <summary>
        /// Gets or sets the sending object.
        /// </summary>
        public object Sender { get; set; }
    }
}
