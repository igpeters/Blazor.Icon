// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Components;

namespace Mobsites.Blazor
{
    /// <summary>
    /// Material icon component.
    /// </summary>
    public partial class Icon
    {
        /// <summary>
        /// The variant of icon to render.
        /// </summary>
        [Parameter] public string Variant { get; set; }

        /// <summary>
        /// The size of icon to render.
        /// </summary>
        [Parameter] public Sizes Size { get; set; }

        /// <summary>
        /// Text that should accompany the icon.
        /// </summary>
        [Parameter] public string Text { get; set; }

        /// <summary>
        /// Margin spacing between icon and accompanying text. Ignored when text is empty.
        /// </summary>
        [Parameter] public int Spacing { get; set; }

        /// <summary>
        /// Whether the icon should show an inactive state.
        /// </summary>
        [Parameter] public bool Inactive { get; set; }

        /// <summary>
        /// Any valid css color usage.
        /// </summary>
        [Parameter] public string InactiveColor { get; set; }

        private string @class;

        /// <summary>
        /// Styles for directly affecting this component go here.
        /// </summary>
        [Parameter] public override string Class
        { 
            get 
            {
                string size = this.Size > 0 ? $"md-{(int)this.Size}" : null;

                return $"{size} {@class}";
            }
            set => @class = value; 
        }
    }
}