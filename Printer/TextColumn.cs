// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Drawing;

namespace Printer
{
  public class TextColumn
  {
    public string Text { get; set; }
    public float RelativeWidth { get; set; }
    public StringAlignment Alignment { get; set; }
    public float FontSize { get; set; }

    public TextColumn(string text, float relativeWidth = 1, StringAlignment alignment = StringAlignment.Near, float fontSize = 10f)
    {
      this.Text = text;
      this.RelativeWidth = relativeWidth;
      this.Alignment = alignment;
      this.FontSize = fontSize;
    }
  }
}