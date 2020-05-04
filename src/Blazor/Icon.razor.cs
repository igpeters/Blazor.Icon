// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Mobsites.Blazor
{
    /// <summary>
    /// UI component for rendering an icon.
    /// </summary>
    public sealed partial class Icon
    {
        /****************************************************
        *
        *  PUBLIC INTERFACE
        *
        ****************************************************/

        /// <summary>
        /// Material Icon ligature or textual name.
        /// </summary>
        [Parameter] public string Variant { get; set; }

        /// <summary>
        /// Call back event for notifying another component that this property changed.
        /// </summary>
        [Parameter] public EventCallback<string> VariantChanged { get; set; }

        /// <summary>
        /// A URL or a URL fragment to the image source.
        /// </summary>
        [Parameter] public string Image { get; set; }

        /// <summary>
        /// Call back event for notifying another component that this property changed. 
        /// </summary>
        [Parameter] public EventCallback<string> ImageChanged { get; set; }

        /// <summary>
        /// A URL or a URL fragment to the image source to use in dark mode.
        /// Ignored if Image is not set.
        /// </summary>
        [Parameter] public string DarkModeImage { get; set; }

        /// <summary>
        /// A URL or a URL fragment to the image source to use in light mode.
        /// Ignored if Image is not set.
        /// </summary>
        [Parameter] public string LightModeImage { get; set; }

        /// <summary>
        /// The size of icon to render. Defaults to 24px.
        /// </summary>
        [Parameter] public Sizes Size { get; set; }

        /// <summary>
        /// Call back event for notifying another component that this property changed. 
        /// </summary>
        [Parameter] public EventCallback<Sizes> SizeChanged { get; set; }

        /// <summary>
        /// Optional accompanying text to display.
        /// </summary>
        [Parameter] public string Text { get; set; }

        /// <summary>
        /// Call back event for notifying another component that this property changed. 
        /// </summary>
        [Parameter] public EventCallback<string> TextChanged { get; set; }

        /// <summary>
        /// Margin spacing between icon and accompanying text. 
        /// Ignored when text is empty.
        /// </summary>
        [Parameter] public int Spacing { get; set; }

        /// <summary>
        /// Call back event for notifying another component that this property changed. 
        /// </summary>
        [Parameter] public EventCallback<int> SpacingChanged { get; set; }

        /// <summary>
        /// Whether a pointer cursor should show up on desktops.
        /// </summary>
        [Parameter] public bool Clickable { get; set; }

        /// <summary>
        /// Clear all state for this UI component and any of its dependents from browser storage.
        /// </summary>
        public ValueTask ClearState() => this.ClearState<Icon, Options>();



        /****************************************************
        *
        *  NON-PUBLIC INTERFACE
        *
        ****************************************************/

        /// <summary>
        /// Life cycle method for when component has been rendered in the dom and javascript interopt is fully ready.
        /// </summary>
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            var options = await this.GetState<Icon, Options>();

            if (firstRender)
            {
                if (options is null)
                {
                    options = this.GetOptions();
                }
                else
                {
                    await this.CheckState(options);
                }

                initialized = true;
            }
            else
            {
                // Use current state if...
                if (this.initialized || options is null)
                {
                    options = this.GetOptions();
                }
            }

            await this.Save<Icon, Options>(options);
        }

        /// <summary>
        /// Get current or storage-saved options for keeping state.
        /// </summary>
        internal Options GetOptions()
        {
            var options = new Options
            {
                Variant = this.Variant,
                Size = this.Size,
                Text = this.Text,
                Spacing = this.Spacing
            };

            base.SetOptions(options);

            return options;
        }

        /// <summary>
        /// Check whether storage-retrieved options are different than current
        /// and thereby need to notify parents of change when keeping state.
        /// </summary>
        internal async Task CheckState(Options options)
        {
            bool stateChanged = false;

            if (this.Variant != options.Variant)
            {
                this.Variant = options.Variant;
                await this.VariantChanged.InvokeAsync(this.Variant);
                stateChanged = true;
            }
            if (this.Size != (options.Size ?? Sizes.Default))
            {
                this.Size = options.Size ?? Sizes.Default;
                await this.SizeChanged.InvokeAsync(this.Size);
                stateChanged = true;
            }
            if (this.Text != options.Text)
            {
                this.Text = options.Text;
                await this.TextChanged.InvokeAsync(this.Text);
                stateChanged = true;
            }
            if (this.Spacing != (options.Spacing ?? 0))
            {
                this.Spacing = options.Spacing ?? 0;
                await this.SpacingChanged.InvokeAsync(this.Spacing);
                stateChanged = true;
            }

            if (await base.CheckState(options) || stateChanged)
                StateHasChanged();
        }
    }
}