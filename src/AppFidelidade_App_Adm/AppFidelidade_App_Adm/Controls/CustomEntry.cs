using System;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.Controls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(CustomEntry), 0);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set{ SetValue(MaxLengthProperty, value); }
        }

        public CustomEntry()
        {
            TextChanged += (s, e) =>
            {
                var entry = (Entry)s;

                if (string.IsNullOrEmpty(entry.Text))
                    return;

                var text = entry.Text;
                int n;
                bool isNumeric = int.TryParse(text, out n);

                if (isNumeric)
                {
                    if (n > MaxLength)
                        text = MaxLength.ToString();
                }
                else
                {
                    if (text.Length > MaxLength)
                        text = entry.Text.Substring(0, MaxLength);
                }

                entry.Text = text;
            };
        }
    }
}
