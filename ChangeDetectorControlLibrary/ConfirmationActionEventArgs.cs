//------------------------------------------------------------------------------------
// <copyright file="confirmationactioneventargs.cs" company="Ion Gireada">
//    Copyright (c) 2018 Ion Gireada
// </copyright>
//------------------------------------------------------------------------------------

namespace ChangeDetectorControlLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="ConfirmationActionEventArgs" />
    /// </summary>
    public class ConfirmationActionEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the DialogResult
        /// </summary>
        public System.Windows.Forms.DialogResult DialogResult { get; set; }

        /// <summary>
        /// Gets or sets the Sender
        /// </summary>
        public object Sender { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationActionEventArgs"/> class.
        /// </summary>
        /// <param name="result">The result<see cref="System.Windows.Forms.DialogResult"/></param>
        public ConfirmationActionEventArgs(System.Windows.Forms.DialogResult result) : this()
        {
            this.DialogResult = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationActionEventArgs"/> class.
        /// </summary>
        public ConfirmationActionEventArgs()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Sender = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationActionEventArgs"/> class.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="result">The result<see cref="System.Windows.Forms.DialogResult"/></param>
        public ConfirmationActionEventArgs(object sender, System.Windows.Forms.DialogResult result) : this(result)
        {
            this.Sender = sender;
        }
    }
}
