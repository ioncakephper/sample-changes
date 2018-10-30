//-----------------------------------------------------------------------
// <copyright file="changeDetector.cs" company="Ion Gireada">
//     Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ChangeDetectorControlLibrary
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the ChangeDetector class.
    /// </summary>
    public partial class ChangeDetector : Component
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDetector"/> class.
        /// </summary>
        public ChangeDetector()
        {
            InitializeComponent();
            InitializeProperties();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDetector"/> class.
        /// </summary>
        /// <param name="container">The containing container.</param>
        public ChangeDetector(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeProperties();
        }

        /// <summary>
        /// Defines the ChangeDetecting event.
        /// </summary> 
        [Description("Occurs whenever the form looks for changes in its content, before the form looks for changes.")]
        public event EventHandler<ChangeDetectingEventArgs> ChangeDetecting;

        /// <summary>
        /// Defines the Change event.
        /// </summary>
        [Description("Occurs whenever the form looks for changes in its content.")]
        public event EventHandler<ChangeOccurredEventArgs> Change;

        /// <summary>
        /// Defines the ChangeDetected event.
        /// </summary>
        [Description("Occurs whenever the form looks for changes in its content, after the form looks for changes.")]
        public event EventHandler<ConfirmationActionEventArgs> ChangeDetected;

        /// <summary>
        /// Gets or sets the InformationMessage.
        /// </summary>
        [Browsable(true)]
        [Description("The message to show in MessageBox")]
        [DefaultValue("Changes occurred and closing now will lose the changes. Do you want to close?")]
        public string InformationMessage { get; set; }

        /// <summary>
        /// Gets or sets the InformationCaption.
        /// </summary>
        [Browsable(true)]
        [Description("The caption to show in MessageBox")]
        [DefaultValue("Confirm Closing")]
        public string InformationCaption { get; set; }

        /// <summary>
        /// Gets or sets the BoxButtons.
        /// </summary>
        [Browsable(true)]
        [Description("The button set to show in MessageBox")]
        [DefaultValue(MessageBoxButtons.YesNoCancel)]
        public MessageBoxButtons BoxButtons { get; set; }

        /// <summary>
        /// Gets or sets the BoxIcon.
        /// </summary>
        [Browsable(true)]
        [Description("The icon to show in MessageBox")]
        [DefaultValue(MessageBoxIcon.Warning)]
        public MessageBoxIcon BoxIcon { get; set; }

        /// <summary>
        /// Gets or sets the BoxCancel.
        /// </summary>
        [Browsable(true)]
        [Description("The button pressed in MessageBox to cancel form closing")]
        [DefaultValue(DialogResult.Cancel)]
        public DialogResult BoxCancel { get; set; }

        /// <summary>
        /// Check whether form should be closed.
        /// </summary>
        /// <param name="sender">The form or dialog to close.</param>
        /// <returns>Returns true if <cref="sender" /> should be closed, false otherwise.</returns>
        public bool CancelFormClosing(object sender)
        {
            ChangeDetectingEventArgs e = new ChangeDetectingEventArgs(sender, false);
            OnChangeDetecting(e);
            if (!e.Cancel)
            {
                ChangeOccurredEventArgs changedOccurredEvent = new ChangeOccurredEventArgs(sender, false);
                OnChange(changedOccurredEvent);
                if (changedOccurredEvent.ChangedOccurred)
                {
                    DialogResult result = MessageBox.Show(this.InformationMessage, this.InformationCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (!result.Equals(BoxCancel))
                    {
                        OnChangeDetected(new ConfirmationActionEventArgs(sender, result));
                        return false;
                    }

                    return true;
                }
            }
            return e.Cancel;
        }

        /// <summary>
        /// Invoke <cref="Change" /> event.
        /// </summary>
        /// <param name="e">The <cref="ChangeOccurredEventArgs" /> type event arguments.</param>
        protected virtual void OnChange(ChangeOccurredEventArgs e)
        {
            if (Change != null)
            {
                Change(this, e);
            }
        }

        /// <summary>
        /// Invoke <cref="ChangeDetecting" /> event.
        /// </summary>
        /// <param name="e">The <cref="CancelEventArgs" /> type event arguments.</param>
        protected virtual void OnChangeDetecting(ChangeDetectingEventArgs e)
        {
            if (ChangeDetecting != null)
            {
                ChangeDetecting(this, e);
            }
        }

        /// <summary>
        /// Invoke <cref="ChangeEvent" /> event.
        /// </summary>
        /// <param name="e">The <cref="ConfirmationActionEventArgs" /> type event arguments.</param>
        protected virtual void OnChangeDetected(ConfirmationActionEventArgs e)
        {
            if (ChangeDetected != null)
            {
                ChangeDetected(this, e);
            }
        }

        /// <summary>
        /// Initializes properties.
        /// </summary>
        private void InitializeProperties()
        {
            InformationMessage = "Changes occurred and closing now will lose the changes. Do you want to close?";
            InformationCaption = "Confirm Closing";
            BoxButtons = MessageBoxButtons.YesNoCancel;
            BoxIcon = MessageBoxIcon.Warning;
            BoxCancel = DialogResult.Cancel;
        }
    }
}
