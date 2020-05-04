// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Mobsites.Blazor
{
    public partial class Icon
    {
        /// <summary>
        /// Abstract base representing options that can be saved in browser storage.
        /// </summary>
        internal class Options : StatefulComponentOptions
        {
            /************************************************************************
            *
            *   Non-null enum and int members with a zero value do not need to be
            *   serialized as they would default to zero on C# object initialization.
            *   
            *   (For nullable types...well null is null.)
            *
            *   Setting their options equivalent to null will keep them from
            *   being serialized.
            *
            *   This saves space in browser storage.
            *
            *   Caveat: If the options are passed into a javascript function,
            *   then, obviously, any such members depended on there will have to 
            *   be accounted for there as not defined.
            *
            ***********************************************************************/

            /// <summary>
            /// Option for Material Icon ligature or textual name.
            /// </summary>
            public string Variant { get; set; }

            private Sizes? size;

            /// <summary>
            /// Option for the size of icon to render. Defaults to 24px.
            /// </summary>
            public Sizes? Size
            {
                get => size;
                set => size = this.NullOnZero<Sizes?>(value);
            }

            /// <summary>
            /// Option for optional accompanying text to display.
            /// </summary>
            public string Text { get; set; }

            private int? spacing;

            /// <summary>
            /// Option for margin spacing between icon and accompanying text. 
            /// </summary>
            public int? Spacing
            {
                get => spacing;
                set => spacing = this.NullOnZero<int?>(value);
            }

        }
    }
}