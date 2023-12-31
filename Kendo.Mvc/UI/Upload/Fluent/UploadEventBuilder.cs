using System;
using System.Collections.Generic;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring the Kendo UI Upload for ASP.NET MVC events.
    /// </summary>
    public class UploadEventBuilder : EventBuilder
    {
        public UploadEventBuilder(IDictionary<string, object> events)
            : base(events)
        {
        }

        /// <summary>
        /// Fires when the upload has been cancelled while in progress.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the cancel event.</param>
        public UploadEventBuilder Cancel(string handler)
        {
            Handler("cancel", handler);

            return this;
        }

        /// <summary>
        /// Fires when the upload has been cancelled while in progress.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Cancel(Func<object, object> handler)
        {
            Handler("cancel", handler);

            return this;
        }

        /// <summary>
        /// Triggered when files are cleared by clicking on the "Clear" button. Note: Cancelling this event will prevent the clearing the selected files.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the clear event.</param>
        public UploadEventBuilder Clear(string handler)
        {
            Handler("clear", handler);

            return this;
        }

        /// <summary>
        /// Triggered when files are cleared by clicking on the "Clear" button. Note: Cancelling this event will prevent the clearing the selected files.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Clear(Func<object, object> handler)
        {
            Handler("clear", handler);

            return this;
        }

        /// <summary>
        /// Fires when all active uploads have completed either successfully or with errors.Note: The complete event fires only when the upload is in\n\t\t/// async mode.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the complete event.</param>
        public UploadEventBuilder Complete(string handler)
        {
            Handler("complete", handler);

            return this;
        }

        /// <summary>
        /// Fires when all active uploads have completed either successfully or with errors.Note: The complete event fires only when the upload is in\n\t\t/// async mode.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Complete(Func<object, object> handler)
        {
            Handler("complete", handler);

            return this;
        }

        /// <summary>
        /// Fires when an upload / remove operation has failed.Note: The error event fires only when the upload is in\n\t\t/// async mode.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the error event.</param>
        public UploadEventBuilder Error(string handler)
        {
            Handler("error", handler);

            return this;
        }

        /// <summary>
        /// Fires when an upload / remove operation has failed.Note: The error event fires only when the upload is in\n\t\t/// async mode.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Error(Func<object, object> handler)
        {
            Handler("error", handler);

            return this;
        }

        /// <summary>
        /// Triggered when the files are cleared by clicking the Pause button. The button is visible if chunksize is set.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the pause event.</param>
        public UploadEventBuilder Pause(string handler)
        {
            Handler("pause", handler);

            return this;
        }

        /// <summary>
        /// Triggered when the files are cleared by clicking the Pause button. The button is visible if chunksize is set.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Pause(Func<object, object> handler)
        {
            Handler("pause", handler);

            return this;
        }

        /// <summary>
        /// Fires when the data about the progress of the upload is available.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the progress event.</param>
        public UploadEventBuilder Progress(string handler)
        {
            Handler("progress", handler);

            return this;
        }

        /// <summary>
        /// Fires when the data about the progress of the upload is available.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Progress(Func<object, object> handler)
        {
            Handler("progress", handler);

            return this;
        }

        /// <summary>
        /// Fires when the files are resumed through clicking the Resume button. The button is visible if chunksize is set and the file upload is paused.The following example demonstrates how to wire up an event handler that is triggered when a user resumes a selected file.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the resume event.</param>
        public UploadEventBuilder Resume(string handler)
        {
            Handler("resume", handler);

            return this;
        }

        /// <summary>
        /// Fires when the files are resumed through clicking the Resume button. The button is visible if chunksize is set and the file upload is paused.The following example demonstrates how to wire up an event handler that is triggered when a user resumes a selected file.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Resume(Func<object, object> handler)
        {
            Handler("resume", handler);

            return this;
        }

        /// <summary>
        /// Fires when an uploaded file is about to be removed. If the event is canceled, the remove operation is prevented.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the remove event.</param>
        public UploadEventBuilder Remove(string handler)
        {
            Handler("remove", handler);

            return this;
        }

        /// <summary>
        /// Fires when an uploaded file is about to be removed. If the event is canceled, the remove operation is prevented.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Remove(Func<object, object> handler)
        {
            Handler("remove", handler);

            return this;
        }

        /// <summary>
        /// Triggered when a files is selected. Note: Cancelling this event will prevent the selection from\n\t\t/// occurring.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the select event.</param>
        public UploadEventBuilder Select(string handler)
        {
            Handler("select", handler);

            return this;
        }

        /// <summary>
        /// Triggered when a files is selected. Note: Cancelling this event will prevent the selection from\n\t\t/// occurring.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Select(Func<object, object> handler)
        {
            Handler("select", handler);

            return this;
        }

        /// <summary>
        /// Fires when an upload / remove operation has been completed successfully.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the success event.</param>
        public UploadEventBuilder Success(string handler)
        {
            Handler("success", handler);

            return this;
        }

        /// <summary>
        /// Fires when an upload / remove operation has been completed successfully.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Success(Func<object, object> handler)
        {
            Handler("success", handler);

            return this;
        }

        /// <summary>
        /// Fires when one or more files are about to be uploaded.\n\t\t/// Canceling the event will prevent the upload.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the upload event.</param>
        public UploadEventBuilder Upload(string handler)
        {
            Handler("upload", handler);

            return this;
        }

        /// <summary>
        /// Fires when one or more files are about to be uploaded.\n\t\t/// Canceling the event will prevent the upload.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public UploadEventBuilder Upload(Func<object, object> handler)
        {
            Handler("upload", handler);

            return this;
        }

    }
}

