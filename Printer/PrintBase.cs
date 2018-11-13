// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Drawing;
using System.Drawing.Printing;

namespace Printer
{
  public abstract class PrintBase
  {
    protected Action<Graphics> print;
    protected float width;

    protected void Print(string printerName, Action<Graphics> print)
    {
      this.print = print;

      PrintDocument pd = new PrintDocument();

      pd.PrinterSettings.PrinterName = printerName; // TODO: it would be better to take printer name from the configuration settings
      pd.PrintPage += PrintPage;
      this.width = pd.DefaultPageSettings.PrintableArea.Width * 2.539993f / 10f; // Convert inches to millimeters

      try
      {
        pd.Print();
      }
     
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    private void PrintPage(object sender, PrintPageEventArgs e)
    {
      Graphics g = e.Graphics;

      g.PageUnit = GraphicsUnit.Millimeter;

      this.print(g);
    }

    protected float DrawTextColumns(Graphics g, float y, params TextColumn[] textColumns)
    {
      float maxHeight = 0f;
      float relativeLeft = 0f;

      foreach (TextColumn textColumn in textColumns)
        using (Font font = new Font(FontFamily.GenericSansSerif, textColumn.FontSize, FontStyle.Regular))
        {
          SizeF size = g.MeasureString(textColumn.Text, font, new SizeF(this.width * textColumn.RelativeWidth, 0));

          if (maxHeight < size.Height)
            maxHeight = size.Height;

          g.DrawString(
            textColumn.Text,
            font,
            Brushes.Black,
            new RectangleF(relativeLeft, y, this.width * textColumn.RelativeWidth, size.Height),
            new StringFormat() { Alignment = textColumn.Alignment }
          );

          relativeLeft += this.width * textColumn.RelativeWidth;
        }

      return maxHeight;
    }
  }
}