//------------------------------------------------------------------------------------
// <copyright file="ChangeDetectingEventArgs.cs" company="Ion Gireada">
//    Copyright (c) 2018 Ion Gireada
// </copyright>
//------------------------------------------------------------------------------------
namespace ChangeDetectorControlLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="ChangeDetectingEventArgs" />
    /// </summary>
    public class ChangeDetectingEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDetectingEventArgs"/> class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="p"></param>
        public ChangeDetectingEventArgs(object sender, bool p)
            : this(p)
        {
            this.Sender = sender;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDetectingEventArgs"/> class.
        /// </summary>
        /// <param name="p"></param>
        public ChangeDetectingEventArgs(bool p)
            : this()
        {
            this.Cancel = p;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDetectingEventArgs"/> class.
        /// </summary>
        public ChangeDetectingEventArgs()
        {
            Cancel = false;
            Sender = null;
        }

        /// <summary>
        /// Gets or sets the Sender.
        /// </summary>
        public object Sender { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether change detection event should be Canceled.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
