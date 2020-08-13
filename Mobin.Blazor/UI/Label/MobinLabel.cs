using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using Mobin.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mobin.Blazor.UI
{
    public class MobinLabel<TValue> : ComponentBase
    {
        /// <summary>
        /// Specifies the field for which validation messages should be displayed.
        /// </summary>
        [Parameter] public Expression<Func<TValue>> DisplayFor { get; set; }


        /// <summary>
        /// This is like 'for' attribute in html label tag element and set focus on 'For' specified attribute when you click on label
        /// </summary>
        [Parameter] public Expression<Func<TValue>> For { get; set; }

        [CascadingParameter] EditContext CascadedEditContext { get; set; }

        /// <summary>
        /// Gets or sets a collection of additional attributes that will be applied to the created element.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

        /// <summary>
        /// Gets the associated <see cref="Forms.EditContext"/>.
        /// </summary>
        protected EditContext EditContext { get; set; }

        /// <summary>
        /// Gets the <see cref="FieldIdentifier"/> for the bound value.
        /// </summary>
        protected FieldIdentifier FieldIdentifier { get; set; }


        /// <inheritdoc />
        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            if (EditContext == null)
            {
                // This is the first run
                // Could put this logic in OnInit, but its nice to avoid forcing people who override OnInit to call base.OnInit()

                if (CascadedEditContext == null)
                {
                    throw new InvalidOperationException($"{GetType()} requires a cascading parameter " +
                        $"of type {nameof(EditContext)}. For example, you can use {GetType().FullName} inside " +
                        $"an {nameof(EditForm)}.");
                }

                EditContext = CascadedEditContext;
            }
            else if (CascadedEditContext != EditContext)
            {
                // Not the first run

                // We don't support changing EditContext because it's messy to be clearing up state and event
                // handlers for the previous one, and there's no strong use case. If a strong use case
                // emerges, we can consider changing this.
                throw new InvalidOperationException($"{GetType()} does not support changing the " +
                    $"{nameof(EditContext)} dynamically.");
            }

            // For derived components, retain the usual lifecycle with OnInit/OnParametersSet/etc.
            return base.SetParametersAsync(ParameterView.Empty);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            DisplayAttribute displayAttr = Utility.ModelMetadata.GetAttribute<DisplayAttribute>(DisplayFor);
            DisplayAttribute forAttr = Utility.ModelMetadata.GetAttribute<DisplayAttribute>(For);
            int counter = 0;
            builder.OpenElement(counter, "label");
            builder.AddMultipleAttributes(counter++, AdditionalAttributes);

            if (displayAttr != null && !string.IsNullOrEmpty(displayAttr.Name))
                builder.AddContent(counter++, displayAttr.Name);

            if (forAttr != null && !string.IsNullOrEmpty(forAttr.Name))
                builder.AddContent(counter++, forAttr.Name);

            builder.CloseElement();
        }
    }


    //public class MobinDatePicker : ComponentBase
    //{
    //    [Inject]
    //    protected IJSRuntime JS { get; set; }

    //    protected internal ElementReference _mobinDatePickerElement { get; set; }

    //    protected override async Task OnAfterRenderAsync(bool firstRender)
    //    {
    //        if (firstRender)
    //        {
    //            await JS.InvokeVoidAsync("mobinDatePicker", _mobinDatePickerElement);
    //        }
    //    }

    //    protected override void BuildRenderTree(RenderTreeBuilder builder)
    //    {
    //        base.BuildRenderTree(builder);
    //    }
    //}






    ///// <summary>
    ///// A base class for form input components. This base class automatically
    ///// integrates with an <see cref="Forms.EditContext"/>, which must be supplied
    ///// as a cascading parameter.
    ///// </summary>
    //public class MobinDatePicker : ComponentBase, IDisposable
    //{
    //    [Inject]
    //    protected IJSRuntime JS { get; set; }
    //    protected internal ElementReference _mobinDatePickerElement { get; set; }
    //    private ValidationMessageStore _parsingValidationMessages;
    //    private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;
    //    private Type _nullableUnderlyingType;

    //    [CascadingParameter] EditContext CascadedEditContext { get; set; }

    //    /// <summary>
    //    /// Gets or sets a collection of additional attributes that will be applied to the created element.
    //    /// </summary>
    //    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    //    /// <summary>
    //    /// Gets or sets the value of the input. This should be used with two-way binding.
    //    /// </summary>
    //    /// <example>
    //    /// @bind-Value="model.PropertyName"
    //    /// </example>
    //    [Parameter] public DateTime Value { get; set; }

    //    /// <summary>
    //    /// Gets or sets the current value of the input.
    //    /// </summary>
    //    protected DateTime CurrentValue
    //    {
    //        get => Value;
    //        set
    //        {
    //            var hasChanged = !EqualityComparer<DateTime>.Default.Equals(value, Value);
    //            if (hasChanged)
    //            {
    //                Value = value;
    //                _ = ValueChanged.InvokeAsync(value);
    //                EditContext.NotifyFieldChanged(FieldIdentifier);
    //            }
    //        }
    //    }

    //    public MobinDatePicker()
    //    {
    //        _validationStateChangedHandler = (sender, eventArgs) => StateHasChanged();
    //    }

    //    /// <summary>
    //    /// Formats the value as a string. Derived classes can override this to determine the formating used for <see cref="CurrentValueAsString"/>.
    //    /// </summary>
    //    /// <param name="value">The value to format.</param>
    //    /// <returns>A string representation of the value.</returns>
    //    protected virtual string FormatValueAsString(DateTime value)
    //        => value.ToString();

    //    /// <inheritdoc />
    //    protected override void BuildRenderTree(RenderTreeBuilder builder)
    //    {
    //        builder.OpenElement(0, "input");
    //        builder.AddAttribute(1, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
    //        builder.AddElementReferenceCapture(2, capturedRef => { _mobinDatePickerElement = capturedRef; });
    //        builder.CloseElement();
    //    }

    //    protected override async Task OnAfterRenderAsync(bool firstRender)
    //    {
    //        if (firstRender)
    //        {
    //            DateTime? gregorianDate = await JS.InvokeAsync<DateTime>("getGregorianDate", _mobinDatePickerElement);
    //            if (gregorianDate.HasValue)
    //                Value = gregorianDate.Value;
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets a callback that updates the bound value.
    //    /// </summary>
    //    [Parameter] public EventCallback<DateTime> ValueChanged { get; set; }

    //    /// <summary>
    //    /// Gets or sets an expression that identifies the bound value.
    //    /// </summary>
    //    [Parameter] public Expression<Func<DateTime>> ValueExpression { get; set; }

    //    /// <summary>
    //    /// Gets the associated <see cref="Forms.EditContext"/>.
    //    /// </summary>
    //    protected EditContext EditContext { get; set; }

    //    /// <summary>
    //    /// Gets the <see cref="FieldIdentifier"/> for the bound value.
    //    /// </summary>
    //    protected FieldIdentifier FieldIdentifier { get; set; }


    //    /// <summary>
    //    /// Gets a string that indicates the status of the field being edited. This will include
    //    /// some combination of "modified", "valid", or "invalid", depending on the status of the field.
    //    /// </summary>
    //    private string FieldClass
    //        => EditContext.FieldCssClass(FieldIdentifier);

    //    /// <summary>
    //    /// Gets a CSS class string that combines the <c>class</c> attribute and <see cref="FieldClass"/>
    //    /// properties. Derived components should typically use this value for the primary HTML element's
    //    /// 'class' attribute.
    //    /// </summary>
    //    protected string CssClass
    //    {
    //        get
    //        {
    //            if (AdditionalAttributes != null &&
    //                AdditionalAttributes.TryGetValue("class", out var @class) &&
    //                !string.IsNullOrEmpty(Convert.ToString(@class)))
    //            {
    //                return $"{@class} {FieldClass}";
    //            }

    //            return FieldClass; // Never null or empty
    //        }
    //    }


    //    /// <inheritdoc />
    //    public override Task SetParametersAsync(ParameterView parameters)
    //    {
    //        parameters.SetParameterProperties(this);

    //        if (EditContext == null)
    //        {
    //            // This is the first run
    //            // Could put this logic in OnInit, but its nice to avoid forcing people who override OnInit to call base.OnInit()

    //            if (CascadedEditContext == null)
    //            {
    //                throw new InvalidOperationException($"{GetType()} requires a cascading parameter " +
    //                    $"of type {nameof(Microsoft.AspNetCore.Components.Forms.EditContext)}. For example, you can use {GetType().FullName} inside " +
    //                    $"an {nameof(EditForm)}.");
    //            }

    //            if (ValueExpression == null)
    //            {
    //                throw new InvalidOperationException($"{GetType()} requires a value for the 'ValueExpression' " +
    //                    $"parameter. Normally this is provided automatically when using 'bind-Value'.");
    //            }

    //            EditContext = CascadedEditContext;
    //            FieldIdentifier = FieldIdentifier.Create(ValueExpression);
    //            _nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(DateTime));

    //            EditContext.OnValidationStateChanged += _validationStateChangedHandler;
    //        }
    //        else if (CascadedEditContext != EditContext)
    //        {
    //            // Not the first run

    //            // We don't support changing EditContext because it's messy to be clearing up state and event
    //            // handlers for the previous one, and there's no strong use case. If a strong use case
    //            // emerges, we can consider changing this.
    //            throw new InvalidOperationException($"{GetType()} does not support changing the " +
    //                $"{nameof(Microsoft.AspNetCore.Components.Forms.EditContext)} dynamically.");
    //        }

    //        // For derived components, retain the usual lifecycle with OnInit/OnParametersSet/etc.
    //        return base.SetParametersAsync(ParameterView.Empty);
    //    }

    //    protected virtual void Dispose(bool disposing)
    //    {
    //    }

    //    void IDisposable.Dispose()
    //    {
    //        if (EditContext != null)
    //        {
    //            EditContext.OnValidationStateChanged -= _validationStateChangedHandler;
    //        }

    //        Dispose(disposing: true);
    //    }
    //}
}