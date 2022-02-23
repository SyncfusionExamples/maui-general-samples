using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattedText
{
    public class HyperlinkUI : Span
    {
        public static readonly BindableProperty LinkUrlProperty =
            BindableProperty.Create(nameof(LinkUrl), typeof(string), typeof(HyperlinkUI), null);

        public string LinkUrl
        {
            get
            {
                return (string)GetValue(LinkUrlProperty);
            }
            set
            {
                SetValue(LinkUrlProperty, value);
            }
        }

        public HyperlinkUI()
        {
            ApplyHyperlinkAppearance();
        }

        void ApplyHyperlinkAppearance()
        {
            this.TextColor = Color.FromArgb("#0000EE");
            this.TextDecorations = TextDecorations.Underline;
        }

        void CreateNavgigationCommand()
        {
            //... Since Span inherits GestureElement, you can add Gesture Recognizer to navigate using LinkUrl
        }

    }
}
